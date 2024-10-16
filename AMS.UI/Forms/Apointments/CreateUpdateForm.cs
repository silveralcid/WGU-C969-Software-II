using AMS.UI.Domain.Entities;
using AMS.UI.View_Models.Components;
using AMS.UI.View_Models.Appointments;
using System.Windows.Forms;
using System;
using AMS.UI.Utils;
using AMS.UI.UseCases.Appointments;
using AMS.UI.UseCases.Customers;
using System.Collections.Generic;
using AMS.UI.UseCases.Consultants;

namespace AMS.UI.Forms.Appointments
{
    public partial class CreateUpdateForm : Form
    {
        CreateUpdateVM vm;
        List<Customer> Customers = CustomerService.GetAll();
        List<User> Consultants = ConsultantService.GetAll();
        Appointment currentAppointment;
        public CreateUpdateForm(Appointment appointment)
        {
            InitializeComponent();

            lblTitle.Text = appointment.IsPresent ? "Update Appointment" :  "Add New Appointment";
            vm = new CreateUpdateVM(appointment);
            currentAppointment = appointment;
            setFieldValues();
        }

        private void btnReset_Click(object sender, System.EventArgs e)
        {
            resetForm();
        }

        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            if (!vm.IsValid())
            {
                displayAllErrors();
            }
            else
            {
                hideAllErrors();
                Appointment appointment = vm.ToEntity();
                CmbOption selectedCustomer = cmbCustomerNames.SelectedItem as CmbOption;
                appointment.Customer = new Customer()
                {
                    Id = selectedCustomer.Value,
                    Name = selectedCustomer.Label
                };
                appointment.Id = currentAppointment.Id;
                appointment.User = new User() { Id = vm.consultantId };
                try
                {
                    AppointmentService.Save(appointment);
                    resetForm();
                    MessageBox.Show("Appointment is saved!");
                    Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Unable to save the Appointment");
                }
            }
        }

        #region TextChanged handlers
        private void cmbCustomerNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomerNames.SelectedItem == null) return;

            vm.CustomerName.Value = ((CmbOption)cmbCustomerNames.SelectedItem).Label;
        }

        private void cmbConsultant_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbConsultant.SelectedItem == null) return;
            CmbOption option = cmbConsultant.SelectedItem as CmbOption;
            vm.ConsultantName.Value = option.Label;
            vm.consultantId = option.Value;
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            vm.Title.Value = txtTitle.Text;
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            vm.Description.Value = txtDescription.Text;
        }

        private void txtLocation_TextChanged(object sender, EventArgs e)
        {
            vm.Location.Value = txtLocation.Text;
        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {
            vm.Contact.Value = txtContact.Text;
        }

        private void txtType_TextChanged(object sender, EventArgs e)
        {
            vm.Type.Value = txtType.Text;
        }

        private void txtURL_TextChanged(object sender, EventArgs e)
        {
            vm.URL.Value = txtURL.Text;
        }

        private void dtpStartTime_ValueChanged(object sender, EventArgs e)
        {
            vm.StartTime.Value = dtpStartTime.Value.ToString();
        }

        private void dtpEndTime_ValueChanged(object sender, EventArgs e)
        {
            vm.EndTime.Value = dtpEndTime.Value.ToString();
        }
        #endregion

        #region ErrorMessage Display
        private void displayAllErrors()
        {
            displayError(lblCustomerNameError, vm.CustomerName);
            displayError(lblConsultantError, vm.ConsultantName);
            displayError(lblTitleError, vm.Title);
            displayError(lblDescriptionError, vm.Description);
            displayError(lblLocationError, vm.Location);
            displayError(lblTypeError, vm.Type);
            displayError(lblContactError, vm.Contact);
            displayError(lblURLError, vm.URL);
            displayError(lblStartTimeError, vm.StartTime);
            displayError(lblEndTimeError, vm.EndTime);
        }

        private void hideAllErrors()
        {
            FormHelper.HideErrorLabels(this);
        }

        private void displayError(Label lblError, Field field)
        {
            lblError.Visible = true;
            lblError.Text = field.Error;
        }
        #endregion

        #region Setters Resetters
        private void setFieldValues()
        {
            foreach (var customer in Customers)
            {
                cmbCustomerNames.Items.Add(new CmbOption() { Value = customer.Id, Label = customer.Name });
            }
            foreach (var consultant in Consultants)
            {
                cmbConsultant.Items.Add(new CmbOption() { Value = consultant.Id, Label = consultant.UserName });
            }

            Customer selectedCustomer = null;
            User selectedConsultant = null;

            if (vm.CustomerName.Value != null)
            {
                selectedCustomer = Customers.Find((customer) => customer.Name == vm.CustomerName.Value);
            }

            if (vm.ConsultantName.Value != null)
            {
                selectedConsultant = Consultants.Find((consultant) => consultant.UserName == vm.ConsultantName.Value);
                vm.consultantId = selectedConsultant.Id;
            }

            if(selectedCustomer != null)
            {
                foreach (var item in cmbCustomerNames.Items)
                {
                    CmbOption option = item as CmbOption;

                    if (option.Label == selectedCustomer.Name)
                    {
                        cmbCustomerNames.SelectedItem = item;
                    }
                }
            }

            if (selectedConsultant != null)
            {
                foreach (var item in cmbConsultant.Items)
                {
                    CmbOption option = item as CmbOption;

                    if (option.Label == selectedConsultant.UserName)
                    {
                        cmbConsultant.SelectedItem = item;
                    }
                }
            }

            txtTitle.Text = vm.Title.Value;
            txtDescription.Text = vm.Description.Value;
            txtLocation.Text = vm.Location.Value;
            txtType.Text = vm.Type.Value;
            txtContact.Text = vm.Contact.Value;
            txtURL.Text = vm.URL.Value;
            dtpStartTime.Value = Convert.ToDateTime(vm.StartTime.Value);
            dtpEndTime.Value = Convert.ToDateTime(vm.EndTime.Value);
        }

        private void resetForm()
        {
            FormHelper.ResetForm(this);
            hideAllErrors();
        }
        #endregion
        
    }
}

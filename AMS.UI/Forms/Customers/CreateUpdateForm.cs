using AMS.UI.Domain.Entities;
using AMS.UI.View_Models.Components;
using AMS.UI.View_Models.Customers;
using AMS.UI.UseCases.Customers;
using System.Windows.Forms;

namespace AMS.UI.Forms.Customers
{
    public partial class CreateUpdateForm : Form
    {
        CreateUpdateVM vm;
        public CreateUpdateForm(Customer customer)
        {
            InitializeComponent();

            lblTitle.Text = customer.IsPresent ? "Update Customer" : "Add New Customer";
            vm = new CreateUpdateVM(customer);
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
                Customer customer = vm.ToEntity();

                CustomerService.Save(customer);
                MessageBox.Show("Customer has been saved successfully!");
                resetForm();
            }
        }

        #region TextChanged handlers
        private void txtCustomerName_TextChanged(object sender, System.EventArgs e)
        {
            vm.CustomerName.Value = txtCustomerName.Text;
        }

        private void txtAddress_TextChanged(object sender, System.EventArgs e)
        {
            vm.Address.Value = txtAddress.Text;
        }

        private void txtPostalCode_TextChanged(object sender, System.EventArgs e)
        {
            vm.PostalCode.Value = txtPostalCode.Text;
        }

        private void txtCity_TextChanged(object sender, System.EventArgs e)
        {
            vm.City.Value = txtCity.Text;
        }

        private void txtCountry_TextChanged(object sender, System.EventArgs e)
        {
            vm.Country.Value = txtCountry.Text;
        }

        private void txtPhoneNumber_TextChanged(object sender, System.EventArgs e)
        {
            vm.PhoneNumber.Value = txtPhoneNumber.Text;
        }
        #endregion

        #region ErrorMessage Display
        private void displayAllErrors()
        {
            displayError(lblCustomerNameError, vm.CustomerName);
            displayError(lblAddressError, vm.Address);
            displayError(lblPostalCodeError, vm.PostalCode);
            displayError(lblCityError, vm.City);
            displayError(lblCountryError, vm.Country);
            displayError(lblPhoneNumberError, vm.PhoneNumber);
        }

        private void hideAllErrors()
        {
            lblCustomerNameError.Visible = false;
            lblAddressError.Visible = false;
            lblPostalCodeError.Visible = false;
            lblCityError.Visible = false;
            lblCountryError.Visible = false;
            lblPhoneNumberError.Visible = false;
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
            txtCustomerName.Text = vm.CustomerName.Value;
            txtAddress.Text = vm.Address.Value;
            txtPostalCode.Text = vm.PostalCode.Value;
            txtCity.Text = vm.City.Value;
            txtCountry.Text = vm.Country.Value;
            txtPhoneNumber.Text = vm.PhoneNumber.Value;
        }


        private void resetForm()
        {
            txtCustomerName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPostalCode.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtCountry.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
        }
        #endregion
    }
}

using AMS.UI.Domain.Entities;
using AMS.UI.Utils;
using AMS.UI.UseCases.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AMS.UI.Forms.Customers
{
    public partial class View : Form
    {
        List<Customer> Customers = new List<Customer>();
        Customer selectedCustomer;

        public View()
        {
            InitializeComponent();
        }

        private void View_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            Customers = CustomerService.GetAll();

            dgvCustomers.Rows.Clear();
            foreach (var customer in Customers)
            {
                dgvCustomers.Rows.Add(
                    customer.Id,
                    customer.Name,
                    customer.Address.Line1,
                    customer.Address.PostalCode,
                    customer.Address.PhoneNumber,
                    customer.Address.City.Name,
                    customer.Address.City.Country.Name
                );
            }

            setSelectedCustomer();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormHelper.ReOpenAfterClose(
                this,
                new CreateUpdateForm(
                    new Customer()
                )
            );

            LoadCustomers();
        }

        private void setSelectedCustomer()
        {
            if (dgvCustomers.SelectedRows.Count > 0)
            {
                var selectedRow = dgvCustomers.SelectedRows[0];
                int customerId = Convert.ToInt32(selectedRow.Cells["colId"].Value);
                selectedCustomer = Customers.Find((customer) => customer.Id == customerId);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FormHelper.ReOpenAfterClose(
                this,
                new CreateUpdateForm(
                    selectedCustomer
                )
            );
            LoadCustomers();
        }

        private void dgvCustomers_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            setSelectedCustomer();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (CustomerService.Delete(selectedCustomer))
            {
                MessageBox.Show("Successfully delete the selected customer");
                LoadCustomers();
            }
        }
    }
}

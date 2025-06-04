using MiniCRMApp.Data;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniCRMApp
{
    public partial class AddEditCustomerForm : Form
    {

        public Customer Customer { get; private set; }
        public AddEditCustomerForm()
        {
            InitializeComponent();

        }

        

        public AddEditCustomerForm(Customer customer) : this()
        {
            if (customer != null)
            {
                this.Text = "Редактирование клиента";
                Customer = customer;
                txtFullName.Text = customer.FullName;
                txtEmail.Text = customer.Email;
                txtPhone.Text = customer.Phone;
                txtAddress.Text = customer.Address;
            }
            else
            {
                this.Text = "Добавление клиента";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Пожалуйста, введите полное имя клиента.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Customer == null)
                Customer = new Customer();

            Customer.FullName = txtFullName.Text;
            Customer.Email = txtEmail.Text;
            Customer.Phone = txtPhone.Text;
            Customer.Address = txtAddress.Text;

            DialogResult = DialogResult.OK;
        }
    }
}

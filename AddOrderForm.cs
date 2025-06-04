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
    public partial class AddOrderForm : Form
    {

        public Order Order { get; private set; }
        private readonly int _customerId;

        public AddOrderForm(int customerId)
        {
            InitializeComponent();
            _customerId = customerId;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (numTotalAmount.Value <= 0)
            {
                MessageBox.Show("Введите сумму заказа больше нуля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Order = new Order
            {
                CustomerId = _customerId,
                OrderName = txtOrderName.Text,
                OrderDate = dtpOrderDate.Value,
                TotalAmount = numTotalAmount.Value
            };

            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}

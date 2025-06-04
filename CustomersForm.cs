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
    public partial class CustomersForm : Form
    {

        private MiniCRMContext _context;
        public CustomersForm()
        {
            InitializeComponent();
            _context = new MiniCRMContext();
        }

        private void CustomersForm_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            gridControl1.DataSource = _context.Customers.ToList();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        private void CustomersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _context.Dispose();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new AddEditCustomerForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _context.Customers.Add(form.Customer);
                    _context.SaveChanges();
                    LoadCustomers();
                }
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            var hitInfo = gridView1.CalcHitInfo(gridControl1.PointToClient(Cursor.Position));
            if (hitInfo.InRow)
            {
                var customer = gridView1.GetRow(hitInfo.RowHandle) as Customer;
                if (customer != null)
                {
                    using (var form = new AddEditCustomerForm(customer))
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            _context.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                            _context.SaveChanges();
                            LoadCustomers();
                        }
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var rowHandle = gridView1.FocusedRowHandle;
            if (rowHandle >= 0)
            {
                var customer = gridView1.GetRow(rowHandle) as Customer;
                if (customer != null)
                {
                    var result = MessageBox.Show($"Вы уверены, что хотите удалить клиента {customer.FullName}?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        _context.Customers.Remove(customer);
                        _context.SaveChanges();
                        LoadCustomers();
                    }
                }
            }
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            var rowHandle = gridView1.FocusedRowHandle;
            if (rowHandle >= 0)
            {
                var customer = gridView1.GetRow(rowHandle) as Customer;
                if (customer != null)
                {
                    using (var form = new OrdersForm(customer))
                    {
                        form.ShowDialog();
                    }
                }
            }
        }
    }
}

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
    public partial class OrdersForm : Form
    {
        private readonly MiniCRMContext _context;
        private readonly Customer _customer;
        public OrdersForm(Customer customer)
        {
            InitializeComponent();

            _context = new MiniCRMContext();
            _customer = customer;
            this.Text = $"Заказы клиента: {_customer.FullName}";
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            LoadOrders();

        }

        private void LoadOrders()
        {
            gridControl1.DataSource = _context.Orders
                .Where(o => o.CustomerId == _customer.Id)
                .ToList();
            gridView1.Columns["CustomerId"].Visible = false;
            gridView1.Columns["Customer"].Visible = false;

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {
            using (var form = new AddOrderForm(_customer.Id))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _context.Orders.Add(form.Order);
                    _context.SaveChanges();
                    LoadOrders();
                }
            }
        }

        private void OrdersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _context.Dispose();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            if (_customer == null)
                return;

            var report = new OrdersReport();

            // Передаём данные в отчет
            report.DataSource = _context.Orders.Where(o => o.CustomerId == _customer.Id).ToList();
            report.Parameters["CustomerName"].Value = _customer.FullName; // если в отчете будет параметр CustomerName
            report.Parameters["CustomerName"].Visible = false;

            // Показать превью
            var printTool = new DevExpress.XtraReports.UI.ReportPrintTool(report);
            printTool.ShowPreviewDialog();
        }
    }
}

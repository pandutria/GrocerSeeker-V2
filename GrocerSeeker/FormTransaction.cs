using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrocerSeeker
{
    public partial class FormTransaction : Form
    {
        DataBaseDataContext db = new DataBaseDataContext();
        public FormTransaction()
        {
            InitializeComponent();
        }

        private void FormTransaction_Load(object sender, EventArgs e)
        {
            showDataHistory();
            showDataPending();
            btnApprove.Visible = false;
            btnCancel.Visible = false;
            btnDecline.Visible = false;
        }

        void showDataHistory()
        {
            dgvDataHistory.Columns.Clear();

            var query = db.transactions.Where(x => x.status != "pending").Select(x => new
            {
                x.id,
                x.product.product_name,
                x.user.vendor_name,
                x.quantity,
                x.product.price_per_unit,
                x.total_price,
                vendor_id = x.user.id,
                customer_id = x.user1.id,
                x.delivery_cost
            }).ToList();

            if (FormLogin.role == "customer")
            {
                query = query.Where(x => x.customer_id == FormLogin.user.id).ToList();
            } else
            {
                query = query.Where(x => x.vendor_id == FormLogin.user.id).ToList();
            }

            dgvDataHistory.DataSource = query;
            dgvDataHistory.Columns["id"].Visible = false;
            dgvDataHistory.Columns["vendor_id"].Visible = false;
            dgvDataHistory.Columns["customer_id"].Visible = false;
        }

        void showDataPending()
        {
            dgvPending.Columns.Clear();

            var query = db.transactions.Where(x => x.status == "pending").Select(x => new
            {
                x.id,
                x.product.product_name,
                x.user.vendor_name,
                x.quantity,
                x.product.price_per_unit,
                x.total_price,
                vendor_id = x.user.id,
                customer_id = x.user1.id,
                x.delivery_cost
            }).ToList();

            if (FormLogin.role == "customer")
            {
                query = query.Where(x => x.customer_id == FormLogin.user.id).ToList();
            }
            else
            {
                query = query.Where(x => x.vendor_id == FormLogin.user.id).ToList();
            }

            dgvPending.DataSource = query;
            dgvPending.Columns["id"].Visible = false;
            dgvPending.Columns["vendor_id"].Visible = false;
            dgvPending.Columns["customer_id"].Visible = false;
        }

        private void dgvDataHistory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var id = (int)dgvDataHistory.Rows[e.RowIndex].Cells["id"].Value;
                var query = db.transactions.FirstOrDefault(x => x.id == id);

                if (query != null)
                {
                    transactionId = query.id;
                    lblName.Text = query.product.product_name;
                    lblVendorName.Text = query.user.vendor_name;
                    lblQty.Text = query.quantity.ToString();
                    lblPrice.Text = query.product.price_per_unit.ToString();
                    lblTotal.Text = query.total_price.ToString();
                    lblCost.Text = query.delivery_cost.ToString();

                    btnCancel.Visible = false;
                }
            }
        }

        int transactionId;

        private void dgvPending_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var id = (int)dgvPending.Rows[e.RowIndex].Cells["id"].Value;
                var query = db.transactions.FirstOrDefault(x => x.id == id);

                if (query != null)
                {
                    transactionId = query.id;
                    lblName.Text = query.product.product_name;
                    lblVendorName.Text = query.user.vendor_name;
                    lblQty.Text = query.quantity.ToString();
                    lblPrice.Text = query.product.price_per_unit.ToString();
                    lblTotal.Text = query.total_price.ToString();
                    lblCost.Text = query.delivery_cost.ToString();

                    if (FormLogin.role == "customer")
                    {
                        btnCancel.Visible = true;
                    }
                    else
                    {
                        btnApprove.Visible = true;
                        btnDecline.Visible = true;
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var query = db.transactions.FirstOrDefault(x => x.id == transactionId);

            if (query != null)
            {
                query.status = "abort";

                var queryRestock = db.products.FirstOrDefault(x => x.id == query.product_id);
                if (queryRestock != null)
                {
                    queryRestock.unit_stock += query.quantity;
                }

                db.SubmitChanges();
                showDataHistory();
                showDataPending();
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            var query = db.transactions.FirstOrDefault(x => x.id == transactionId);

            if (query != null)
            {
                query.status = "success";
                db.SubmitChanges();
                showDataHistory();
                showDataPending();
            }
        }

        private void btnDecline_Click(object sender, EventArgs e)
        {
            var query = db.transactions.FirstOrDefault(x => x.id == transactionId);

            if (query != null)
            {
                query.status = "abort";

                var queryRestock = db.products.FirstOrDefault(x => x.id == query.product_id);
                if (queryRestock != null)
                {
                    queryRestock.unit_stock += query.quantity;
                }

                db.SubmitChanges();
                showDataHistory();
                showDataPending();
            }
        }
    }
}

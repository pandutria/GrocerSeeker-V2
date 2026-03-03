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
    public partial class FormProduct : Form
    {
        DataBaseDataContext db = new DataBaseDataContext();
        public FormProduct()
        {
            InitializeComponent();
        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
            if (FormLogin.role == "customer")
            {
                gbTransaction.Visible = false;
                gbDetails.Enabled = false;
                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                lblUnit.Visible = false;
                rbPcs.Visible = true;
                rbKg.Visible = true;
                cboStatus.Visible = false;
                lblStatus.Visible = false;
                btnSave.Visible = false;
                btnCancel.Visible = false;

                showDataIfCustomer();
            } else
            {
                gbTransaction.Visible = false;
                btnAdd.Visible = true;
                btnEdit.Visible = true;
                btnDelete.Visible = true;
                lblUnit.Visible = true;
                rbPcs.Visible = true;
                rbKg.Visible = true;
                cboStatus.Visible = false;
                lblStatus.Visible = true;
                btnSave.Visible = true;
                btnCancel.Visible = true;

                showDataIfVendor();
            }
        }

        void showDataIfCustomer()
        {
            dgvData.Columns.Clear();

            var query = db.products.Where(x => x.user.vendor_active == 1 && x.unit_stock > 0 && x.is_active == 1).Select(x => new
            {
                user_id = x.user.id,
                x.id,
                x.user.vendor_name,
                x.product_name,
                x.category.name,
                x.unit_type,
                x.price_per_unit,
                x.unit_stock,
            }).ToList();

            if (FormLogin.user.vendor_active == 1)
            {
                query = query.Where(x => x.user_id != FormLogin.user.id).ToList();
            }

            dgvData.DataSource = query;

            dgvData.Columns["user_id"].Visible = false;
            dgvData.Columns["id"].Visible = false;
        }

        void showDataIfVendor()
        {
            dgvData.Columns.Clear();

            var cb = new DataGridViewCheckBoxColumn();
            cb.HeaderText = "status";
            cb.Name = "cbStatus";
            cb.TrueValue = 1;
            cb.FalseValue = 0;
            cb.DataPropertyName = "is_active";

            var query = db.products.Where(x => x.user.vendor_active == 1 && x.unit_stock > 0 && x.is_active == 1).Select(x => new
            {
                user_id = x.user.id,
                x.id,
                x.product_name,
                x.category.name,
                x.unit_type,
                x.price_per_unit,
                x.unit_stock,
                x.is_active
            }).ToList();

            if (FormLogin.user.vendor_active == 1)
            {
                query = query.Where(x => x.user_id != FormLogin.user.id).ToList();
            }

            dgvData.DataSource = query;

            dgvData.Columns["user_id"].Visible = false;
            dgvData.Columns["is_active"].Visible = false;
            dgvData.Columns["id"].Visible = false;
            dgvData.Columns.Add(cb);
        }

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (FormLogin.role == "customer")
                {
                    gbTransaction.Visible = true;
                }

                var id = (int) dgvData.Rows[e.RowIndex].Cells["id"].Value;
                var query = db.products.FirstOrDefault(x => x.id == id);

                if (query != null)
                {
                    tbName.Text = query.product_name;
                    cboCategory.Text = query.category.name;
                    nupPrice.Value = Convert.ToInt32(query.price_per_unit);
                    nupStock.Value = Convert.ToDecimal(query.unit_stock);
                    vendorLatitude = Convert.ToDouble(query.user.vendor_latitude);
                    vendorLongitude = Convert.ToDouble(query.user.vendor_longitude);

                    if (query.unit_type == "measurable")
                    {
                        rbKg.Checked = true;
                    } else
                    {
                        rbPcs.Checked = true;
                    }

                    var distance = (calculateDistance() /  100) * 15000;

                    //if dont need coma
                    lblCost.Text = distance.ToString();

                    //if need coma
                    //lblCost.Text = Math.Floor(distance).ToString();
                    //lblCost.Text = Math.Ceiling(distance).ToString();
                    //lblCost.Text = Math.Round(distance).ToString();
                }
            }
        }

        private void nupQty_ValueChanged(object sender, EventArgs e)
        {
            lblTotal.Text = $"{nupPrice.Value * nupQty.Value}";
        }

        double toRadian(double radius)
        {
            return radius * (Math.PI / 180);
        }

        double vendorLatitude;
        double vendorLongitude;

        //if dont need coma
        int calculateDistance()
        {
            var customerLatitude = Convert.ToDouble(FormLogin.user.cust_latitude);
            var customerLongitude = Convert.ToDouble(FormLogin.user.cust_longitude);

            var a = Math.Pow(Math.Sin((toRadian(customerLatitude) - toRadian(vendorLatitude)) / 2), 2) +
                Math.Cos(toRadian(customerLatitude)) * Math.Cos(toRadian(vendorLatitude)) *
                Math.Pow(Math.Sin((toRadian(customerLongitude) - toRadian(vendorLongitude)) / 2), 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            var d = 6371 * c;

            return Convert.ToInt32(d);
        }

        // if need coma
        //double calculateDistance()
        //{
        //    var customerLatitude = Convert.ToDouble(FormLogin.user.cust_latitude);
        //    var customerLongitude = Convert.ToDouble(FormLogin.user.cust_longitude);

        //    var a = Math.Pow(Math.Sin((toRadian(customerLatitude) - toRadian(vendorLatitude)) / 2), 2) +
        //        Math.Cos(toRadian(customerLatitude)) * Math.Cos(toRadian(vendorLatitude)) * 
        //        Math.Pow(Math.Sin((toRadian(customerLongitude) - toRadian(vendorLongitude)) / 2), 2);

        //    var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

        //    var d = 6371 * c;

        //    return Convert.ToDouble(d);
        //}

        private void btnBuy_Click(object sender, EventArgs e)
        {
                
        }
    }
}

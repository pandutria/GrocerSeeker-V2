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
            showDataCbo();

            var list = new List<String>();
            list.Add("active");
            list.Add("inactive");
            cboStatus.DataSource = list;
            rbKg.Checked = true;

            if (FormLogin.role == "customer")
            {
                gbTransaction.Visible = false;
                gbDetails.Enabled = false;
                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                lblUnit.Visible = true;
                rbPcs.Visible = true;
                rbKg.Visible = true;
                cboStatus.Visible = false;
                lblStatus.Visible = false;
                btnSave.Visible = false;
                btnCancel.Visible = false;

                showDataIfCustomer();
            }
            else
            {
                gbTransaction.Visible = false;
                gbDetails.Enabled = false;
                btnAdd.Visible = true;
                btnEdit.Visible = true;
                btnDelete.Visible = true;
                lblUnit.Visible = true;
                rbPcs.Visible = true;
                rbKg.Visible = true;
                cboStatus.Visible = true;
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

            var query = db.products.Where(x => x.user.vendor_active == 1 && x.unit_stock > 0 && x.is_active == 1 && x.deleted_at == null).Select(x => new
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
                query = query.Where(x => x.user_id == FormLogin.user.id).ToList();
            }

            dgvData.DataSource = query;

            dgvData.Columns["user_id"].Visible = false;
            dgvData.Columns["is_active"].Visible = false;
            dgvData.Columns["id"].Visible = false;
            dgvData.Columns.Add(cb);
        }

        int cost;

        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (FormLogin.role == "customer")
                {
                    gbTransaction.Visible = true;
                }

                var id = (int)dgvData.Rows[e.RowIndex].Cells["id"].Value;
                var query = db.products.FirstOrDefault(x => x.id == id);

                if (query != null)
                {
                    tbName.Text = query.product_name;
                    cboCategory.SelectedValue = Convert.ToInt32(query.category_id);
                    nupPrice.Value = Convert.ToInt32(query.price_per_unit);
                    nupStock.Value = Convert.ToDecimal(query.unit_stock);
                    vendorLatitude = Convert.ToDouble(query.user.vendor_latitude);
                    vendorLongitude = Convert.ToDouble(query.user.vendor_longitude);
                    vendorId = Convert.ToInt32(query.user.id);
                    productId = Convert.ToInt32(query.id);

                    if (query.unit_type == "measurable")
                    {
                        rbKg.Checked = true;
                    }
                    else
                    {
                        rbPcs.Checked = true;
                    }

                    var distance = (calculateDistance() / 100) * 15000;

                    //if dont need coma
                    lblCost.Text = distance.ToString();
                    cost = distance;

                    //if need coma
                    //lblCost.Text = Math.Floor(distance).ToString();
                    //lblCost.Text = Math.Ceiling(distance).ToString();
                    //lblCost.Text = Math.Round(distance).ToString();
                }
            }
        }

        private void nupQty_ValueChanged(object sender, EventArgs e)
        {
            if (nupQty.Value > nupStock.Value)
            {
                lblError.Text = "Cannot caluculate total when quantity higher than stock";
                return;
            }

            lblTotal.Text = $"{nupPrice.Value * nupQty.Value}";
        }

        double toRadian(double radius)
        {
            return radius * (Math.PI / 180);
        }

        double vendorLatitude;
        double vendorLongitude;

        // if dont need coma
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

        int productId =  -1;
        int vendorId;

        private void btnBuy_Click(object sender, EventArgs e)
        {
            if (nupQty.Value > nupStock.Value)
            {
                lblError.Text = "Cannot caluculate total when quantity higher than stock";
                return;
            }

            if (nupQty.Value <= 0)
            {
                lblError.Text = "Qty must be higher than 0";
                return;
            }

            var queryCheck = db.transactions.Where(x => x.customer_id == FormLogin.user.id && x.status == "pending").Count();

            if (queryCheck >= 10)
            {
                lblError.Text = "Customers can only have 10 pending transactions";
                return;
            }

            var query = new transaction();
            query.customer_id = FormLogin.user.id;
            query.product_id = Convert.ToInt32(productId);
            query.vendor_id = Convert.ToInt32(vendorId);
            query.quantity = Convert.ToDouble(nupQty.Value);
            query.total_price = Convert.ToInt32(lblTotal.Text);
            query.delivery_cost = Convert.ToInt32(lblCost.Text);
            query.status = "pending";
            query.created_at = DateTime.Now;
            query.updated_at = null;

            var queryUpdate = db.products.FirstOrDefault(x => x.id == productId);
            queryUpdate.unit_stock -= Convert.ToDouble(nupQty.Value);

            db.transactions.InsertOnSubmit(query);
            db.SubmitChanges();
            new FormMain().Show();
            Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lblTotal.Text = string.Empty;
            lblCost.Text = string.Empty;
            nupQty.Value = 0;
        }

        void showDataCbo()
        {
            var data = db.categories.Where(x => x.is_active == 1).ToList();
            cboCategory.DataSource = data;
            cboCategory.ValueMember = "id";
            cboCategory.DisplayMember = "name";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            gbDetails.Enabled = true;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            gbDetails.Enabled = true;
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void rbKg_CheckedChanged(object sender, EventArgs e)
        {
            if (rbKg.Checked)
            {
                nupStock.DecimalPlaces = 2;
            }
            else
            {
                nupStock.DecimalPlaces = 0;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbName.Text == string.Empty)
            {
                lblError.Text = "Name must be filled";
                return;
            }

            if (!rbKg.Checked && !rbPcs.Checked)
            {
                lblError.Text = "Unit type must be choose between countable (pieces, items) and\r\nmeasurable (kg, litre).";
                return;
            }

            if (nupPrice.Value <= 0)
            {
                lblError.Text = "Price per unit required and should be digit.";
                return;
            }

            if (nupStock.Value <= 0)
            {
                lblError.Text = "Stock must be more than 0";
                return;
            }

            

            if (productId != -1)
            {
                var queryUpdate = db.products.FirstOrDefault(x => x.id == productId);

                if (queryUpdate != null)
                {
                    queryUpdate.product_name = tbName.Text;
                    queryUpdate.vendor_id = FormLogin.user.id;
                    queryUpdate.category_id = Convert.ToInt32(cboCategory.SelectedValue);
                    queryUpdate.price_per_unit = Convert.ToDecimal(nupPrice.Value);
                    queryUpdate.unit_stock = Convert.ToDouble(nupStock.Value);

                    if (rbKg.Checked)
                    {
                        queryUpdate.unit_type = "measurable";
                    }
                    else
                    {
                        queryUpdate.unit_type = "countable";
                    }

                    queryUpdate.price_per_unit = Convert.ToDecimal(queryUpdate.price_per_unit);

                    if (cboStatus.Text == "active")
                    {
                        queryUpdate.is_active = 1;
                    }
                    else
                    {
                        queryUpdate.is_active = 0;
                    }

                    queryUpdate.created_at = DateTime.Now;
                    queryUpdate.updated_at = DateTime.Now;
                    queryUpdate.deleted_at = null;

                    db.SubmitChanges();
                    MessageBox.Show("Update data success");
                    productId = -1;
                    return;
                }
            }

            var query = new product();
            query.id = db.products.OrderByDescending(x => x.id).FirstOrDefault().id + 1;
            query.product_name = tbName.Text;
            query.vendor_id = FormLogin.user.id;
            query.category_id = Convert.ToInt32(cboCategory.SelectedValue);
            query.price_per_unit = Convert.ToDecimal(nupPrice.Value);
            query.unit_stock = Convert.ToDouble(nupStock.Value);

            if (rbKg.Checked)
            {
                query.unit_type = "measurable";
            }
            else
            {
                query.unit_type = "countable";
            }

            query.price_per_unit = Convert.ToDecimal(query.price_per_unit);

            if (cboStatus.Text == "active")
            {
                query.is_active = 1;
            } else
            {
                query.is_active = 0;
            }

            query.created_at = DateTime.Now;
            query.updated_at = null;
            query.deleted_at = null;

            db.products.InsertOnSubmit(query);
            db.SubmitChanges();

            MessageBox.Show("Create data success");
            new FormMain().Show();
            Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var query = db.products.FirstOrDefault(x => x.id == productId);

            if (query != null)
            {
                query.deleted_at = DateTime.Now;
                db.SubmitChanges();
                MessageBox.Show("Delete data success");
                showDataIfVendor();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            gbDetails.Enabled = false;
            btnEdit.Enabled = true;
            btnAdd.Enabled = true;
            btnDelete.Enabled = true;
        }
    }
}

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
                gbTransaction.Visible = true;
                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                lblUnit.Visible = false;
                rbPcs.Visible = false;
                rbKg.Visible = false;
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
            dgvData.Columns.Add(cb);
        }
    }
}

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
    public partial class FormProfile : Form
    {
        DataBaseDataContext db = new DataBaseDataContext();
        public FormProfile()
        {
            InitializeComponent();
        }

        private void FormProfile_Load(object sender, EventArgs e)
        {
            tbPhone.Enabled = false;

            var query = db.users.FirstOrDefault(x => x.id == FormLogin.user.id);

            if (query != null)
            {
                tbPhone.Text = query.phone_number;
                tbEmail.Text = query.email;

                if (query.vendor_active == 1)
                {
                    cbVendor.Checked = true;
                    gbVendor.Enabled = true;
                    tbVendorName.Text = query.vendor_name;
                    tbVendorAddress.Text = query.vendor_address;
                    tbVendorLat.Text = query.vendor_latitude.ToString();
                    tbVendorLong.Text = query.vendor_longitude.ToString();
                }
                else
                {
                    gbVendor.Enabled = false;
                }

                if (query.cust_active == 1)
                {
                    cbCustomer.Checked = true;
                    gbCustomer.Enabled = true;
                    tbCustomerName.Text = query.cust_name;
                    tbCustomerAddress.Text = query.cust_address;
                    tbCustomerLat.Text = query.cust_latitude.ToString();
                    tbCustomerLong.Text = query.cust_longitude.ToString();
                }
                else
                {
                    gbCustomer.Enabled = false;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbEmail.Text == string.Empty)
            {
                lblError.Text = "All field must be filled";
                return;
            }

            if (!FormCreateNewForm.isValidEmail(tbEmail.Text))
            {
                lblError.Text = "Must be a proper email format";
                return;
            }

            if (!cbCustomer.Checked && !cbVendor.Checked)
            {
                lblError.Text = "Role must be fill at least 1 role.";
                return;
            }

            if (cbVendor.Checked)
            {
                if (tbVendorName.Text == string.Empty)
                {
                    lblError.Text = "Vendor name must be filled";
                    return;
                }

                if (tbVendorAddress.Text == string.Empty)
                {
                    lblError.Text = "Vendor address must be filled";
                    return;
                }

                var latitude = tbVendorLat.Text.Trim().Replace("-", "").Replace(".", "").Replace("+", "");
                var longitude = tbVendorLat.Text.Trim().Replace("-", "").Replace(".", "").Replace("+", "");

                if (latitude.ToString() == string.Empty || longitude.ToString() == string.Empty)
                {
                    lblError.Text = "Latitude and longitude vendor must be filled";
                    return;
                }

                if (!latitude.All(x => char.IsDigit(x)))
                {
                    lblError.Text = "Latitude and longitude vendor must be digit";
                    return;
                }

                if (!longitude.All(x => char.IsDigit(x)))
                {
                    lblError.Text = "Latitude and longitude vendor must be digit";
                    return;
                }
            }

            if (cbCustomer.Checked)
            {
                if (tbCustomerName.Text == string.Empty)
                {
                    lblError.Text = "Customer name must be filled";
                    return;
                }

                if (tbCustomerAddress.Text == string.Empty)
                {
                    lblError.Text = "Customer address must be filled";
                    return;
                }

                var latitude = tbCustomerLat.Text.Trim().Replace("-", "").Replace(".", "").Replace("+", "");
                var longitude = tbCustomerLong.Text.Trim().Replace("-", "").Replace(".", "").Replace("+", "");

                if (latitude.ToString() == string.Empty || longitude.ToString() == string.Empty)
                {
                    lblError.Text = "Latitude and longitude customer must be filled";
                    return;
                }

                if (!latitude.All(x => char.IsDigit(x)))
                {
                    lblError.Text = "Latitude and longitude customer must be digit";
                    return;
                }

                if (!longitude.All(x => char.IsDigit(x)))
                {
                    lblError.Text = "Latitude and longitude customer must be digit";
                    return;
                }
            }

            var query = db.users.FirstOrDefault(x => x.id == FormLogin.user.id);
            query.email = tbEmail.Text;
            query.updated_at = DateTime.Now;

            if (cbCustomer.Checked)
            {
                FormLogin.user = query;
                query.cust_active = 1;
                query.cust_name = tbCustomerName.Text;
                query.cust_address = tbCustomerAddress.Text;
                query.cust_latitude = Convert.ToDouble(tbCustomerLat.Text);
                query.cust_longitude = Convert.ToDouble(tbCustomerLong.Text);
            }
            else
            {
                query.cust_active = 0;
                query.cust_name = null;
                query.cust_address = null;
                query.cust_latitude = null;
                query.cust_longitude = null;
            }

            if (cbVendor.Checked)
            {
                FormLogin.user = query;
                query.vendor_active = 1;
                query.vendor_name = tbVendorName.Text;
                query.vendor_address = tbVendorAddress.Text;
                query.vendor_latitude = Convert.ToDouble(tbVendorLat.Text);
                query.vendor_longitude = Convert.ToDouble(tbVendorLong.Text);
            }
            else
            {
                query.vendor_active = 0;
                query.vendor_name = null;
                query.vendor_address = null;
                query.vendor_latitude = null;
                query.vendor_longitude = null;
            }

            if (!cbCustomer.Checked)
            {
                var transaction = db.transactions.Where(x => x.customer_id == query.id);

                foreach (var i in transaction)
                {
                    i.status = "abort";
                }
                db.SubmitChanges();
            }

            if (!cbVendor.Checked)
            {
                var transaction = db.transactions.Where(x => x.vendor_id == query.id);

                foreach (var i in transaction)
                {
                    i.status = "abort";
                }

                db.SubmitChanges();

                var product = db.products.Where(x => x.vendor_id == query.id);

                foreach (var i in product)
                {
                    i.is_active = 0;
                }

                db.SubmitChanges();
            }

            db.SubmitChanges();
            MessageBox.Show("Berhasil");

            if (FormLogin.role == "customer" && !cbCustomer.Checked)
            {
                new FormLogin().Show();
                Hide();
                return;
            }

            if (FormLogin.role == "vendor" && !cbVendor.Checked)
            {
                new FormLogin().Show();
                Hide();
                return;
            }

            new FormMain().Show();
            Hide();
        }

        private void cbCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCustomer.Checked)
            {
                gbCustomer.Enabled = true;
            }
            else
            {
                gbCustomer.Enabled = false;
            }
        }

        private void cbVendor_CheckedChanged(object sender, EventArgs e)
        {
            if (cbVendor.Checked)
            {
                gbVendor.Enabled = true;
            }
            else
            {
                gbVendor.Enabled = false;
            }
        }

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            var query = db.users.FirstOrDefault(x => x.id == FormLogin.user.id);

            if (query != null)
            {
                tbPhone.Text = query.phone_number;
                tbEmail.Text = query.email;

                if (query.vendor_active == 1)
                {
                    cbVendor.Checked = true;
                    gbVendor.Enabled = true;
                    tbVendorName.Text = query.vendor_name;
                    tbVendorAddress.Text = query.vendor_address;
                    tbVendorLat.Text = query.vendor_latitude.ToString();
                    tbVendorLong.Text = query.vendor_longitude.ToString();
                }
                else
                {
                    cbVendor.Checked = false;
                    gbVendor.Enabled = false;
                }

                if (query.cust_active == 1)
                {
                    cbCustomer.Checked = true;
                    gbCustomer.Enabled = true;
                    tbCustomerName.Text = query.cust_name;
                    tbCustomerAddress.Text = query.cust_address;
                    tbCustomerLat.Text = query.cust_latitude.ToString();
                    tbCustomerLong.Text = query.cust_longitude.ToString();
                }
                else
                {
                    cbCustomer.Checked = false;
                    gbCustomer.Enabled = false;
                }
            }
        }
    }
}

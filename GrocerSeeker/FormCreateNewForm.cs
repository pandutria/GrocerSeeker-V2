using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GrocerSeeker
{
    public partial class FormCreateNewForm : Form
    {
        DataBaseDataContext db = new DataBaseDataContext();
        public FormCreateNewForm()
        {
            InitializeComponent();
        }

        private void FormCreateNewForm_Load(object sender, EventArgs e)
        {
            gbVendor.Enabled = false;
            gbCustomer.Enabled = false;
        }

        public static bool isValidEmail(string email)
        {
            var regex = @"^\S+@\S+\.\S+$";
            return Regex.IsMatch(email, regex);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (tbPhone.Text == string.Empty || tbPassword.Text == string.Empty
                || tbPassword.Text == string.Empty || tbConfirmPassword.Text == string.Empty ||
                tbEmail.Text == string.Empty
                )
            {
                lblError.Text = "all field must be filled";
                return;
            }

            if (!tbPhone.Text.All(x => char.IsDigit(x)))
            {
                lblError.Text = "phone number is digit and length between 10-15 digits";
                return;
            }

            if (tbPhone.TextLength < 10 || tbPhone.TextLength > 15)
            {
                lblError.Text = "phone number is digit and length between 10-15 digits.";
                return;
            }

            var queryPhone = db.users.FirstOrDefault(x => x.phone_number == tbPhone.Text);

            if (queryPhone != null)
            {
                lblError.Text = "Phone number must be uniqe";
                return;
            }

            if (tbPassword.TextLength < 8)
            {
                lblError.Text = "Password must be minimum 8 characters.";
                return;
            }

            if (!tbPassword.Text.Any(x => char.IsUpper(x)))
            {
                lblError.Text = "Password must be a combination of uppercase, lowercase characters";
                return;
            }


            if (!tbPassword.Text.Any(x => char.IsLower(x)))
            {
                lblError.Text = "password must be a combination of uppercase, lowercase characters";
                return;
            }

            if (tbConfirmPassword.Text != tbPassword.Text)
            {
                lblError.Text = "Confirmation password must be matched with the inputted password";
                return;
            }

            if (!isValidEmail(tbEmail.Text))
            {
                lblError.Text = "Email must be a proper email format , e.g. : xxx@xxx.xxx.";
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

            // Cara 1
            var id = db.users.OrderByDescending(x => x.id).FirstOrDefault().id + 1;

            // Cara 2
            //var id = db.users.Count();

            var query = new user();
            query.id = id;
            query.phone_number = tbPhone.Text;
            query.email = tbEmail.Text;
            query.password = tbPassword.Text;
            query.created_at = DateTime.Now;
            query.updated_at = null;

            if (cbCustomer.Checked)
            {
                query.cust_active = 1;
                query.cust_name = tbCustomerName.Text;
                query.cust_address = tbCustomerAddress.Text;
                query.cust_latitude = Convert.ToDouble(tbCustomerLat.Text);
                query.cust_longitude = Convert.ToDouble(tbCustomerLong.Text);
            }
            else
            {
                query.cust_active = 0;
            }

            if (cbVendor.Checked)
            {
                query.vendor_active = 1;
                query.vendor_name = tbVendorName.Text;
                query.vendor_address = tbVendorAddress.Text;
                query.vendor_latitude = Convert.ToDouble(tbVendorLat.Text);
                query.vendor_longitude = Convert.ToDouble(tbVendorLong.Text);
            }
            else
            {
                query.vendor_active = 0;
            }

            db.users.InsertOnSubmit(query);
            db.SubmitChanges();

            new FormLogin().Show();
            Hide();
        }

        private void cbCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCustomer.Checked)
            {
                gbCustomer.Enabled = true;
            } else
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
    }
}

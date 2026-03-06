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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            tbPassword.UseSystemPasswordChar = true;

            var list = new List<string>();
            list.Add("customer");
            list.Add("vendor");

            cboLoginAs.DataSource = list;

            tbPhone.Text = "08861554350";
            tbPassword.Text = "Prggro1234";
        }

        public static user user;
        public static string role;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (tbPhone.Text == string.Empty || tbPassword.Text == string.Empty)
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
                lblError.Text =  "phone number is digit and length between 10-15 digits.";
                return;
            }

            var db = new DataBaseDataContext();
            var query = db.users.FirstOrDefault(x => x.phone_number == tbPhone.Text && x.password == tbPassword.Text);

            if (query == null)
            {
                lblError.Text = "Your data is not valid";
                return;
            }

            if (cboLoginAs.Text == "customer" && query.cust_active != 1)
            {
                lblError.Text = "unauthorized";
                return;
            }

            if (cboLoginAs.Text == "vendor" && query.vendor_active != 1)
            {
                lblError.Text = "unauthorized";
                return;
            }

            user = query;
            role = cboLoginAs.Text;
            new FormMain().Show();
            Hide();
        }

        private void linkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new FormCreateNewForm().Show();
            Hide();
        }
    }
}

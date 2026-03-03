namespace GrocerSeeker
{
    partial class FormProfile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCustomer = new System.Windows.Forms.CheckBox();
            this.cbVendor = new System.Windows.Forms.CheckBox();
            this.gbVendor = new System.Windows.Forms.GroupBox();
            this.tbVendorLong = new System.Windows.Forms.TextBox();
            this.tbVendorName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tbVendorLat = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbVendorAddress = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.gbCustomer = new System.Windows.Forms.GroupBox();
            this.tbCustomerLong = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbCustomerLat = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbCustomerAddress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbCustomerName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.btnDiscard = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.gbVendor.SuspendLayout();
            this.gbCustomer.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(321, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Your Profile";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(263, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Phone Number";
            // 
            // tbPhone
            // 
            this.tbPhone.Location = new System.Drawing.Point(378, 87);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(168, 22);
            this.tbPhone.TabIndex = 2;
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(378, 121);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(168, 22);
            this.tbEmail.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(263, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(263, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Role Creation";
            // 
            // cbCustomer
            // 
            this.cbCustomer.AutoSize = true;
            this.cbCustomer.Location = new System.Drawing.Point(378, 163);
            this.cbCustomer.Name = "cbCustomer";
            this.cbCustomer.Size = new System.Drawing.Size(86, 20);
            this.cbCustomer.TabIndex = 6;
            this.cbCustomer.Text = "Customer";
            this.cbCustomer.UseVisualStyleBackColor = true;
            this.cbCustomer.CheckedChanged += new System.EventHandler(this.cbCustomer_CheckedChanged);
            // 
            // cbVendor
            // 
            this.cbVendor.AutoSize = true;
            this.cbVendor.Location = new System.Drawing.Point(481, 162);
            this.cbVendor.Name = "cbVendor";
            this.cbVendor.Size = new System.Drawing.Size(73, 20);
            this.cbVendor.TabIndex = 7;
            this.cbVendor.Text = "Vendor";
            this.cbVendor.UseVisualStyleBackColor = true;
            this.cbVendor.CheckedChanged += new System.EventHandler(this.cbVendor_CheckedChanged);
            // 
            // gbVendor
            // 
            this.gbVendor.Controls.Add(this.tbVendorLong);
            this.gbVendor.Controls.Add(this.tbVendorName);
            this.gbVendor.Controls.Add(this.label12);
            this.gbVendor.Controls.Add(this.label16);
            this.gbVendor.Controls.Add(this.tbVendorLat);
            this.gbVendor.Controls.Add(this.label15);
            this.gbVendor.Controls.Add(this.label13);
            this.gbVendor.Controls.Add(this.tbVendorAddress);
            this.gbVendor.Controls.Add(this.label14);
            this.gbVendor.Location = new System.Drawing.Point(427, 223);
            this.gbVendor.Name = "gbVendor";
            this.gbVendor.Size = new System.Drawing.Size(366, 183);
            this.gbVendor.TabIndex = 17;
            this.gbVendor.TabStop = false;
            this.gbVendor.Text = "Vendor Details";
            // 
            // tbVendorLong
            // 
            this.tbVendorLong.Location = new System.Drawing.Point(270, 142);
            this.tbVendorLong.Name = "tbVendorLong";
            this.tbVendorLong.Size = new System.Drawing.Size(73, 22);
            this.tbVendorLong.TabIndex = 33;
            // 
            // tbVendorName
            // 
            this.tbVendorName.Location = new System.Drawing.Point(102, 35);
            this.tbVendorName.Name = "tbVendorName";
            this.tbVendorName.Size = new System.Drawing.Size(224, 22);
            this.tbVendorName.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(171, 142);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 20);
            this.label12.TabIndex = 32;
            this.label12.Text = "Longitude";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(16, 35);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 20);
            this.label16.TabIndex = 25;
            this.label16.Text = "Name";
            // 
            // tbVendorLat
            // 
            this.tbVendorLat.Location = new System.Drawing.Point(93, 142);
            this.tbVendorLat.Name = "tbVendorLat";
            this.tbVendorLat.Size = new System.Drawing.Size(67, 22);
            this.tbVendorLat.TabIndex = 31;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(16, 63);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(71, 20);
            this.label15.TabIndex = 27;
            this.label15.Text = "Address";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(16, 142);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(69, 20);
            this.label13.TabIndex = 30;
            this.label13.Text = "Latitude";
            // 
            // tbVendorAddress
            // 
            this.tbVendorAddress.Location = new System.Drawing.Point(102, 63);
            this.tbVendorAddress.Name = "tbVendorAddress";
            this.tbVendorAddress.Size = new System.Drawing.Size(224, 22);
            this.tbVendorAddress.TabIndex = 28;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(16, 103);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 20);
            this.label14.TabIndex = 29;
            this.label14.Text = "Location:";
            // 
            // gbCustomer
            // 
            this.gbCustomer.Controls.Add(this.tbCustomerLong);
            this.gbCustomer.Controls.Add(this.label11);
            this.gbCustomer.Controls.Add(this.tbCustomerLat);
            this.gbCustomer.Controls.Add(this.label10);
            this.gbCustomer.Controls.Add(this.label9);
            this.gbCustomer.Controls.Add(this.tbCustomerAddress);
            this.gbCustomer.Controls.Add(this.label8);
            this.gbCustomer.Controls.Add(this.tbCustomerName);
            this.gbCustomer.Controls.Add(this.label7);
            this.gbCustomer.Location = new System.Drawing.Point(24, 223);
            this.gbCustomer.Name = "gbCustomer";
            this.gbCustomer.Size = new System.Drawing.Size(363, 183);
            this.gbCustomer.TabIndex = 16;
            this.gbCustomer.TabStop = false;
            this.gbCustomer.Text = "Customer Details";
            // 
            // tbCustomerLong
            // 
            this.tbCustomerLong.Location = new System.Drawing.Point(269, 142);
            this.tbCustomerLong.Name = "tbCustomerLong";
            this.tbCustomerLong.Size = new System.Drawing.Size(73, 22);
            this.tbCustomerLong.TabIndex = 24;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(169, 142);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 20);
            this.label11.TabIndex = 23;
            this.label11.Text = "Longitude";
            // 
            // tbCustomerLat
            // 
            this.tbCustomerLat.Location = new System.Drawing.Point(91, 142);
            this.tbCustomerLat.Name = "tbCustomerLat";
            this.tbCustomerLat.Size = new System.Drawing.Size(67, 22);
            this.tbCustomerLat.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(14, 142);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 20);
            this.label10.TabIndex = 21;
            this.label10.Text = "Latitude";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(14, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 20);
            this.label9.TabIndex = 20;
            this.label9.Text = "Location:";
            // 
            // tbCustomerAddress
            // 
            this.tbCustomerAddress.Location = new System.Drawing.Point(100, 63);
            this.tbCustomerAddress.Name = "tbCustomerAddress";
            this.tbCustomerAddress.Size = new System.Drawing.Size(224, 22);
            this.tbCustomerAddress.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 20);
            this.label8.TabIndex = 18;
            this.label8.Text = "Address";
            // 
            // tbCustomerName
            // 
            this.tbCustomerName.Location = new System.Drawing.Point(100, 35);
            this.tbCustomerName.Name = "tbCustomerName";
            this.tbCustomerName.Size = new System.Drawing.Size(224, 22);
            this.tbCustomerName.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Name";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(289, 497);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(98, 31);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblError
            // 
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(24, 429);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(769, 56);
            this.lblError.TabIndex = 18;
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDiscard
            // 
            this.btnDiscard.Location = new System.Drawing.Point(416, 497);
            this.btnDiscard.Name = "btnDiscard";
            this.btnDiscard.Size = new System.Drawing.Size(98, 31);
            this.btnDiscard.TabIndex = 20;
            this.btnDiscard.Text = "Discard";
            this.btnDiscard.UseVisualStyleBackColor = true;
            this.btnDiscard.Click += new System.EventHandler(this.btnDiscard_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(695, 39);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(98, 31);
            this.btnEdit.TabIndex = 21;
            this.btnEdit.Text = "Edit Profile";
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // FormProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 557);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDiscard);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.gbVendor);
            this.Controls.Add(this.gbCustomer);
            this.Controls.Add(this.cbVendor);
            this.Controls.Add(this.cbCustomer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPhone);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GrocerSeeker";
            this.Load += new System.EventHandler(this.FormProfile_Load);
            this.gbVendor.ResumeLayout(false);
            this.gbVendor.PerformLayout();
            this.gbCustomer.ResumeLayout(false);
            this.gbCustomer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbCustomer;
        private System.Windows.Forms.CheckBox cbVendor;
        private System.Windows.Forms.GroupBox gbVendor;
        private System.Windows.Forms.TextBox tbVendorLong;
        private System.Windows.Forms.TextBox tbVendorName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbVendorLat;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbVendorAddress;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox gbCustomer;
        private System.Windows.Forms.TextBox tbCustomerLong;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbCustomerLat;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbCustomerAddress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbCustomerName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnDiscard;
        private System.Windows.Forms.Button btnEdit;
    }
}
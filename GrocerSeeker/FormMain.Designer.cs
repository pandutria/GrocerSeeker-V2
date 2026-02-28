namespace GrocerSeeker
{
    partial class FormMain
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
            this.lblName = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnTransaction = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome,";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblName.Location = new System.Drawing.Point(156, 27);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(129, 29);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Welcome,";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblRole.Location = new System.Drawing.Point(156, 72);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(120, 29);
            this.lblRole.TabIndex = 5;
            this.lblRole.Text = "customer";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 29);
            this.label4.TabIndex = 4;
            this.label4.Text = "Login as";
            // 
            // btnProfile
            // 
            this.btnProfile.Location = new System.Drawing.Point(26, 127);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(309, 48);
            this.btnProfile.TabIndex = 6;
            this.btnProfile.Text = "Profile";
            this.btnProfile.UseVisualStyleBackColor = true;
            // 
            // btnProduct
            // 
            this.btnProduct.Location = new System.Drawing.Point(26, 187);
            this.btnProduct.Name = "btnProduct";
            this.btnProduct.Size = new System.Drawing.Size(309, 48);
            this.btnProduct.TabIndex = 7;
            this.btnProduct.Text = "Product";
            this.btnProduct.UseVisualStyleBackColor = true;
            // 
            // btnTransaction
            // 
            this.btnTransaction.Location = new System.Drawing.Point(26, 247);
            this.btnTransaction.Name = "btnTransaction";
            this.btnTransaction.Size = new System.Drawing.Size(309, 48);
            this.btnTransaction.TabIndex = 8;
            this.btnTransaction.Text = "Transaction";
            this.btnTransaction.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(106, 311);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(145, 35);
            this.btnLogout.TabIndex = 9;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 372);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnTransaction);
            this.Controls.Add(this.btnProduct);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label1);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnTransaction;
        private System.Windows.Forms.Button btnLogout;
    }
}
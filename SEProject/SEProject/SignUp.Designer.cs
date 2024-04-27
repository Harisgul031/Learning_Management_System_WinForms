namespace SEProject
{
    partial class SignUp
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.loginID = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.Label();
            this.passwordconfirm = new System.Windows.Forms.Label();
            this.registered = new System.Windows.Forms.Button();
            this.stafftype = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(268, 113);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(268, 151);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 1;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(268, 191);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 22);
            this.textBox3.TabIndex = 2;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // loginID
            // 
            this.loginID.AutoSize = true;
            this.loginID.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginID.Location = new System.Drawing.Point(38, 113);
            this.loginID.Name = "loginID";
            this.loginID.Size = new System.Drawing.Size(138, 16);
            this.loginID.TabIndex = 3;
            this.loginID.Text = "Enter your Login ID";
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.Location = new System.Drawing.Point(38, 151);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(151, 16);
            this.Password.TabIndex = 4;
            this.Password.Text = "Enter Your Password";
            // 
            // passwordconfirm
            // 
            this.passwordconfirm.AutoSize = true;
            this.passwordconfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordconfirm.Location = new System.Drawing.Point(38, 191);
            this.passwordconfirm.Name = "passwordconfirm";
            this.passwordconfirm.Size = new System.Drawing.Size(167, 16);
            this.passwordconfirm.TabIndex = 5;
            this.passwordconfirm.Text = "Confirm Your Password";
            // 
            // registered
            // 
            this.registered.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registered.ForeColor = System.Drawing.SystemColors.Highlight;
            this.registered.Location = new System.Drawing.Point(155, 290);
            this.registered.Name = "registered";
            this.registered.Size = new System.Drawing.Size(263, 37);
            this.registered.TabIndex = 6;
            this.registered.Text = "Register and return to Login Page";
            this.registered.UseVisualStyleBackColor = true;
            this.registered.Click += new System.EventHandler(this.registered_Click);
            // 
            // stafftype
            // 
            this.stafftype.AutoSize = true;
            this.stafftype.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stafftype.Location = new System.Drawing.Point(38, 228);
            this.stafftype.Name = "stafftype";
            this.stafftype.Size = new System.Drawing.Size(78, 16);
            this.stafftype.TabIndex = 7;
            this.stafftype.Text = "Staff Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Full Name";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(268, 79);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 22);
            this.textBox5.TabIndex = 10;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(268, 228);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 22);
            this.textBox4.TabIndex = 12;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 769);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stafftype);
            this.Controls.Add(this.registered);
            this.Controls.Add(this.passwordconfirm);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.loginID);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label loginID;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.Label passwordconfirm;
        private System.Windows.Forms.Button registered;
        private System.Windows.Forms.Label stafftype;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
    }
}
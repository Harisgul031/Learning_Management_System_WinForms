namespace SEProject
{
    partial class Login
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
            this.LoginB = new System.Windows.Forms.Button();
            this.RegisterB = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.LoginID = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.Label();
            this.teacherlogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoginB
            // 
            this.LoginB.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginB.ForeColor = System.Drawing.SystemColors.Highlight;
            this.LoginB.Location = new System.Drawing.Point(137, 223);
            this.LoginB.Name = "LoginB";
            this.LoginB.Size = new System.Drawing.Size(178, 33);
            this.LoginB.TabIndex = 0;
            this.LoginB.Text = "Login as Student";
            this.LoginB.UseVisualStyleBackColor = true;
            this.LoginB.Click += new System.EventHandler(this.button1_Click);
            // 
            // RegisterB
            // 
            this.RegisterB.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegisterB.ForeColor = System.Drawing.SystemColors.Highlight;
            this.RegisterB.Location = new System.Drawing.Point(276, 368);
            this.RegisterB.Name = "RegisterB";
            this.RegisterB.Size = new System.Drawing.Size(341, 57);
            this.RegisterB.TabIndex = 1;
            this.RegisterB.Text = "Click here to Register/SignUp";
            this.RegisterB.UseVisualStyleBackColor = true;
            this.RegisterB.Click += new System.EventHandler(this.RegisterB_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(230, 116);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(230, 170);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 4;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // LoginID
            // 
            this.LoginID.AutoSize = true;
            this.LoginID.Location = new System.Drawing.Point(134, 122);
            this.LoginID.Name = "LoginID";
            this.LoginID.Size = new System.Drawing.Size(56, 16);
            this.LoginID.TabIndex = 5;
            this.LoginID.Text = "Login ID";
            // 
            // Password
            // 
            this.Password.AutoSize = true;
            this.Password.Location = new System.Drawing.Point(134, 176);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(67, 16);
            this.Password.TabIndex = 6;
            this.Password.Text = "Password";
            // 
            // teacherlogin
            // 
            this.teacherlogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teacherlogin.ForeColor = System.Drawing.SystemColors.Highlight;
            this.teacherlogin.Location = new System.Drawing.Point(321, 223);
            this.teacherlogin.Name = "teacherlogin";
            this.teacherlogin.Size = new System.Drawing.Size(205, 33);
            this.teacherlogin.TabIndex = 7;
            this.teacherlogin.Text = "Login as Teacher";
            this.teacherlogin.UseVisualStyleBackColor = true;
            this.teacherlogin.Click += new System.EventHandler(this.teacherlogin_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 769);
            this.Controls.Add(this.teacherlogin);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.LoginID);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.RegisterB);
            this.Controls.Add(this.LoginB);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoginB;
        private System.Windows.Forms.Button RegisterB;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label LoginID;
        private System.Windows.Forms.Label Password;
        private System.Windows.Forms.Button teacherlogin;
    }
}


namespace SEProject
{
    partial class Teacher_Class_Create_Join
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
            this.createclassroom = new System.Windows.Forms.Button();
            this.classromcode = new System.Windows.Forms.TextBox();
            this.classroom = new System.Windows.Forms.Button();
            this.openclass = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // createclassroom
            // 
            this.createclassroom.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createclassroom.ForeColor = System.Drawing.SystemColors.Highlight;
            this.createclassroom.Location = new System.Drawing.Point(22, 32);
            this.createclassroom.Name = "createclassroom";
            this.createclassroom.Size = new System.Drawing.Size(252, 50);
            this.createclassroom.TabIndex = 0;
            this.createclassroom.Text = "Create Classroom";
            this.createclassroom.UseVisualStyleBackColor = true;
            this.createclassroom.Click += new System.EventHandler(this.createclassroom_Click);
            // 
            // classromcode
            // 
            this.classromcode.Location = new System.Drawing.Point(293, 46);
            this.classromcode.Name = "classromcode";
            this.classromcode.Size = new System.Drawing.Size(100, 22);
            this.classromcode.TabIndex = 1;
            this.classromcode.TextChanged += new System.EventHandler(this.classromcode_TextChanged);
            // 
            // classroom
            // 
            this.classroom.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classroom.ForeColor = System.Drawing.SystemColors.Highlight;
            this.classroom.Location = new System.Drawing.Point(22, 98);
            this.classroom.Name = "classroom";
            this.classroom.Size = new System.Drawing.Size(252, 45);
            this.classroom.TabIndex = 2;
            this.classroom.Text = "Open Classroom";
            this.classroom.UseVisualStyleBackColor = true;
            this.classroom.Click += new System.EventHandler(this.classroom_Click);
            // 
            // openclass
            // 
            this.openclass.Location = new System.Drawing.Point(293, 109);
            this.openclass.Name = "openclass";
            this.openclass.Size = new System.Drawing.Size(100, 22);
            this.openclass.TabIndex = 3;
            this.openclass.TextChanged += new System.EventHandler(this.openclass_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 408);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(371, 256);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button1.Location = new System.Drawing.Point(12, 376);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(371, 35);
            this.button1.TabIndex = 5;
            this.button1.Text = "Your joined Classes";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Tomato;
            this.button2.Location = new System.Drawing.Point(760, 706);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(210, 51);
            this.button2.TabIndex = 6;
            this.button2.Text = "Logout";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Tomato;
            this.button3.Location = new System.Drawing.Point(527, 706);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(210, 51);
            this.button3.TabIndex = 7;
            this.button3.Text = "Back";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button6.Location = new System.Drawing.Point(266, 670);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(117, 38);
            this.button6.TabIndex = 12;
            this.button6.Text = "Refresh ";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 769);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.openclass);
            this.Controls.Add(this.classroom);
            this.Controls.Add(this.classromcode);
            this.Controls.Add(this.createclassroom);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createclassroom;
        private System.Windows.Forms.TextBox classromcode;
        private System.Windows.Forms.Button classroom;
        private System.Windows.Forms.TextBox openclass;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button6;
    }
}
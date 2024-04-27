using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEProject
{
    public partial class Student_Dashboard : Form
    {
        string studentid;
        string classroomcode;
        public Student_Dashboard(string studentid, string classroomcode)
        {
            this.studentid = studentid;
            this.classroomcode = classroomcode; 
           
            InitializeComponent();
            richTextBox1.Text = "Bring Laptops in your next class\nWe will have an online class coming Saturday";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Student_CourseOutline_Tab form7 = new Student_CourseOutline_Tab(studentid , classroomcode);
            this.Hide();
            form7.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Student_Assignment_Tab  form8 = new Student_Assignment_Tab(studentid , classroomcode);
            this.Hide();
            form8.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Student_query form1 = new Student_query(studentid, classroomcode);
            this.Hide();
            form1.ShowDialog();

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Login form1 = new Login();
            this.Hide();
            form1.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Student_class_join form5 = new Student_class_join(studentid);
            this.Hide();
            form5.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Student_Announcement form1 = new Student_Announcement( studentid , classroomcode);
            this.Hide();
            form1.ShowDialog();
        }
    }
}

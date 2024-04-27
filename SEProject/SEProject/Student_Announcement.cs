using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEProject
{

   
    public partial class Student_Announcement : Form
    {
        string StudentId;
        string ClassroomCode;
        string connectionString = "Data Source=HARISGUL\\SQLEXPRESS;Initial Catalog=SEProject;Integrated Security=True";
        public Student_Announcement(string StudentId,string classroomCode )
        {
            InitializeComponent();
            this.StudentId = StudentId;
            ClassroomCode = classroomCode;
            DisplayAnnouncements();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string announcementText = richTextBox2.Text;
            string loginId = StudentId;// You need to set this value

            // Insert announcement into the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO announcements (announcement, loginID, classroomcode) VALUES (@announcement, @loginID, @classroomCode)", connection);
                command.Parameters.AddWithValue("@announcement", announcementText);
                command.Parameters.AddWithValue("@loginID", loginId);
                command.Parameters.AddWithValue("@classroomCode", ClassroomCode);
                command.ExecuteNonQuery();
            }

            // Display announcements instantly
            richTextBox2.Clear();
            DisplayAnnouncements();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void DisplayAnnouncements()
        {
            richTextBox1.Clear();

            // Fetch announcements with names and display them in richTextBox1
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT a.announcement, u.name FROM announcements a INNER JOIN userr u ON a.loginID = u.username WHERE a.classroomcode = @classroomCode", connection);
                command.Parameters.AddWithValue("@classroomCode", ClassroomCode);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string announcement = reader["announcement"].ToString();
                    string name = reader["name"].ToString();

                    // Set the name in bold
                    richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                    richTextBox1.AppendText($"{name}\n");

                    // Reset font to default
                    richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                    richTextBox1.AppendText($"{announcement}\n\n\n\n");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayAnnouncements();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    SqlCommand command = new SqlCommand("DELETE FROM announcements", connection);
            //    command.ExecuteNonQuery();
            //}

            //// Clear the display in richTextBox1
            //richTextBox1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login login = new Login();  
            this.Hide();
            login.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Student_Dashboard student_Dashboard = new Student_Dashboard(StudentId , ClassroomCode );
            student_Dashboard.ShowDialog();
            this.Hide();
        }

        private void Student_Announcement_Load(object sender, EventArgs e)
        {

        }
    }
}




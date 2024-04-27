using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SEProject
{
    public partial class Student_CourseOutline_Tab : Form
    {
        string studentid;
        string classroomcode;

        public Student_CourseOutline_Tab(string studentid, string classroomcode)
        {
            this.studentid = studentid;
            this.classroomcode = classroomcode;
            InitializeComponent();

            // Fetch and display data from the database
            FetchAndDisplayData();
        }

        private void FetchAndDisplayData()
        {
            string connectionString = "Data Source=HARISGUL\\SQLEXPRESS;Initial Catalog=SEProject;Integrated Security=True"; // Update this with your actual connection string
            string query = "SELECT marks, outline FROM course_outline WHERE class_code = @classroomcode";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@classroomcode", classroomcode);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            // Populate rich text boxes with data from the database
                            richTextBox1.Text = reader["marks"].ToString();
                            richTextBox2.Text = reader["outline"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("No data found for the provided classroom code.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            // You can handle any text change events here if needed
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            // You can handle any text change events here if needed
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Login form1 = new Login();
            this.Hide();
            form1.ShowDialog();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Student_Dashboard form6 = new Student_Dashboard(studentid , classroomcode);
            this.Hide();
            form6.ShowDialog();
        }
    }
}

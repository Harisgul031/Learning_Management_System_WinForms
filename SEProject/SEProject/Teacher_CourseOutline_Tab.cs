using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SEProject
{
    public partial class Teacher_CourseOutline_Tab : Form
    {
        string teacherId;
        string classroomcode;
        string connectionString = "Data Source=HARISGUL\\SQLEXPRESS;Initial Catalog=SEProject;Integrated Security=True";

        public Teacher_CourseOutline_Tab(string teacherId, string classroomcode)
        {
            this.teacherId = teacherId;
            this.classroomcode = classroomcode;
            InitializeComponent();

            // Load data into rich text boxes
            LoadData();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT marks, outline FROM course_outline WHERE teacher_id = @teacherId AND class_code = @classroomcode";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@teacherId", teacherId);
                    command.Parameters.AddWithValue("@classroomcode", classroomcode);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            richTextBox1.Text = reader["marks"].ToString();
                            richTextBox2.Text = reader["outline"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("No data found.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Get the text from the rich text boxes
            string marks = richTextBox1.Text;
            string outline = richTextBox2.Text;

            // Check if data already exists for the teacherId and classroomcode
            bool dataExists = CheckIfDataExists();

            // Insert or update data based on whether it already exists
            if (dataExists)
            {
                UpdateData(marks, outline);
            }
            else
            {
                InsertData(marks, outline);
            }
        }

        private bool CheckIfDataExists()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM course_outline WHERE teacher_id = @teacherId AND class_code = @classroomcode";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@teacherId", teacherId);
                    command.Parameters.AddWithValue("@classroomcode", classroomcode);

                    try
                    {
                        connection.Open();
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        private void InsertData(string marks, string outline)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO course_outline (teacher_id, class_code, marks, outline) VALUES (@teacherId, @classroomcode, @marks, @outline)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@teacherId", teacherId);
                    command.Parameters.AddWithValue("@classroomcode", classroomcode);
                    command.Parameters.AddWithValue("@marks", marks);
                    command.Parameters.AddWithValue("@outline", outline);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show("Data inserted successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void UpdateData(string marks, string outline)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE course_outline SET marks = @marks, outline = @outline WHERE teacher_id = @teacherId AND class_code = @classroomcode";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@teacherId", teacherId);
                    command.Parameters.AddWithValue("@classroomcode", classroomcode);
                    command.Parameters.AddWithValue("@marks", marks);
                    command.Parameters.AddWithValue("@outline", outline);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show("Data updated successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Login form1 = new Login();
            this.Hide();
            form1.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form form4 = new Teacher_Dashboard(teacherId, classroomcode);
            this.Hide();
            form4.ShowDialog();
        }
    }
}

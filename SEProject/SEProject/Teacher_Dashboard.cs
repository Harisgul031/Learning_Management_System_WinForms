using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SEProject
{
    public partial class Teacher_Dashboard : Form
    {
        public string teacherId;
        public string classroomCode;
        //MessageBox.Show(classroomCode);

        private string connectionString = "Data Source=HARISGUL\\SQLEXPRESS;Initial Catalog=SEProject;Integrated Security=True";

        public Teacher_Dashboard(string teacherId, string classroomCode)
        {
            InitializeComponent();
            this.teacherId = teacherId;
            this.classroomCode = classroomCode;
            richTextBox1.Text = "Quote of the Day\n\n'Be Kind, It makes you Beautiful'";
            // MessageBox.Show("Classroom Code: " + classroomCode + "\nTeacher ID: " + teacherId);
        }

        private void join_button_Click(object sender, EventArgs e)
        {
            string studentId = textBox1.Text;

            // Check if student ID is empty
            if (string.IsNullOrEmpty(studentId))
            {
                MessageBox.Show("Please enter a valid ID.");
                return; // Exit the method early
            }

            // Check if the student ID exists in the 'userr' table
            bool studentExists = CheckIfStudentExists(studentId);
            if (!studentExists)
            {
                MessageBox.Show("Student ID does not exist.");
                return; // Exit the method early
            }

            // Check if the student ID is already present in the 'classroom_members' table
            bool alreadyJoined = CheckIfStudentAlreadyJoined(studentId);
            if (alreadyJoined)
            {
                MessageBox.Show("Student is already a member of the classroom.");
                return; // Exit the method early
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO classroom_members (class_code, teacher_id, student_id) VALUES (@ClassCode, @TeacherId, @StudentId)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@ClassCode", SqlDbType.VarChar, 50).Value = classroomCode;
                    command.Parameters.Add("@TeacherId", SqlDbType.VarChar, 50).Value = teacherId;
                    command.Parameters.Add("@StudentId", SqlDbType.VarChar, 50).Value = studentId;

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Student joined the classroom successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to join the classroom. Please try again.");
                    }
                }
            }
        }

        private bool CheckIfStudentExists(string studentId)
        {
            bool studentExists = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM userr WHERE username = @StudentId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentId", studentId);

                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        studentExists = true;
                    }
                }
            }

            return studentExists;
        }

        private bool CheckIfStudentAlreadyJoined(string studentId)
        {
            bool alreadyJoined = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT COUNT(*) FROM classroom_members WHERE student_id = @StudentId";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentId", studentId);

                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        alreadyJoined = true;
                    }
                }
            }

            return alreadyJoined;
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
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
            Teacher_Class_Create_Join form3 = new Teacher_Class_Create_Join(teacherId);
            this.Hide();
            form3.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Teacher_CourseOutline_Tab form9 = new Teacher_CourseOutline_Tab(teacherId,classroomCode);
            this.Hide();
            form9.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Assignment_upload assignment_Upload = new Assignment_upload( teacherId, classroomCode);
            this.Hide();
            assignment_Upload.ShowDialog();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Teacher_Announcement form1 = new Teacher_Announcement(teacherId, classroomCode);
            this.Hide();
            form1.ShowDialog();
                
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Teacher_query form1 = new Teacher_query(teacherId, classroomCode);  
            form1.ShowDialog();
            this.Hide();
        }
    }
}

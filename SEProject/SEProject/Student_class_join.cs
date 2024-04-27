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
    public partial class Student_class_join : Form
    {
        string studentid;
        string classroomCode;
        string teacheridd;
        private string connectionString = "Data Source=HARISGUL\\SQLEXPRESS;Initial Catalog=SEProject;Integrated Security=True";
        public Student_class_join(string studentid )
        {
            this.studentid = studentid;
            InitializeComponent();

            
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "SELECT class_code, teacher_id FROM classroom_members WHERE student_id = @StudentId";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@StudentId", studentid);

                            SqlDataAdapter adapter = new SqlDataAdapter(command);
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);

                            dataGridView1.DataSource = dataTable;
                        }
                    }
                
               
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
             classroomCode = textBox1.Text;

          
            if (string.IsNullOrEmpty(classroomCode))
            {
                MessageBox.Show("Please enter a classroom code.");
                return;
            }

      
            string teacherId = RetrieveTeacherId(classroomCode);
            if (!string.IsNullOrEmpty(teacherId))
            {
              
                InsertStudentIntoClassroom(studentid, classroomCode, teacherId);
            }
            else
            {
                MessageBox.Show("class doesnt exist");
            }
        }


        private string RetrieveTeacherId(string classroomCode)
        {
            string teacherId = "";
           
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT teacher_id FROM classroom WHERE classroom_code = @ClassroomCode";
                    teacheridd = query;
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ClassroomCode", classroomCode);
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            teacherId = result.ToString();
                        }
                    }
                }
          
            return teacherId;
        }

        private void InsertStudentIntoClassroom(string studentId, string classroomCode, string teacherId)
        {
            

            using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO classroom_members (class_code, teacher_id, student_id) VALUES (@ClassCode, @TeacherId, @StudentId)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ClassCode", classroomCode);
                        command.Parameters.AddWithValue("@TeacherId", teacherId);
                        command.Parameters.AddWithValue("@StudentId", studentId);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Student added to classroom successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Failed to add student to classroom. Please try again.");
                        }
                    }
                }
         
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string temp=textBox2.Text;
            classroomCode = temp;
            bool isMember = CheckClassroomMembership(studentid, temp);
            if (isMember)
            {
                Student_Dashboard form6 = new Student_Dashboard(studentid, classroomCode);
                this.Hide();
                form6.ShowDialog();
            }
            else
            {
                MessageBox.Show("Error joining to classroom , check classcode and re-enter again");
            }
        }
        private bool CheckClassroomMembership(string studentId, string classroomCode)
        {
             //classroomCode=textBox2.Text;
            bool isMember = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM classroom_members WHERE student_id = @studentid AND class_code = @classroomCode";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@studentid", studentid);
                        command.Parameters.AddWithValue("@classroomCode", classroomCode);
                        int count = (int)command.ExecuteScalar();
                        if (count > 0)
                        {
                            isMember = true;
                        }
                    }
                }
          
            return isMember;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Login form1 = new Login();
            this.Hide();
            form1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login form1 = new Login();
            this.Hide();
            form1.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT class_code, teacher_id FROM classroom_members WHERE student_id = @StudentId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentId", studentid);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SEProject
{
    public partial class Teacher_Class_Create_Join : Form
    {

        public string teacherId;
        public string classroomCode;

        public Teacher_Class_Create_Join(string teacherId)
        {
            InitializeComponent();
            this.teacherId = teacherId;
            ShowClassroomData();
        }
        private string connectionString = "Data Source=HARISGUL\\SQLEXPRESS;Initial Catalog=SEProject;Integrated Security=True";


        public Teacher_Class_Create_Join()
        {
            InitializeComponent();
        }

        private void ShowClassroomData()
        {
            
                
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    
                    connection.Open();

                   
                    string query = "SELECT * FROM classroom WHERE teacher_id = @TeacherId";

                   
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                       
                        command.Parameters.AddWithValue("@TeacherId", teacherId);

                       
                        DataTable dataTable = new DataTable();

                        
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                        
                        dataAdapter.Fill(dataTable);

                        
                        dataGridView1.DataSource = dataTable;
                    }
                }
          
        }

        private void createclassroom_Click(object sender, EventArgs e)
        {
           
             
                 classroomCode = classromcode.Text;
            if (string.IsNullOrEmpty(classroomCode))
            {
                MessageBox.Show("Please enter a valid classroom code.");
                return; // Exit the method early
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
                {
                     
                        connection.Open();

                      
                        string query = "INSERT INTO classroom (classroom_code, teacher_id) VALUES (@ClassroomCode, @teacherId)";

                       
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                          
                            command.Parameters.AddWithValue("@ClassroomCode", classroomCode);
                            command.Parameters.AddWithValue("@TeacherId", teacherId);

                          
                            int rowsAffected = command.ExecuteNonQuery();

                            
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Classroom created successfully!");
                            }
                            else
                            {
                                MessageBox.Show("Failed to create classroom. Please try again.");
                            }
                        }
                
                
                }



           
        }

        private void classromcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void classroom_Click(object sender, EventArgs e)
        {

            
            string classcode= openclass.Text;
            if (string.IsNullOrEmpty(classcode))
            {
                MessageBox.Show("Please enter a valid classroom code.");
                return; // Exit the method early
            }
            if (ValidateClassOwnership(classcode, teacherId))
            {
                MessageBox.Show("class joined successfully");
                Teacher_Dashboard form4 = new Teacher_Dashboard(teacherId, classcode);
                this.Hide();
                form4.ShowDialog();
            }
            else
            {
                MessageBox.Show("Wrong classroom code, Kindly re-enter code");
            }
        }
        private bool ValidateClassOwnership(string classCode, string teacherId)
        {
           
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM classroom WHERE classroom_code = @ClassCode AND teacher_id = @TeacherId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ClassCode", classCode);
                        command.Parameters.AddWithValue("@TeacherId", teacherId);
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
          
        }
        private void openclass_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login form1 = new Login();
            this.Hide();
            form1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login form1 = new Login();
            this.Hide();
            form1.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ShowClassroomData();
        }
    }
}

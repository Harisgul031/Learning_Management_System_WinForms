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
    public partial class Login : Form
    {


      
        private string connectionString = "Data Source=HARISGUL\\SQLEXPRESS;Initial Catalog=SEProject;Integrated Security=True";

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string loginId = textBox1.Text;
            string password = textBox2.Text;

            // Validate loginId
            if (loginId.Length >= 14 || !loginId.Any(char.IsDigit) || loginId.Count(char.IsDigit) < 2 || loginId.Length < 8)
            {
                MessageBox.Show("Login ID must be greater than 7 and less than 14 characters and contain at least 2 numbers.");
                return;
            }
            // Check if password and confirm password match




            // Validate password
            if (password.Length >= 15 || password.Length < 8 || !password.Any(char.IsLetter) || !password.Any(char.IsDigit) || !password.Any(c => !char.IsLetterOrDigit(c)))
            {
                MessageBox.Show("Password must be greater than 7 and less than 15 characters long and include letters, numbers, and special characters.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                   
                    connection.Open();

                  
                    string query = "SELECT COUNT(*) FROM userr WHERE username = @Username AND password = @Password And staff_type = 'student'";

               
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                   
                        command.Parameters.AddWithValue("@Username", loginId);
                        command.Parameters.AddWithValue("@Password", password);

                     
                        int count = (int)command.ExecuteScalar();

                        if (count > 0)
                        {
                           
                            Student_class_join form5 = new Student_class_join(loginId);
                            this.Hide();
                            form5.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password. Please try again.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegisterB_Click(object sender, EventArgs e)
        {
            SignUp form2 = new SignUp();

           
            form2.Show();
            this.Hide();
        }

        private void teacherlogin_Click(object sender, EventArgs e)
        {
          
            string loginId = textBox1.Text;
            string password = textBox2.Text;

          
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    
                    connection.Open();

                   
                    string query = "SELECT COUNT(*) FROM userr WHERE username = @Username AND password = @Password AND staff_type = 'teacher'";

                    
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                       
                        command.Parameters.AddWithValue("@Username", loginId);
                        command.Parameters.AddWithValue("@Password", password);

                        
                        int count = (int)command.ExecuteScalar();
                        if (count > 0)
                        {
                         
                            Teacher_Class_Create_Join form3 = new Teacher_Class_Create_Join(loginId);
                            form3.Show();
                            this.Hide();
                           
                        }
                        else
                        {
                            MessageBox.Show("Invalid username, password, or you are not a teacher. Please try again.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

    }
}

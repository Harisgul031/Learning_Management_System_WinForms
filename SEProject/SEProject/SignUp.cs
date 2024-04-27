using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace SEProject
{
    public partial class SignUp : Form
    {
 
        private string connectionString = "Data Source=HARISGUL\\SQLEXPRESS;Initial Catalog=SEProject;Integrated Security=True";

        public SignUp()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void registered_Click(object sender, EventArgs e)
        {
     
            string loginId = textBox1.Text;
            string password = textBox2.Text;
            string confirmPassword = textBox3.Text;
            string stafftype = textBox4.Text;
            string name = textBox5.Text;

            // Validate loginId
            if (loginId.Length >= 14 || !loginId.Any(char.IsDigit) || loginId.Count(char.IsDigit) < 2 || loginId.Length <8)
            {
                MessageBox.Show("Login ID must be greater than 7 and less than 14 characters and contain at least 2 numbers.");
                return;
            }
            // Check if password and confirm password match
           

            

            // Validate password
            if (password.Length >= 15 || password.Length <8 || !password.Any(char.IsLetter) || !password.Any(char.IsDigit) || !password.Any(c => !char.IsLetterOrDigit(c)))
            {
                MessageBox.Show("Password must be greater than 7 and less than 15 characters long and include letters, numbers, and special characters.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Password and confirm password do not match. Please try again.");
                return;
            }

            // Validate stafftype
            if (stafftype != "student" && stafftype != "teacher")
            {
                MessageBox.Show("Staff type must be either 'student' or 'teacher'.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
               
                   
                    connection.Open();

                    
                    string query = "INSERT INTO userr (username, name, password , staff_type ) VALUES (@Username, @name , @Password , @stafftype)";

                  
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                       
                        command.Parameters.AddWithValue("@Username", loginId);
                        command.Parameters.AddWithValue("name", name);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@stafftype", stafftype);

                       
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Registration successful!");
                        }
                        else
                        {
                            MessageBox.Show("Registration failed. Please try again.");
                        }
                    }
              

                Login form1 = new Login();
                form1.Show();
                this.Hide();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
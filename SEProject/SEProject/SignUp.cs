using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

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


            if (!Regex.IsMatch(loginId, @"^\d{6}$"))
            {
                MessageBox.Show("Login ID must be exactly 6 numeric digits.");
                return;
            }


            if (!Regex.IsMatch(password, @"^(?=.*[0-9])(?=.*[^a-zA-Z0-9])(?!.*\s).{7,14}$"))
            {
                MessageBox.Show("Password must be between 7 to 14 characters long, and include at least one digit, one special character, and no spaces.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Password and confirm password do not match. Please try again.");
                return;
            }

           
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
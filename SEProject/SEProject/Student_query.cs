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
    public partial class Student_query : Form
    {
        string StudentId;
        string ClassroomCode;
        string connectionString = "Data Source=HARISGUL\\SQLEXPRESS;Initial Catalog=SEProject;Integrated Security=True";
        public Student_query(string StudentId, string classroomCode)
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
            string query = richTextBox2.Text;
            string loginId = StudentId;// You need to set this value

            // Insert announcement into the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO query (query, loginID, classroomcode) VALUES (@query, @loginID, @classroomCode)", connection);
                command.Parameters.AddWithValue("@query", query);
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

            // Fetch queries with names and IDs and display them in richTextBox1
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT a.id, a.query, u.name FROM query a INNER JOIN userr u ON a.loginID = u.username WHERE a.classroomcode = @classroomCode", connection);
                command.Parameters.AddWithValue("@classroomCode", ClassroomCode);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // Check if 'id' column exists
                    if (reader["id"] != DBNull.Value)
                    {
                        string queryId = reader["id"].ToString();
                        string query = reader["query"].ToString();
                        string name = reader["name"].ToString();

                        // Set the name and query ID in bold
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                        richTextBox1.AppendText($"Query ID: {queryId}\n{name}\n");

                        // Reset font to default
                        richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                        richTextBox1.AppendText($"{query}\n");

                        // Display responses for this query ID
                        List<string> responses = GetResponsesForQuery(queryId);
                        foreach (string response in responses)
                        {
                            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                            richTextBox1.AppendText($"Response: {response}\n");

                            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                        }

                        richTextBox1.AppendText("\n\n");
                    }
                    else
                    {
                        // Handle if 'id' column is DBNull
                        richTextBox1.AppendText("Query ID not found.\n");
                    }
                }
            }
        }

        // Method to retrieve responses from Query_Response table for a given query ID
        private List<string> GetResponsesForQuery(string queryId)
        {
            List<string> responses = new List<string>();

            // Construct the SQL SELECT statement to retrieve responses for a specific query ID
            string selectQuery = "SELECT response FROM Query_Response WHERE id = @queryId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Create a command object
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    // Add parameter for query ID
                    cmd.Parameters.AddWithValue("@queryId", queryId);

                    // Execute the command and retrieve the responses
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            responses.Add(reader["response"].ToString());
                        }
                    }
                }
            }

            return responses;
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayAnnouncements();
        }
        private void button5_Click(object sender, EventArgs e)
        {
           
            Student_Dashboard  student_Dashboard= new Student_Dashboard(StudentId, ClassroomCode);
            student_Dashboard.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
            this.Hide();
        }
    }
}

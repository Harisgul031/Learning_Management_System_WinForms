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
    public partial class Teacher_query : Form
    {
        string teacherId, classroomCode;
        string connectionString = "Data Source=HARISGUL\\SQLEXPRESS;Initial Catalog=SEProject;Integrated Security=True";
        public Teacher_query(string teacherId,string classroomCode)
        {
            this.teacherId = teacherId;
            this.classroomCode = classroomCode;
            InitializeComponent();
            this.Load += Form1_Load;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateTextBox1();
        }
        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Extract the text from richTextBox2 and textBox1
            string queryText = richTextBox2.Text;
            string id = textBox1.Text;

            // Check if textBox1 is empty
            if (string.IsNullOrWhiteSpace(id))
            {
                MessageBox.Show("Please enter an ID number first.");
                return;
            }

            // Insert the data into the Query_Response table
            InsertDataIntoQueryResponse(queryText, id);
            richTextBox1.Clear();
            PopulateTextBox1();
        }

        private void InsertDataIntoQueryResponse(string queryText, string id)
        {
            // Construct the SQL INSERT statement
            string insertQuery = "INSERT INTO Query_Response (id, response, loginID, classroomcode) VALUES (@id, @response, @loginID, @classroomcode)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Create a command object
                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    // Add parameters to the command
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@response", queryText);
                    cmd.Parameters.AddWithValue("@loginID", teacherId);
                    cmd.Parameters.AddWithValue("@classroomcode", classroomCode);

                    // Execute the command
                    cmd.ExecuteNonQuery();

                    // Optionally, provide feedback to the user
                    MessageBox.Show("Data inserted successfully!");
                }
            }
        }


        private void PopulateTextBox1()
        {
            // Construct the SQL SELECT statement to retrieve data from the query table along with username from the userr table
            string selectQuery = "SELECT q.id, q.query, u.name FROM query q INNER JOIN userr u ON q.loginID = u.username";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the connection
                connection.Open();

                // Create a command object
                using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
                {
                    // Execute the command
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Check if there are rows returned
                        if (reader.HasRows)
                        {
                            // Read the data and display in richTextBox1
                            while (reader.Read())
                            {
                                // Append name with bold font
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                                richTextBox1.AppendText($"{reader["name"]}\n");

                                // Append ID and Query
                                richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Regular);
                                richTextBox1.AppendText($"ID: {reader["id"]}\n");
                                richTextBox1.AppendText($"Query: {reader["query"]}\n");

                                // Check if there are responses for this query ID in Query_Response table
                                string queryId = reader["id"].ToString();
                                List<string> responses = GetResponsesForQuery(queryId);
                                foreach (string response in responses)
                                {
                                    // Append response in bold
                                    richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
                                    richTextBox1.AppendText($"Response: {response}\n");
                                }

                                richTextBox1.AppendText("\n"); // Add a new line for separation
                            }
                        }
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

        private void button4_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.ShowDialog();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Teacher_Dashboard teacher_Dashboard = new Teacher_Dashboard(teacherId, classroomCode);
            teacher_Dashboard.ShowDialog();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

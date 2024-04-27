using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SEProject
{
    public partial class Student_Assignment_Tab : Form
    {
        string studentid;
        string classroomcode;
        private string connectionString = "Data Source=HARISGUL\\SQLEXPRESS;Initial Catalog=SEProject;Integrated Security=True"; // Update this with your actual connection string

        public Student_Assignment_Tab(string studentid, string classroomcode)
        {
            InitializeComponent();
            this.studentid = studentid;
            this.classroomcode = classroomcode;

            // Define columns for DataGridView
            dataGridView1.Columns.Add("AssignmentIdColumn", "Assignment ID");
            dataGridView1.Columns.Add("DescriptionColumn", "Description");
            dataGridView1.Columns.Add("FilePathColumn", "File Path");
            dataGridView1.Columns.Add("SubmissionDateColumn", "Submission Date");

            // Auto-adjust grid size accordingly
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Fetch and display assignment details when the form is loaded
            DisplayAssignmentDetails();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void DisplayAssignmentDetails()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT AssignmentId, AssignmentDescription, FilePath, SubmissionDate FROM Assignments WHERE ClassroomCode = @ClassroomCode";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClassroomCode", classroomcode);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            // Add assignment details to the DataGridView
                            dataGridView1.Rows.Add(
                                reader["AssignmentId"].ToString(),
                                reader["AssignmentDescription"].ToString(),
                                reader["FilePath"].ToString(),
                                reader["SubmissionDate"].ToString()
                            );
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error fetching assignment details: " + ex.Message);
                    }
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "PDF Files (*.pdf)|*.pdf|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    // Insert assignment details into the SubmittedAssignments table
                    InsertSubmittedAssignment(filePath);

                    // Update the status of the assignment to "Submitted"
                    //UpdateAssignmentStatus();
                }
            }
        }

        private void InsertSubmittedAssignment(string filePath)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
               
                string query = "INSERT INTO SubmittedAssignments (AssignmentId, StudentId, ClassroomCode, SubmissionStatus, FilePath) " +
                               "VALUES (@AssignmentId, @StudentId, @ClassroomCode, @SubmissionStatus, @FilePath)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AssignmentId", textBox2.Text);
                    command.Parameters.AddWithValue("@StudentId", studentid);
                    command.Parameters.AddWithValue("@ClassroomCode", classroomcode);
                    command.Parameters.AddWithValue("@SubmissionStatus", "Submitted");
                    command.Parameters.AddWithValue("@FilePath", filePath);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Assignment submitted successfully.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error submitting assignment: " + ex.Message);
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

        private void button4_Click(object sender, EventArgs e)
        {
            Student_Dashboard form6 = new Student_Dashboard(studentid , classroomcode);
            this.Hide();
            form6.ShowDialog();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        // Other event handlers and methods
    }
}

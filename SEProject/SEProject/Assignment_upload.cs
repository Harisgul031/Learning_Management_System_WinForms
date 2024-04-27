using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace SEProject
{
    public partial class Assignment_upload : Form
    {
        private string teacherId;
        private string classroomCode;
        private string connectionString = "Data Source=HARISGUL\\SQLEXPRESS;Initial Catalog=SEProject;Integrated Security=True"; // Update this with your actual connection string
        private string selectedFilePath;

        public Assignment_upload(string teacherId, string classroomCode)
        {
            InitializeComponent();
            this.teacherId = teacherId;
            this.classroomCode = classroomCode;
            dataGridView1.Columns.Add("AssignmentIdColumn", "Assignment ID");
            dataGridView1.Columns.Add("AssignmentDescriptionColumn", "Assignment Description");
            dataGridView1.Columns.Add("FilePathColumn", "File Path");
            dataGridView1.Columns.Add("SubmissionDateColumn", "Submission Date");

           
            dataGridView2.Columns.Add("AssignmentIdColumn", "Assignment ID");
            dataGridView2.Columns.Add("StudentIdColumn", "Student ID");
            dataGridView2.Columns.Add("SubmissionStatusColumn", "Submission Status");
            dataGridView2.Columns.Add("FilePathColumn", "File Path");

            
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Set row height
            dataGridView2.RowTemplate.Height = 30;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Set row height
            dataGridView1.RowTemplate.Height = 30;
            DisplayAssignmentDetails();
            DisplaySubmittedAssignments();
        }

        private void DisplaySubmittedAssignments()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT AssignmentId, StudentId, SubmissionStatus, FilePath FROM SubmittedAssignments WHERE ClassroomCode = @ClassroomCode";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ClassroomCode", classroomCode);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        // Clear existing data in the DataGridView
                        dataGridView2.Rows.Clear();

                        while (reader.Read())
                        {
                            // Add a new row to the DataGridView for each submitted assignment
                            dataGridView2.Rows.Add(
                                reader["AssignmentId"].ToString(),
                                reader["StudentId"].ToString(),
                                reader["SubmissionStatus"].ToString(),
                                reader["FilePath"].ToString()
                            );
                        }

                        if (dataGridView2.Rows.Count == 0)
                        {
                            MessageBox.Show("No submitted assignments found.");
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error fetching submitted assignments: " + ex.Message);
                    }
                }
            }
        }

        private void DisplayAssignmentDetails()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT AssignmentId , AssignmentDescription, FilePath, SubmissionDate FROM Assignments WHERE TeacherId = @TeacherId AND ClassroomCode = @ClassroomCode";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TeacherId", teacherId);
                    command.Parameters.AddWithValue("@ClassroomCode", classroomCode);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        
                        dataGridView1.Rows.Clear();

                        while (reader.Read())
                        {
                            
                            dataGridView1.Rows.Add(
                                reader["AssignmentId"].ToString(),
                                reader["AssignmentDescription"].ToString(),
                                reader["FilePath"].ToString(),
                                reader["SubmissionDate"].ToString()
                            );
                        }

                        if (dataGridView1.Rows.Count == 0)
                        {
                            MessageBox.Show("No assignment details found.");
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


        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "PDF Files (*.pdf)|*.pdf|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected file path
                    selectedFilePath = openFileDialog.FileName;
                    //textBox2.Text = selectedFilePath;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedFilePath))
            {
                MessageBox.Show("Please select a PDF file to upload.");
                return;
            }

            
            string assignmentDescription = richTextBox1.Text;

            

            try
            {
                
                InsertAssignmentIntoDatabase(teacherId, classroomCode, assignmentDescription, selectedFilePath);
                DisplayAssignmentDetails();
                DisplaySubmittedAssignments();
                MessageBox.Show("Assignment uploaded successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error uploading assignment: " + ex.Message);
            }
        }

        private void InsertAssignmentIntoDatabase(string teacherId, string classroomCode, string assignmentDescription, string filePath)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Assignments (TeacherId, ClassroomCode,  AssignmentDescription, FilePath) " +
                               "VALUES (@TeacherId, @ClassroomCode,  @AssignmentDescription, @FilePath)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TeacherId", teacherId);
                    command.Parameters.AddWithValue("@ClassroomCode", classroomCode);
                    //command.Parameters.AddWithValue("@AssignmentTitle", assignmentTitle);
                    command.Parameters.AddWithValue("@AssignmentDescription", assignmentDescription);
                    command.Parameters.AddWithValue("@FilePath", filePath);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error uploading assignment: " + ex.Message);
                    }
                }
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Login form1 = new Login();
            this.Hide();
            form1.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Teacher_Dashboard form4 = new Teacher_Dashboard(teacherId , classroomCode );
            this.Hide();
            form4.ShowDialog();
        }
    }
}

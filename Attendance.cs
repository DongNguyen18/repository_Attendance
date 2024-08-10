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

namespace DatabaseAttendanceASM2
{
    public partial class Attendance : Form
    {
        public Attendance()
        {
            InitializeComponent();
        }       

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=studentdb;Integrated Security=True;";

            // Define the SQL query with parameters
            string query = "INSERT INTO attendance_tad VALUES (@studentid, @studentname, @age, @Dob, @Email, @Mobile,@attendance)";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Create a new SQL command
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Add parameters with values from text boxes
                    cmd.Parameters.AddWithValue("@studentid", int.Parse(textBox7.Text));
                    cmd.Parameters.AddWithValue("@studentname", textBox1.Text);
                    cmd.Parameters.AddWithValue("@age", int.Parse(textBox3.Text));
                    cmd.Parameters.AddWithValue("@Dob", DateTime.Parse(textBox6.Text));
                    cmd.Parameters.AddWithValue("@Email", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Mobile", textBox5.Text); // Fixed spelling
                    cmd.Parameters.AddWithValue("@attendance", textBox2.Text);
                    try
                    {
                        // Open the connection
                        con.Open();

                        // Execute the command
                        cmd.ExecuteNonQuery();

                        // Show success message
                        MessageBox.Show("Record Added Successfully", "ADD", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void Attendance_Load(object sender, EventArgs e)
        {
            String connectionString = @"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=studentdb;Integrated Security=True;";

            // Define your SQL query
            string query = "SELECT * FROM attendance_tad";

            // Create a new SQL connection
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Create a new SQL command
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Create a new SQL data adapter
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    // Create a data table to hold the results
                    DataTable table = new DataTable();

                    try
                    {
                        // Open the connection
                        con.Open();

                        // Fill the data table
                        da.Fill(table);

                        // Bind the data table to the DataGridView
                        dataGridView1.DataSource = table;
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=studentdb;Integrated Security=True;";

            // Define the SQL query with parameters
            string query = "UPDATE attendance_tad SET studentname=@studentname, age=@age, Dob=@Dob, email=@Email,mobile=@Mobile,attendance=@attendance where studentid=@studentid";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Create a new SQL command
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Add parameters with values from text boxes
                    cmd.Parameters.AddWithValue("@studentid", int.Parse(textBox7.Text));
                    cmd.Parameters.AddWithValue("@studentname", textBox1.Text);
                    cmd.Parameters.AddWithValue("@age", int.Parse(textBox3.Text));
                    cmd.Parameters.AddWithValue("@Dob", DateTime.Parse(textBox6.Text));
                    cmd.Parameters.AddWithValue("@Email", textBox4.Text);
                    cmd.Parameters.AddWithValue("@Mobile", textBox5.Text); // Fixed spelling
                    cmd.Parameters.AddWithValue("@attendance", textBox2.Text);
                    try
                    {
                        // Open the connection
                        con.Open();

                        // Execute the command
                        cmd.ExecuteNonQuery();

                        // Show success message
                        MessageBox.Show("Record Update Successfully", "UPDATE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=studentdb;Integrated Security=True;";

            // Define the SQL query with parameters
            string query = "DELETE info_tad Where studentid=@studentid";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Create a new SQL command
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Add parameters with values from text boxes
                    cmd.Parameters.AddWithValue("@studentid", int.Parse(textBox7.Text));
                  
                    try
                    {
                        // Open the connection
                        con.Open();

                        // Execute the command
                        cmd.ExecuteNonQuery();

                        // Show success message
                        MessageBox.Show("Delete Successfully", "DELETE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
    }
}

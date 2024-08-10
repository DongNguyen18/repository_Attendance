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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DatabaseAttendanceASM2
{
    public partial class Teacher : Form
    {
        public Teacher()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=studentdb;Integrated Security=True;";

            // Define the SQL query with parameters
            string query = "INSERT INTO Teacher_tad VALUES (@id,@name,@age)";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Create a new SQL command
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Add parameters with values from text boxes
                    cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@name", textBox2.Text);
                    cmd.Parameters.AddWithValue("@age", int.Parse(textBox3.Text));

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

        private void Teacher_Load(object sender, EventArgs e)
        {
            String connectionString = @"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=studentdb;Integrated Security=True;";

            // Define your SQL query
            string query = "SELECT * FROM Teacher_tad";

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

        private void button2_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=studentdb;Integrated Security=True;";

            // Define the SQL query with parameters
            string query = "UPDATE Teacher_tad set name=@name,age=@age where id=@id ";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Create a new SQL command
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Add parameters with values from text boxes
                    cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                    cmd.Parameters.AddWithValue("@name", textBox2.Text);
                    cmd.Parameters.AddWithValue("@age", int.Parse(textBox3.Text));

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

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=studentdb;Integrated Security=True;";

            // Define the SQL query with parameters
            string query = "DELETE Teacher_tad where id=@id";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Create a new SQL command
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Add parameters with values from text boxes
                    cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));


                    try
                    {
                        // Open the connection
                        con.Open();

                        // Execute the command
                        cmd.ExecuteNonQuery();

                        // Show success message
                        MessageBox.Show("Record Delete Successfully", "DELETE", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

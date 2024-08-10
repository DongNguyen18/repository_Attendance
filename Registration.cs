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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=ADMIN-PC\SQLEXPRESS;Initial Catalog=studentdb;Integrated Security=True;";

            // Define the SQL query with parameters
            string query = "INSERT INTO regis_tad VALUES (@firstname,@lastname,@email,@password)";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // Create a new SQL command
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Add parameters with values from text boxes
                    
                    cmd.Parameters.AddWithValue("@firstname", textBox1.Text);
                    cmd.Parameters.AddWithValue("@lastname", textBox2.Text);
                    cmd.Parameters.AddWithValue("@email", textBox3.Text);
                    cmd.Parameters.AddWithValue("@password", textBox4.Text); // Fixed spelling

                    try
                    {
                        // Open the connection
                        con.Open();

                        // Execute the command
                        cmd.ExecuteNonQuery();

                        // Show success message
                        MessageBox.Show("Registration Completed", "Comleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }
    }
}

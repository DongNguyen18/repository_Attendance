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
    public partial class Show : Form
    {
        public Show()
        {
            InitializeComponent();          
        }      

        private void Show_Load(object sender, EventArgs e)
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
    }
}

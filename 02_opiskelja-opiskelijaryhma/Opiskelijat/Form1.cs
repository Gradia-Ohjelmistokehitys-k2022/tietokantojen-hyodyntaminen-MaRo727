using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Opiskelijat
{
    public partial class Form1 : Form
    {
        // Replace this with your actual SQL Server connection string
        private string connectionString = "Trusted_Connection=true;" +
                                          "server=(localdb)\\MSSQLLocalDB;" +
                                          "database=OpiskelijatDB;";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            // SQL query to select all records from the Opiskelija table
            string selectQuery = "SELECT id, name, surname, group_id FROM Opiskelija";
            string selectQuery1 = "SELECT name FROM opiskelijaryhmä";

            // Establishing the connection to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // DataAdapter to execute the query and fill the DataSet
                    SqlDataAdapter dataAdapter = new(selectQuery, connection);

                    // DataSet to hold the query result
                    DataSet ds = new DataSet();
                    dataAdapter.Fill(ds); // Filling the DataSet with data from the database

                    // Binding the data to the DataGridView
                    dataGridView1.ReadOnly = true; // Set DataGridView to read-only mode
                    dataGridView1.DataSource = ds.Tables[0]; // Display the first table in the dataset

                    // SQL command to select names from the opiskelijaryhmä table
                    SqlCommand cmd = new(selectQuery1, connection);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cmbRyhmat.Items.Add(reader.GetString(0));
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message); // Handle any errors gracefully
                }
            }
        }

        private void addToDb_Click_1(object sender, EventArgs e)
        {
            string firstName = firstNameInput.Text;
            string lastName = lastNameInput.Text;
            int groupid = cmbRyhmat.SelectedIndex + 1;
            string insertQuery = "INSERT INTO Opiskelija (name, surname, group_id) VALUES (@name, @surname, @group_id)";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", firstName);
                        cmd.Parameters.AddWithValue("@surname", lastName);
                        cmd.Parameters.AddWithValue("@group_id", groupid);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Record added successfully!");
                LoadData(); // Refresh the DataGridView to show the newly added record
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Insert Error: " + ex.Message);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var selectedId = dataGridView1.SelectedRows[0].Cells[0].Value;
            string deleteQuery = "DELETE FROM Opiskelija where id = @id";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand del = new SqlCommand(deleteQuery, conn))
                    {
                        del.Parameters.AddWithValue("@id", selectedId);
                        del.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Successfully deleted row!");
                LoadData(); // Refresh the DataGridView to show the newly added record
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Insert Error: " + ex.Message);
            }
           
        }
    }
}

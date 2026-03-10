using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class New_Order : Form
    {
        public New_Order()
        {
            InitializeComponent();


            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-JC34F7J\\MSSQLSERVER01;Initial Catalog=products;Integrated Security=True;Encrypt=False");
            try
            {
                
                conn.Open();

                string query = "SELECT Pname FROM P_table";
                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    pname.Items.Add(reader["Pname"].ToString());
                }

                reader.Close();
            }
            catch 
            {
             
                MessageBox.Show("Error: " );
            }
            finally
            {
                conn.Close();
            }
        }

        private void pname_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProductName = pname.SelectedItem.ToString();

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-JC34F7J\\MSSQLSERVER01;Initial Catalog=products;Integrated Security=True;Encrypt=False");
            try
            {
                conn.Open();

                string query = "SELECT Price FROM P_table WHERE Pname = @Pname";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Pname", selectedProductName);

                object result = cmd.ExecuteScalar();
                if (result != null)
                {
                    price1.Text = result.ToString();
                }
                else
                {
                    price1.Text = "Price not found";
                }
            }
            catch 
            {
                MessageBox.Show("Error: ");
            }
            finally
            {
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string CDe = cus.Text;
            string PName = pname.Text;
            int price = int.Parse(price1.Text);
            string oid = oid1.Text;
            int quantity = int.Parse(qty.Text);
            int tot =quantity*price;

            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-JC34F7J\\MSSQLSERVER01;Initial Catalog=products;Integrated Security=True;Encrypt=False");
            conn.Open();
            string insertQuery = "INSERT INTO [Order] (OID, Details, Name, Price, Qty, Total) VALUES (@OID, @Details, @Name, @Price, @Qty, @Total)";
            SqlCommand com = new SqlCommand(insertQuery, conn);

            com.Parameters.AddWithValue("@OID", oid);
            com.Parameters.AddWithValue("@Details", CDe);
            com.Parameters.AddWithValue("@Name", PName);
            com.Parameters.AddWithValue("@Price", price);
            com.Parameters.AddWithValue("@Qty", quantity);
            com.Parameters.AddWithValue("@Total", tot);

            try
            {
                com.ExecuteNonQuery();
                MessageBox.Show("Order added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding order: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            

            LoadDataIntoDataGridView();
            DisplayTotalSum();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          


        }


        private void LoadDataIntoDataGridView()
        {
            string connectionString = "Data Source=DESKTOP-JC34F7J\\MSSQLSERVER01;Initial Catalog=products;Integrated Security=True;Encrypt=False";

            using (SqlConnection conn = new SqlConnection(connectionString))

            {
                conn.Open();

                string query = "SELECT Name, Price, Qty, Total FROM [Order] where OID = ( SELECT MAX(OID) FROM  [Order] )";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
                conn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void DisplayTotalSum()
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-JC34F7J\\MSSQLSERVER01;Initial Catalog=products;Integrated Security=True;Encrypt=False"))
            {
                con.Open();

               
                string query = "SELECT SUM(Total) FROM [Order]";
                SqlCommand cmd = new SqlCommand(query, con);

                object result = cmd.ExecuteScalar();

              
                totbill.Text = result != DBNull.Value ? result.ToString() : "0";
            }
        }

        private void New_Order_Load(object sender, EventArgs e)
        {

        }
    }
    
}

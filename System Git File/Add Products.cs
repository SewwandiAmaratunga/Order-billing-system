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


namespace WindowsFormsApp4
{
    public partial class Add_Products : Form
    {
        public Add_Products()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-JC34F7J\\MSSQLSERVER01;Initial Catalog=products;Integrated Security=True;Encrypt=False");





        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                string sql = "INSERT INTO P_table (PID, Pname, Price) VALUES (@PID, @Pname, @Price)";
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@PID", pid.Text);
                    cmd.Parameters.AddWithValue("@Pname", pname.Text);
                    cmd.Parameters.AddWithValue("@Price", int.Parse(pprice.Text));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product added successfully!");
                }
            }
            catch 
            {
                MessageBox.Show("Error " );
            }


        }

        private void Add_Products_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pid.Clear();
            pname.Clear();
            pprice.Clear();
        }

        private void pid_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Products add_Products = new Add_Products();
            add_Products.Show();
        }

        private void newOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            New_Order new_Order = new New_Order();
            new_Order.Show();
        }
    }
}

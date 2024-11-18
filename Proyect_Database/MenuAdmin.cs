using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyect_Database
{
    public partial class MenuAdmin : Form
    {
        public MenuAdmin()
        {
            InitializeComponent();
        }

        private void tablaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Form1 re = new Form1();
                re.Show();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void consultaSQLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Query re = new Query();
                re.Show();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

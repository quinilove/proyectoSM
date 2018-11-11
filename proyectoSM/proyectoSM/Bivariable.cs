using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proyectoSM
{
    public partial class Bivariable : Form
    {
        public Bivariable()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BivariableP BIP = new BivariableP();

            BIP.Show();
        }
    }
}

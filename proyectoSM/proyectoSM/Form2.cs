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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int i;
            int suma1 = 0;
            int suma2 = 0;
            double promedio1;
            double promedio2;
            int[] numerico1 ={ 10,11,12,13,14,15};
            int[] numerico2 ={ 13,14,15,16,17,18};

            for (i = 0; i < numerico1.Length; i++)
            {
                suma1 = suma1 + numerico1[i];
            }
            promedio1 = suma1 / numerico1.Length;
            for (i = 0; i < numerico2.Length; i++)
            {
                suma2 = suma2 + numerico2[i];
            }
            promedio2 = suma2 / numerico2.Length;
            Console.WriteLine("la suma1 es igual a {0}", suma1);
            Console.WriteLine("el primedio1 es igual a {0}", promedio1);
            Console.WriteLine("la suma2 es igual a {0}", suma2);
            Console.WriteLine("el primedio2 es igual a {0}", promedio2);
            Console.ReadLine();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

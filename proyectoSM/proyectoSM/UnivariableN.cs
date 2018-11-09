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
    public partial class UnivariableN : Form
    {
        public UnivariableN()
        {
            InitializeComponent();
        }

        private void UnivariableN_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            int suma = 0;
            double promedio;
            int[] numerico = { 10, 11, 12, 13, 14, 15 };


            for (i = 0; i < numerico.Length; i++)
            {
                suma = suma + numerico[i];
            }
            promedio = suma / numerico.Length;
           
            label3.Text = "La media es: "+ promedio.ToString();


        }

        private void label3_Click(object sender, EventArgs e)
        {
   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] numerico = { 10, 11, 20, 13, 14, 15, 21 };
            Array.Sort(numerico);

            Console.WriteLine("\nLos números ordenados son:");
/*/
            for (int i = 0; i < numerico.Length; i++)
            {
                Console.WriteLine(numerico[i]);
            }
            /*/
 
            label3.Text = "La mediana es: " + numerico[numerico.Length / 2];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[] x = new int[] { 4, 1, 2, 1, 2, 4, 3, 2, 4, 4 };

            Dictionary<int, int> counts = new Dictionary<int, int>();
            foreach (int a in x)
            {
                if (counts.ContainsKey(a))
                    counts[a] = counts[a] + 1;
                else
                    counts[a] = 1;
            }

            int result = int.MinValue;
            int max = int.MinValue;
            foreach (int key in counts.Keys)
            {
                if (counts[key] > max)
                {
                    max = counts[key];
                    result = key;
                }
            }

            label3.Text = "La moda es: " + result.ToString();

        }
    }
}

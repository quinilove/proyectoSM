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
        double MedianaFinal ;
        int Maximo, Minimo,Q1, Q3;
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
            int[] numerico = { 10, 11, 20, 13, 14, 15, 21 };


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

        public void button2_Click(object sender, EventArgs e)
        {
            int[] numerico = { 10, 11, 20, 13, 14, 15, 21,39 };
            //double Q1T, Q3T;
            Array.Sort(numerico);
            Maximo = numerico[numerico.Length-1];
            Minimo = numerico[0];
            double Q1T, Q3T;
            Q1T = numerico.Length / 4;
            Q3T = (Q1T * 3);
            int i1 = Convert.ToInt32(Q1T);
            int i2 = (int)Q1T;
            int i3 = Convert.ToInt32(Q3T);
            int i4 = (int)Q3T;
            Q1 = numerico[i2];
            Q3 = numerico[i4];
            
            //double score = 8.6;
            //int i1 = Convert.ToInt32(score);
            //int i2 = (int)score;
            /*/
            Console.WriteLine("{ 10, 11, 20, 13, 14, 15, 21 };\nLos números ordenados son:");
/*/
            for (int i = 0; i < numerico.Length; i++)
            {
                Console.WriteLine(numerico[i]);
            }
           
 
            label3.Text = "La mediana es: " + numerico[numerico.Length / 2];
            MedianaFinal = numerico[numerico.Length / 2];
            label4.Text = "MAX: " + Maximo;
            label5.Text = "MIN: " + Minimo;
            label6.Text = "Q1: " + Q1;
            label7.Text = "Q3: " + Q3;
            label8.Text = "Mediana: " + MedianaFinal;
            button5.Enabled = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int[] x = new int[] { 10, 11, 20, 13, 14, 15, 21 };

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

        private void button4_Click(object sender, EventArgs e)
        {


            int datos_m = 0;
            int[] listBox1 = { 10, 11, 20, 13, 14, 15, 21 };
            //calcular media
            for (int i = 0; i < listBox1.Length; ++i)
            {
                datos_m += Convert.ToInt32(listBox1[i].ToString());
            }
            var tamano_muestra = listBox1.Length;
            var media = datos_m / tamano_muestra;
           // MessageBox.Show("" + media);
            //calcular varianza
            double datos_v = 0;
            for (int i = 0; i < listBox1.Length; ++i)
            {
                //conversion explicita a double para emplear el metodo pow
                datos_v += Math.Pow((Convert.ToDouble(listBox1[i].ToString()) - Convert.ToDouble(media)), 2); ;
            }
            var total_varianza = datos_v / (listBox1.Length - 1);
           // MessageBox.Show("Desviacion estandar: " + Math.Sqrt(total_varianza));
            label3.Text = "Desviacion estandar: " + Math.Sqrt(total_varianza);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            boxPlot frm6 = new boxPlot(Maximo,Minimo, Q1, Q3, MedianaFinal);
            

            frm6.Show();
        }
    }
}

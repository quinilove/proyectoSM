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
    public partial class UnivariableC2 : Form
    {
        public UnivariableC2()
        {
            InitializeComponent();
        }

        private void UnivariableC2_Load(object sender, EventArgs e)
        {
            //Console.WriteLine("Ingrese una frase: ");
            //String texto = Console.ReadLine();
            String[] palabras = { "hola", "mundo", "cruel", "hola", "mundo", "feliz" };
            String[] palabras2 = new string[palabras.Length];
            //texto.Split(" ");
            string[] fila = new string[2];
            int[] nro_repeticion_palabra = new int[palabras.Length];
            DataTable myData = new DataTable();
            int i = 0;
            int j = 0;
            myData.Columns.Add("Palabra");
            myData.Columns.Add("Cantidad");


            for (i = 0; i < palabras.Length; i++)
            {
                for (j = 0; j < palabras.Length; j++)
                {
                    if (palabras[i].CompareTo(palabras[j]) == 0)
                    {
                        nro_repeticion_palabra[i]++;
                        palabras2[i] = palabras[i];
                        //  palabras2 = palabras2.Where(palabras[j] != palabras[i])
                        //.Where(i => i != 4).ToArray();
                    }
                }
            }
            for (i = 0; i < palabras.Length; i++)
            {
                for (j = 0; j < palabras.Length; j++)
                {
                    if (palabras[i].CompareTo(palabras[j]) == 0)
                    {
                        fila[0] = palabras[i];
                        fila[1] = nro_repeticion_palabra[i].ToString();
                        int i1 = Convert.ToInt32(fila[1]);
                        int i2 = (int)i1;
                        //necesito comparar que los datos nuevos esten o no en la fila antes de ingresarlos.
                        if (i2 == 2)
                        {
                            if(palabras[i].ToString() == fila[0])
                            {
                                palabras[i] = palabras[i].Remove(i);
                            }
                            //palabras[i] = palabras[i].Remove(i);
                            myData.Rows.Add(fila);
                        }
                        else
                        {
                            myData.Rows.Add(fila);
                        }

                    }

                }
            }

            dataGridView1.DataSource = myData;
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}



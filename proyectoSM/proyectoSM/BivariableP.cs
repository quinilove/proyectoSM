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
    public partial class BivariableP : Form
    {
        public BivariableP()
        {
            InitializeComponent();
        }

        private void lbPromA_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] ArregloA = new int[] { 83, 64, 72, 81, 70, 68, 65, 75, 71, 85, 80, 72, 69, 75 };
            int[] ArregloB = new int[] { 86, 65, 90, 75, 96, 80, 70, 80, 91, 85, 90, 95, 70, 70 };
            double PromedioA = 0.0;
            double PromedioB = 0.0;
            double sumatoriaA = 0.0;
            double sumatoriaB = 0.0;
            double tempp = 0.0;
            double tempq = 0.0;
            double tempA = 0.0;
            double tempB = 0.0;

            double tempA2 = 0.0;
            double tempB2 = 0.0;
            double sumatoriaA2 = 0.0;
            double sumatoriaB2 = 0.0;

            double MultiSumAB = 0.0;
            int tamanioA = ArregloA.Length;
            int tamanioB = ArregloB.Length;

            double divisionOA = 0.0;
            double divisionOB = 0.0;
            double OA = 0.0;
            double OB = 0.0;
            double RAB = 0.0;
            double TOAB = 0.0;

            // Calculo de Promedios A y B

            for (int p = 0; p < tamanioA; p++)
            {
                tempp = ArregloA[p];
                PromedioA = PromedioA + tempp;
            }

            for (int q = 0; q < tamanioB; q++)
            {
                tempq = ArregloB[q];
                PromedioB = PromedioB + tempq;
            }

            PromedioA = PromedioA / (tamanioA);
            PromedioB = PromedioB / (tamanioB);

            lbPromA.Text = "Promedio A: " + PromedioA.ToString();
            lbPromB.Text = "Promedio B: " + PromedioB.ToString();

            // Sumatoria menos promedio de A y B multiplicadas


            for (int i = 0; i < tamanioA; i++)
            {
                tempA = ArregloA[i] - PromedioA;
                tempB = ArregloB[i] - PromedioB;
                sumatoriaA = sumatoriaA + (tempA * tempB);
            }

            lbSumAB.Text = "Sumatoria A*B Total: " + sumatoriaA;


            MultiSumAB = sumatoriaA; //Parte de arriba del calculo de Pearson


            //***********************INICIO OA y OB*************************

            // Sumatoria menos promedio de A y B al cuadrado

            for (int i = 0; i < tamanioA; i++)
            {
                tempA2 = ArregloA[i] - PromedioA;
                tempA2 = tempA2 * tempA2;
                sumatoriaA2 = sumatoriaA2 + tempA2;
            }

            for (int j = 0; j < tamanioA; j++)
            {
                tempB2 = ArregloB[j] - PromedioB;
                tempB2 = tempB2 * tempB2;
                sumatoriaB2 = sumatoriaB2 + tempB2;
            }

            lbSumA2.Text = "Sumatoria A2: " + sumatoriaA2.ToString();
            lbSumB2.Text = "Sumatoria B2: " + sumatoriaB2.ToString();

            // División pre-raiz de A y B

            divisionOA = sumatoriaA2 / tamanioA;
            divisionOB = sumatoriaB2 / tamanioB;

            lbDivOA.Text = "Div. OA: " + divisionOA;
            lbDivOB.Text = "Div. OB: " + divisionOB;

            // Raiz final, terminación de OA y OB

            OA = Math.Sqrt(divisionOA);
            OB = Math.Sqrt(divisionOB);

            lbRaizOA.Text = "OA: " + OA;
            lbRaizOB.Text = "OB: " + OB;

            //***************************CALCULO FINAL PEARSON******************************

            // Calculo RAB

            TOAB = ((tamanioA + 1) * (OA * OB));

            RAB = MultiSumAB / TOAB;

            lbTOAB.Text = "N*OA*OB: " + TOAB.ToString();
            lbRAB.Text = "RAB: " + RAB.ToString();
        }
    }
}

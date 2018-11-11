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
    public partial class boxPlot : Form
    {
        public boxPlot(int Max, int Min, double Q1, double Q3, double Media)
        {
            InitializeComponent();
chart1.Series["Representacion BoxPlot"].Points.AddXY(0, Max, Min, Q1, Q3, Media);



            // Specify data series name for the Box Plot.
            chart1.Series["Representacion BoxPlot"]["Representacion BoxPlot"] = "DataSeries";

            // Set other custom attributes

            chart1.Series["Representacion BoxPlot"]["BoxPlotShowAverage"] = "true";
            chart1.Series["Representacion BoxPlot"]["BoxPlotShowMedian"] = "true";
            chart1.Series["Representacion BoxPlot"]["BoxPlotShowUnusualValues"] = "true";
        }

        private void boxPlot_Load(object sender, EventArgs e)
        {

        }
    }
}

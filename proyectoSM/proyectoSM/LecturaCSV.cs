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
    public partial class LecturaCSV : Form
    {
        private bool dataHasBeenFound;
        private char missingValueCharacter;
        DataTable myDataTable = new DataTable();
        List<Attribute> foundAttributes = new List<Attribute>();

        public LecturaCSV()
        {
            InitializeComponent();
            dataHasBeenFound = false;
            missingValueCharacter = '?'; ///Set default value for missing value in document.
        }

        public LecturaCSV(List<Attribute> newAttributes, DataTable newDataTable)
        {
            InitializeComponent();
            foundAttributes = newAttributes;
            CSVDataGridView.DataSource = newDataTable;
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            if (openCSVFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //openCSVFileDialog.ShowDialog();

                FilePathTextBox.Text = openCSVFileDialog.FileName;
                CargarDatosDeCSV(openCSVFileDialog.FileName);
            }
        }

        private void CargarDatosDeCSV(string filePath)
        {

            string[] lineas = System.IO.File.ReadAllLines(filePath);


            for (int i = 0; i < lineas.Length; i++)
            {
                //DataRow newRow = myDataTable.NewRow();
                ParseLine(lineas[i]);
                //CSVDataGridView.Rows.Add(lineas[i]);
            }

            CSVDataGridView.DataSource = myDataTable;
        }

       

        private void ParseLine(string line)
        {
            string[] tempArray;


            if (line[0] == '%' && line[1] == '%')
            {
                line = line.Substring(2);
                CommentsListBox.Items.Add(line);
            }
            else if (line[0] == '@')
            {
                line = line.Substring(1);

                tempArray = line.Split(' ');

                if (tempArray[0] == "relation")
                {
                    RelationNameTextBox.Text += tempArray[1];
                }
                else if (tempArray[0] == "attribute")
                {
                    myDataTable.Columns.Add(new DataColumn(tempArray[1]));
                    if (tempArray[2] == "nominal")
                    {
                        ///If we arrive here, it means we have a messs starting tempArray[3] 
                        ///Example: (tourist | first class)
                        ///Notice how splitting by blank spaces does not work anymore.
                        foundAttributes.Add(new Attribute(tempArray[1], tempArray[2], NominalOptions(line)));
                    }
                    else if (tempArray[2] == "numeric")
                    {
                        foundAttributes.Add(new Attribute(tempArray[1], tempArray[2], tempArray[3]));
                    }


                    CommentsListBox.Items.Add(foundAttributes[foundAttributes.Count - 1].PrintAttribute());

                }
                else if (tempArray[0] == "missingValue")
                {
                    missingValueCharacter = tempArray[1][0];
                }
                else if (tempArray[0] == "data")
                {
                    dataHasBeenFound = true;
                }
                else
                {
                    ///Error
                }

            }
            else if (dataHasBeenFound)
            {
                tempArray = line.Split(',');
                myDataTable.Rows.Add(tempArray);


            }
            else
            {
                ///Error
            }
        }

        private string[] NominalOptions(string line)
        {
            ///Example of recieved line:
            ///attribute type nominal (tourist | first class)
            ///<summary>
            ///Find parenthesis to start extracting a nominal attribute option, stop when '|' is found.
            ///If space behind '|' delete, then start looking for new option after '|'. Repeat.
            ///Or stop if ')' is found.
            /// </summary>

            int parenthesisIndex = 0;
            string tempString;
            
            for(int i = 0; i < line.Length; i++)
            {
                if(line[i] == '(')
                {
                    parenthesisIndex = i;
                }
            }

            tempString = line.Substring(parenthesisIndex + 1);
            tempString = tempString.Remove(tempString.Length-1);

            return tempString.Split('|');

        }

        private void CSVDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

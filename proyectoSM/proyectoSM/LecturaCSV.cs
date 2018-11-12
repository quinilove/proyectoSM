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
        private string relationName;
        DataTable myDataTable = new DataTable();
        List<Attribute> foundAttributes = new List<Attribute>();

        public LecturaCSV()
        {
            InitializeComponent();
            dataHasBeenFound = false;
            missingValueCharacter = '?'; ///Set default value for missing value in document.
        }

        public LecturaCSV(List<Attribute> newAttributes, DataTable newDataTable, string newRelationName, char newMissingCharValue)
        {
            InitializeComponent();
            foundAttributes = newAttributes;
            CSVDataGridView.DataSource = newDataTable;
            myDataTable = newDataTable;
            relationName = newRelationName;
            missingValueCharacter = newMissingCharValue;
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

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '(')
                {
                    parenthesisIndex = i;
                }
            }

            tempString = line.Substring(parenthesisIndex + 1);
            tempString = tempString.Remove(tempString.Length - 1);

            return tempString.Split('|');

        }

        private void CSVDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private string[] ReturnAttributeInstancesByName(string attributeName)
        {
            int attributeIndex = 0;
            string[] instances = new string[myDataTable.Rows.Count];
            
            for (int i = 0; i < foundAttributes.Count; i++)
            {
                if(foundAttributes[i].name == attributeName)
                {
                    attributeIndex = i;
                    break;
                }
            }
            Console.WriteLine("Nada de nada " + attributeIndex + ", instancias:" + instances.Length + ", " + myDataTable.Rows.Count);
            for (int i = 0; i < instances.Length; i++)
            {
                instances[i] = myDataTable.Rows[i].Field<string>(attributeIndex);
                Console.WriteLine(instances[i]);
                //.Cells[attributeName].Value.ToString();
            }


            return instances;
        }

        private void UpdateDataTable()
        {
            myDataTable.Clear();
            foreach (DataGridViewColumn col in CSVDataGridView.Columns)
            {
                myDataTable.Columns.Add(col.Name);
            }

            foreach (DataGridViewRow row in CSVDataGridView.Rows)
            {
                DataRow dRow = myDataTable.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                myDataTable.Rows.Add(dRow);
            }
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            // Displays a SaveFileDialog so the user can save the Image  
            // assigned to Button2.  
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "CSV File|*.CSV";
            saveFileDialog1.Title = "Guardar tabla a archivo .CSV";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            UpdateDataTable();
            
           

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                System.IO.StreamWriter myStream = new System.IO.StreamWriter(saveFileDialog1.OpenFile());

                if (myStream != null)
                {

                    // Code to write the stream goes here.
                    myStream.WriteLine("@relation " + relationName);
                    for(int i = 0; i < foundAttributes.Count; i++)
                    {
                        myStream.WriteLine(foundAttributes[i].PrintAttribute());
                    }
                    myStream.WriteLine("@missingValue " + missingValueCharacter);
                    myStream.WriteLine("@data");

                    string currentLine = "";
                    for (int i = 0; i < CSVDataGridView.Rows.Count-1; i++)
                    {
                        for(int j = 0; j < CSVDataGridView.Columns.Count; j++)
                        {
                                currentLine += CSVDataGridView.Rows[i].Cells[j].Value.ToString() + ",";
                            
                        }
                        currentLine = currentLine.Substring(0, currentLine.Length - 1);
                        myStream.WriteLine(currentLine);

                        currentLine = "";
                    }
                    myStream.Dispose();
                    myStream.Close();
                }
                
            }


        }

        private void LecturaCSV_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateDataTable();

            Menu newMenu = new Menu(foundAttributes, myDataTable);

            newMenu.Show();
        }
    }
}

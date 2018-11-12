using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
namespace proyectoSM
{
    public partial class InitialForm : Form
    {
        DataTable myDataTable = new DataTable();
        private int attributesQuantity = 0;
        private bool relationNameFound = false;
        private string relationName;
        private bool dataHasBeenFound = false;
        private bool missingValueHasBeenFound = false;
        private char missingValueChar = '?';
        private List<Attribute> foundAttributes = new List<Attribute>();
        private string filename;

        public InitialForm()
        {
            InitializeComponent();
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            if (OpenCSVFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //openCSVFileDialog.ShowDialog();
                filename = OpenCSVFileDialog.FileName;
                string format = filename.Substring(filename.Length - 4);

                if (format != ".csv")
                {
                    ErrorMessageBox("Por favor seleccione un archivo .csv", "Error, formato incorrecto", false);
                }
                else
                {
                    FilePathTextBox.Text = filename;
                    CargarDatosDeCSV(filename);
                }


            }
        }

        private void CargarDatosDeCSV(string filePath)
        {

            

            CreateRelationTagIfMissing(filePath, "@relation");
            CreateAttributeTagIfMissing(filePath, "@attribute");
            CreateMissingSymbolIfMissing(filePath, "@missingValue");
            CreateDataTagIfMissing(filePath, "@data");

            string[] lineas = System.IO.File.ReadAllLines(filePath);

            for (int i = 0; i < lineas.Length; i++)
            {
                //DataRow newRow = myDataTable.NewRow();
                ParseLine(lineas[i]);              
                //CSVDataGridView.Rows.Add(lineas[i]);
            }
            LecturaCSV testDialog = new LecturaCSV(foundAttributes, myDataTable,relationName,missingValueChar);

            testDialog.Show();
            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            /*if (testDialog.ShowDialog(this) == DialogResult.OK)
            {
                // Read the contents of testDialog's TextBox.
                missingValueChar = testDialog.MissingValue;
                AddLineAfterTag(tag + " " + missingValueChar, "@attribute");
            }
            else
            {
                ErrorMessageBox("Error al momento de asignar valor faltante", "Error", true);
            }

            testDialog.Dispose();*/
            ///CSVDataGridView.DataSource = myDataTable;
            ///Probably send everything to the constructor
        }

        private void ParseLine(string line)
        {
            string[] tempArray;
            if(String.IsNullOrEmpty(line))
            {

            }
            else if (line[0] == '%' && line[1] == '%')
            {
                line = line.Substring(2);
                //CommentsListBox.Items.Add(line);
            }
            else if (line[0] == '@')
            {
                line = line.Substring(1);

                tempArray = line.Split(' ');

                if (tempArray[0] == "relation")
                {
                    if(relationNameFound)
                    {
                        ErrorMessageBox("Se encontro mas de un nombre para la relación.", "Error al procesar archivo", true);
                    }
                    else
                    {
                        relationName = tempArray[1];
                        relationNameFound = true;
                    }

                }
                else if (tempArray[0] == "attribute")
                {
                    attributesQuantity++;
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


                    //CommentsListBox.Items.Add(foundAttributes[foundAttributes.Count - 1].PrintAttribute());

                }
                else if (tempArray[0] == "missingValue")
                {
                    missingValueHasBeenFound = true;
                   missingValueChar = tempArray[1][0];
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
                if(foundAttributes[0].name == tempArray[0])
                {
                    //If they're the same, it means our first line is attribute names.
                }
                else
                {
                    myDataTable.Rows.Add(tempArray);
                }


            }
            else if(!dataHasBeenFound)
            {
                ///Generar tag @data
                AddLineAfterTag("@data", "@attribute");
                dataHasBeenFound = true;
                /*if()
                {

                }*/
                tempArray = line.Split(',');
                ErrorMessageBox("Se encontraron " + tempArray.Length.ToString() + " atributos no registrados en tu linea", "Error", true);
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

        private void ErrorMessageBox(string message, string caption, bool closeParent)
        {
            // Initializes the variables to pass to the MessageBox.Show method.

            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            // Displays the MessageBox.

            result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Exclamation);
            
            if (closeParent && (result == System.Windows.Forms.DialogResult.OK))
            {
                // Closes the parent form.

                this.Close();
            }

        }

        private void AddLineToTheBeginningOfFile(string newContent)
        {
            string currentContent = String.Empty;
            if (System.IO.File.Exists(filename))
            {
                currentContent = System.IO.File.ReadAllText(filename);
            }
            System.IO.File.WriteAllText(filename, newContent + System.Environment.NewLine + currentContent);
        }
        
        private void AddLineAfterTag(string newContent, string tag)
        {
            bool foundTag = false;
            if (System.IO.File.Exists(filename))
            {
                string[] currentContent = System.IO.File.ReadAllLines(filename);
                Console.WriteLine("Lenght: " + currentContent.Length);
                string[] allLines = new string[currentContent.Length + 1];
                string currentLine;
                string[] split;
                int lastFoundIndex = 0;
                for (int i = 0; i < currentContent.Length; i++)
                {
                    currentLine = currentContent[i];
                    split = currentLine.Split(' ');

                    if (split[0] == tag)
                    {
                        lastFoundIndex = i;
                        foundTag = true;
                    }
                }

                Console.WriteLine("Found Index: " + lastFoundIndex);

                if (!foundTag)
                {
                    ErrorMessageBox("Error al generar archivo.", "Error", true);
                }
                else
                {
                    int j = 0;
                    for (int i = 0; i < allLines.Length; i++)
                    {
                        allLines[i] = currentContent[j];
                        if (i == lastFoundIndex)
                        {
                            i++;
                            allLines[i] = newContent;      
                        }
                        j++;
                    }
                }
                Console.WriteLine(filename);
                //colocar
                System.IO.File.WriteAllLines(filename,allLines);
            }

        }

        private void CreateRelationTagIfMissing(string filePath ,string tag)
        {
            tag = "@relation";

            string[] lineas = System.IO.File.ReadAllLines(filePath);
            string[] currentLine;
            bool tagFound = false;
            int foundTags = 0;

            for (int i = 0; i < lineas.Length; i++)
            {
                currentLine = lineas[i].Split(' ');

                if(tagFound && (foundTags > 1))
                {
                    ErrorMessageBox("Se encontraron varios nombres de relación", "Error", true);
                }
                else if(currentLine[0] == tag)
                {
                    tagFound = true;
                    foundTags++;
                }

            }

            if(!tagFound)
            {
                SimpleInput testDialog = new SimpleInput();

                // Show testDialog as a modal dialog and determine if DialogResult = OK.
                if (testDialog.ShowDialog(this) == DialogResult.OK)
                {
                    // Read the contents of testDialog's TextBox.
                    relationName = testDialog.TextBoxValue;
                    AddLineToTheBeginningOfFile(tag + " " + relationName);
                }
                else
                {
                    ErrorMessageBox("Error al momento de asignar nombre de relación", "Error", true);
                }

                testDialog.Dispose();
            }

        }

        private void CreateAttributeTagIfMissing(string filePath, string tag)
        {
            tag = "@attribute";
            //tag = "@data";
            string[] lineas = System.IO.File.ReadAllLines(filePath);
            string[] currentLine;
            bool tagFound = false;
            int foundTags = 0;

            for (int i = 0; i < lineas.Length; i++)
            {
                currentLine = lineas[i].Split(' ');
                if(currentLine[0] == tag)
                {
                    tagFound = true;
                    foundTags++;
                }
            }

            if (!tagFound)
            {
                // Initializes the variables to pass to the MessageBox.Show method.

                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show("No se encontraron nombres de atributos, ¿La primera linea corresponde al nombre de estos?"
                                         , "Seleccione una opción", buttons, MessageBoxIcon.Question);

                if ((result == System.Windows.Forms.DialogResult.Yes))
                {
                    int index = LookForBeginningOfData(filePath);
                    if(index == -1)
                    {
                        ErrorMessageBox("Error al momento de generar atributo", "Error", true);
                    }
                    
                    currentLine = lineas[index].Split(',');
                    for (int j = 0; j < currentLine.Length; j++)
                    {
                        
                        AddAttribute testDialog = new AddAttribute(currentLine[j], filePath, j);

                        // Show testDialog as a modal dialog and determine if DialogResult = OK.
                        if (testDialog.ShowDialog(this) == DialogResult.OK)
                         {
                            foundAttributes.Add(testDialog.resultAttribute);
                            Console.WriteLine(foundAttributes[foundAttributes.Count - 1].PrintAttribute());
                        }
                        else
                        {
                            ErrorMessageBox("Error al momento de generar atributo", "Error", true);
                        }

                        testDialog.Dispose();
                    }
                }
                else
                {
                    int index = LookForBeginningOfData(filePath);
                    if (index == -1)
                    {
                        ErrorMessageBox("Error al momento de generar atributo", "Error", true);
                    }

                    currentLine = lineas[index].Split(',');
                    for (int j = 0; j < currentLine.Length; j++)
                    {

                        AddAttribute testDialog = new AddAttribute("", filePath, j);

                        // Show testDialog as a modal dialog and determine if DialogResult = OK.
                        if (testDialog.ShowDialog(this) == DialogResult.OK)
                        {
                            foundAttributes.Add(testDialog.resultAttribute);
                            Console.WriteLine(foundAttributes[foundAttributes.Count - 1].PrintAttribute());
                        }
                        else
                        {
                            ErrorMessageBox("Error al momento de generar atributo", "Error", true);
                        }

                        testDialog.Dispose();
                    }
                }

                for(int i = 0; i < foundAttributes.Count;i++)
                {
                    if(i == 0)
                    {
                        Console.WriteLine("Se añade: " + foundAttributes[i].PrintAttribute() + " al final del @relation"); 
                        AddLineAfterTag(foundAttributes[i].PrintAttribute(),"@relation");
                    }
                    else
                    {
                        Console.WriteLine("Se añade: " + foundAttributes[i].PrintAttribute() + " al final del @attribute");
                        AddLineAfterTag(foundAttributes[i].PrintAttribute(), "@attribute");

                    }
                    
                }

            }
            else if (tagFound)
            {

                //verificar si la cantidad de etiquetas que existen es inferior, si es el caso no hacer nada
                //de lo contrario generar etiqueta
                //currentLine = lineas.Split(',');
                Console.WriteLine(foundTags);


            }
         
        }

        private void CreateDataTagIfMissing(string filePath, string tag)
        {
            //tag = "@attribute";
            tag = "@data";

            string[] lineas = System.IO.File.ReadAllLines(filePath);
            string[] currentLine;
            bool tagFound = false;
            int foundTags = 0;

            for (int i = 0; i < lineas.Length; i++)
            {
                currentLine = lineas[i].Split(' ');

                if (tagFound && (foundTags > 1))
                {
                    ErrorMessageBox("Se encontraron varios inicios de datos", "Error", true);
                }
                else if (currentLine[0] == tag)
                {
                    tagFound = true;
                    foundTags++;
                }

            }

            if (!tagFound)
            {
                AddLineAfterTag(tag, "@missingValue");
            }
        }

        private void CreateMissingSymbolIfMissing(string filePath, string tag)
        {
            tag = "@missingValue";

            string[] lineas = System.IO.File.ReadAllLines(filePath);
            string[] currentLine;
            bool tagFound = false;
            int foundTags = 0;

            for (int i = 0; i < lineas.Length; i++)
            {
                currentLine = lineas[i].Split(' ');

                if (tagFound && (foundTags > 1))
                {
                    ErrorMessageBox("Se encontraron varios nombres de relación", "Error", true);
                }
                else if (currentLine[0] == tag)
                {
                    tagFound = true;
                    foundTags++;
                }

            }

            if (!tagFound)
            {
                AddMissingSymbol testDialog = new AddMissingSymbol();

                // Show testDialog as a modal dialog and determine if DialogResult = OK.
                if (testDialog.ShowDialog(this) == DialogResult.OK)
                {
                    // Read the contents of testDialog's TextBox.
                    missingValueChar = testDialog.MissingValue;
                    AddLineAfterTag(tag +" " + missingValueChar, "@attribute");
                }
                else
                {
                    ErrorMessageBox("Error al momento de asignar valor faltante", "Error", true);
                }

                testDialog.Dispose();
            }

        }

        private int LookForBeginningOfData(string filePath)
        {
            //Returns index of found data beginning in file
            string[] lineas = System.IO.File.ReadAllLines(filePath);
            for (int i = 0; i < lineas.Length; i++)
            {
                if((lineas[i][0] != '@' ) && (lineas[i][0] != '%'))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}

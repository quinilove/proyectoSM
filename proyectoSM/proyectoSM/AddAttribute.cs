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
    public partial class AddAttribute : Form
    {

        private int currentIndex;
        private string filePath;
        public Attribute resultAttribute;

        public AddAttribute(string attributeName, string fileName, int newCurrentIndex)
        {
            InitializeComponent();
            if (attributeName.Length >= 1)
            {
                NameTextBox.Text = attributeName;
                NameTextBox.Enabled = false;
            }
            else
            {
                NameTextBox.Enabled = true;
            }
            currentIndex = newCurrentIndex;
            filePath = fileName;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            if (NameTextBox.Text.Contains(" ") || (NameTextBox.Text.Length < 1))
            {
                ErrorMessageBox("Nombre de atributo invalido, intenta de nuevo.", "Error", false);
                if (!NameTextBox.Enabled)
                {
                    NameTextBox.Enabled = true;
                }
            }
            else if (TypeComboBox.GetItemText(TypeComboBox.SelectedItem) == "nominal")
            {
                if (NominalListBox.Items.Count < 1)
                {
                    ErrorMessageBox("Agregue al menos un elemento en la lista.", "Error", true);
                    this.AcceptButton.DialogResult = System.Windows.Forms.DialogResult.Abort;
                }
                else
                {
                    resultAttribute = new Attribute(NameTextBox.Text, TypeComboBox.GetItemText(TypeComboBox.SelectedItem), GetNominalOptions());
                    this.AcceptButton.DialogResult = System.Windows.Forms.DialogResult.OK;
                }

            }
            else if (TypeComboBox.GetItemText(TypeComboBox.SelectedItem) == "numeric")
            {
                if (String.IsNullOrEmpty(DominioComboBox.GetItemText(DominioComboBox.SelectedItem)))
                {
                    ErrorMessageBox("Seleccione un domio numérico por favor.", "Error", true);
                    this.AcceptButton.DialogResult = System.Windows.Forms.DialogResult.Abort;
                }
                else
                { 
                    resultAttribute = new Attribute(NameTextBox.Text, TypeComboBox.GetItemText(TypeComboBox.SelectedItem),
                                                    DominioComboBox.GetItemText(DominioComboBox.SelectedItem));
                    this.AcceptButton.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
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
        private string[] GetNominalOptions()
        {
            string[] elements = new string[NominalListBox.Items.Count];
            for (int i = 0; i < NominalListBox.Items.Count; i++)
            {
                elements[i] = NominalListBox.Items[i].ToString();
            }

            return elements;
        }

        private void TypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TypeComboBox.edit
            Console.Write("Selected Index Changed");
            DominioComboBox.Items.Clear();
            NominalListBox.Items.Clear();

            if(TypeComboBox.SelectedText == "numeric")
            {
                DominioComboBox.Items.Add("[0-9]+");
                DominioComboBox.Enabled = true;
            }
            else if(TypeComboBox.SelectedText == "nominal")
            {
                DominioComboBox.Enabled = false;
                string[] lineas = System.IO.File.ReadAllLines(filePath);
                string[] currentLine;
                for(int i = 0; i < lineas.Length; i++)
                {
                    currentLine = lineas[i].Split(',');
                    NominalListBox.Items.Add(currentLine[currentIndex]);
                }
                AddButton.Enabled = true;
                AddTextBox.Enabled = true;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (AddTextBox.Text.Contains(" ") || (AddTextBox.Text.Length < 1))
            {
                ErrorMessageBox("Nombre de atributo invalido, intenta de nuevo.", "Error", false);
            }
            else
            {
                NominalListBox.Items.Add(AddTextBox.Text);
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void SelectTypeButton_Click(object sender, EventArgs e)
        {
            DominioComboBox.Items.Clear();
            NominalListBox.Items.Clear();

            if (TypeComboBox.GetItemText(TypeComboBox.SelectedItem) == "numeric")
            {
                DominioComboBox.Items.Add("[0-9]+");
                DominioComboBox.Enabled = true;
                AddButton.Enabled = false;
                AddTextBox.Enabled = false;
                AcceptButton.Enabled = true;
            }
            else if (TypeComboBox.GetItemText(TypeComboBox.SelectedItem) == "nominal")
            {
                DominioComboBox.Enabled = false;
                string[] lineas = System.IO.File.ReadAllLines(filePath);
                string[] currentLine;
                int start = LookForBeginningOfData(filePath);
                //If NameTextBox is not enabled it means our first line of data in the document 
                //is actually attribute names.
                if(!NameTextBox.Enabled)
                {
                    start++;
                }

                for (int i = start; i < lineas.Length; i++)
                {
                    
                    currentLine = lineas[i].Split(',');
                    Console.WriteLine("Current line: " + currentLine + "file; " + filePath);

                    if (!NominalListBoxContainsString(currentLine[currentIndex]))
                    {
                        NominalListBox.Items.Add(currentLine[currentIndex]);
                    }
                   
                    
                }
                AddButton.Enabled = true;
                AddTextBox.Enabled = true;
                AcceptButton.Enabled = true;
            }
            else
            {
                ErrorMessageBox("Selecciona un tipo correcto.", "Error", false);
            }
        }

        private int LookForBeginningOfData(string filePath)
        {
            //Returns index of found data beginning in file
            string[] lineas = System.IO.File.ReadAllLines(filePath);
            for (int i = 0; i < lineas.Length; i++)
            {
                if ((lineas[i][0] != '@') && (lineas[i][0] != '%'))
                {
                    return i;
                }
            }
            return -1;
        }

        private bool NominalListBoxContainsString(string element)
        {
            for(int i = 0; i < NominalListBox.Items.Count; i++)
            {
                if(NominalListBox.Items[i].ToString() == element)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

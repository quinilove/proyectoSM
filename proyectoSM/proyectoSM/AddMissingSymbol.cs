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
    public partial class AddMissingSymbol : Form
    {
        public char MissingValue { get; set; }

        public AddMissingSymbol()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if((textBox1.Text.Length > 1) ||String.IsNullOrEmpty(textBox1.Text))
            {
                ErrorMessageBox("Solo puede ser un solo caracter.", "Error al guardar valor.", false);
                textBox1.Clear();
            }
            else
            {
                MissingValue = textBox1.Text[0];
                this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
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
    }
}

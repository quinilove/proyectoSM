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
    public partial class Menu : Form
    {
        List<Attribute> myAttributes;
        DataTable myData;

        public Menu()
        {
            InitializeComponent();
        }

        public Menu(List<Attribute> newAttributes, DataTable newData)
        {
            myAttributes = newAttributes;
            myData = newData;
        }

        private string[] ReturnAttributeInstancesByName(string attributeName)
        {
            int attributeIndex = 0;
            string[] instances = new string[myData.Rows.Count];

            for (int i = 0; i < myAttributes.Count; i++)
            {
                if (myAttributes[i].name == attributeName)
                {
                    attributeIndex = i;
                    break;
                }
            }

            for (int i = 0; i < instances.Length; i++)
            {
                instances[i] = myData.Rows[i].Field<string>(attributeIndex);
                Console.WriteLine(instances[i]);
            }

            return instances;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Univariable uni = new Univariable();

            uni.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            Bivariable Bi = new Bivariable();

            Bi.Show();
        }
    }
}

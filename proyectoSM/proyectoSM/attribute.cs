using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyectoSM
{
    public class Attribute
    {
        public string type;
        public string name;
        public List<string> nominalOptions = new List<string>();
        public string numericRegEx;


        public Attribute(string newName, string newType, string[] posibleOptions) //nominal constructor
        {
            type = newType;
            name = newName;
            for (int i = 0; i < posibleOptions.Length; i++)
            {
                nominalOptions.Add(posibleOptions[i]);
            }
        }

        public Attribute(string newName, string newType, string newNumericRegEx)
        {

            type = newType;
            name = newName;
            numericRegEx = newNumericRegEx;
        }
        
        public string PrintAttribute()
        {
            ///@attribute passenger_numbers numeric [0-9]+
            ///@attribute type nominal (tourist | first class)


            string returnValue = "@attribute ";
            returnValue += name + " ";
            returnValue += type + " ";

            if (nominalOptions.Count > 1)
            {
                returnValue += "(";
                for (int i = 0; i < nominalOptions.Count; i++)
                {
                    returnValue += nominalOptions[i] + "|";
                }
                returnValue = returnValue.Remove(returnValue.Length - 1);
                returnValue += ")";
            }
            else if(nominalOptions.Count == 1)
            {
                returnValue += "(";
                returnValue += nominalOptions[0];
                returnValue += ")";
            }
            else
            {
                returnValue += numericRegEx;
            }
            
            return returnValue;
        }

       
    }
}

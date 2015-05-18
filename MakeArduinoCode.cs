using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMLToArduino
{
    class MakeArduinoCode
    {
        private SortedDictionary<string, string> variables;
        private SortedDictionary<string, bool> definedVariables;
        private ArrayList dictionaryKeys;
        public MakeArduinoCode()
        {
            variables = new SortedDictionary<string, string>();
            definedVariables = new SortedDictionary<string, bool>();
            dictionaryKeys = new ArrayList();
        }
        public void CreateVariable(string type, string name, string value)
        {
            dictionaryKeys.Add(name);
            ChangeVariable(type, name, value);
        }
        public void ChangeVariable(string type, string name, string value)
        {
            variables[name] = type + " " + name + " = " + value + ";";
            definedVariables[name] = true;
        }
        public void CreateArray(string type, string name)
        {
            dictionaryKeys.Add(name);
            variables[name] = type + " " + name + "[] = {";
            definedVariables[name] = false;
        }
        public void AddElementToArray(string array, string elem)
        {
            if(variables.ContainsKey(array) && !definedVariables[array])
            {
                variables[array] += elem + ", ";
            }
        }
        public void FinishArray(string array)
        {
            if(variables.ContainsKey(array) && !definedVariables[array])
            {
                char[] charsToTrim = { ',', ' '};
                variables[array] = variables[array].Trim(charsToTrim);
                variables[array] += "};";
                definedVariables[array] = true;
            }
        }
        public ArrayList GetAllDefinedVariables()
        {
            ArrayList retVal = new ArrayList();
            for (int i = 0; i < dictionaryKeys.Count; i++)
            {
                if(definedVariables[(string)dictionaryKeys[i]])
                {
                    retVal.Add(variables[(string)dictionaryKeys[i]]);
                }
            }
            return retVal;
        } 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_IA_Ibasic_Intouch_Re
{
    class IBASICtranslator
    {
        private string[] IBASICcode;

        public IBASICtranslator(string[] IBASICcode)
        {
            this.IBASICcode = IBASICcode;
        }
        public void Toutput()
        {
            string line = "";
            string keyword;
            for(int i=0; i < IBASICcode.Length; i++)
            {
                line = IBASICcode[i];
                line = line.Trim();
                keyword = line.Substring(0, 6);
                ///This if statement makes sure "INPUT" is not part of a variable name
                if (line.Substring(6, 1) == " ")
                {
                    string therest = line.Substring(6);
                    therest = therest.Trim();
                    char qm = '"';

                    if (keyword == "OUTPUT")
                    {
                        string[] eachString = therest.Split(',');
                        string outputstring = "";
                        ///This loop is to change , to + but it doesnt have to do it for the last eachstring
                        for (int z = 0; z < eachString.Length - 1; z++)
                        {
                            ///The if statement is to determine if the comma is within a string or a string add operation
                            if (eachString[z].StartsWith(qm.ToString()) == true && eachString[z].EndsWith(qm.ToString()) == true
                                || eachString[z].Contains(qm.ToString()) == false || eachString[z].EndsWith(qm.ToString()) == true)
                            {
                                /// if eachstring[z] is just a " would mean that , is the first char of that string value
                                /// so i wont change , to + but if eachstring[z] contains a " but isnt just " it would mean that
                                ///  " is at the end so i'd change , to +. 
                                if (eachString[z] != qm.ToString())
                                {
                                    eachString[z] = eachString[z] + "+";
                                }
                                else
                                {
                                    eachString[z] = eachString[z] + ",";
                                }
                            }
                            else
                            {
                                eachString[z] = eachString[z] + ",";
                            }
                            outputstring = outputstring + eachString[z];
                        }
                        outputstring = outputstring + eachString[eachString.Length - 1];

                        IBASICcode[i] = "Console.WriteLine(" + outputstring + ")";
                    }
                    
                }
            }
         
        }
        public void Tinput()
        {
            string line = "";
            string keyword;
            for (int i = 0; i < IBASICcode.Length; i++)
            {
                line = IBASICcode[i].Trim();
                keyword = line.Substring(0, 5);
                ///This if statement makes sure "INPUT" is not part of a variable name
                if (line.Substring(5, 1) == " ")
                {
                    string therest = line.Substring(5);
                    therest = therest.Trim();

                    if (keyword == "INPUT")
                    {
                        IBASICcode[i] = therest + " = " + "Console.ReadLine()";
                    }
                }
            }
        }

        public void TvarDeclaration()
        {
            string line = "";
            string keyword;
            for (int i = 0; i < IBASICcode.Length; i++)
            {
                line = IBASICcode[i].Trim();
                keyword = line.Substring(0, 7);
                string arraycheck = string.Concat(IBASICcode[i].Where(c => !Char.IsWhiteSpace(c)));
                ///This if statement makes sure "DECLARE" is not part of a variable name and its not array declaration
                if (line.Substring(7, 1) == " " &&
                    arraycheck.Contains("ARRAY[") == false)
                {
                    string therest = line.Substring(7);
                    therest = therest.Trim();
                    string[] variable = therest.Split(':');
                    string variableName = variable[0].Trim();
                    variable[1] = variable[1].Trim();
                    string type1 = variable[1].Substring(0, 1).ToUpper();
                    string type2 = variable[1].Substring(1).ToLower();
                    if (keyword == "DECLARE")
                    {
                        IBASICcode[i] = "Dim " + variableName + " As " + type1 + type2;

                    }
                }
            }
        }

            public string TarrayDeclaration()
            {
                string line = "";
                string keyword;
                for (int i = 0; i < IBASICcode.Length; i++)
                {
                    line = IBASICcode[i].Trim();
                    keyword = line.Substring(0, 7);
                    ///get rid of all the spaces
                    string arraycheck = string.Concat(IBASICcode[i].Where(c => !Char.IsWhiteSpace(c)));
                    ///This if statement makes sure "DECLARE" is not part of a variable name and isa array declaration
                    if (line.Substring(7, 1) == " " &&
                        arraycheck.Contains("ARRAY[") == true)
                    {
                        string therest = line.Substring(7);
                        therest = therest.Trim();
                        string[] variablearray = therest.Split(':', 2);
                        string variable = variablearray[0].Trim();
                        string[] indexandtype = variablearray[1].Split(']');
                        string type = indexandtype[1].Trim();
                        string[] types = type.Split('F');
                        types[1] = types[1].Trim();
                        string type1 = types[1].Substring(0, 1).ToUpper();
                        string type2 = types[1].Substring(1).ToLower();
                        ///get rid of all the space to make it easier to separate indices
                        indexandtype[0] = string.Concat(indexandtype[0].Where(c => !Char.IsWhiteSpace(c)));
                        string[] Indices = indexandtype[0].Split(':');
                        int index = int.Parse(Indices[1]);
                        if (keyword == "DECLARE")
                        {
                            IBASICcode[i] = "Dim " + variable+"(" + (index-1) + ")" + " As " + type1 + type2;
                            line = IBASICcode[i];
                        }
                    }
                   
                }
            return line;
        }
        
    }
}

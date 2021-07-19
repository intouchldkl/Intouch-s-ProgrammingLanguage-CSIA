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
        public string translateOUTPUT()
        {
            string line = "";
            string keyword;
            for(int i=0; i < IBASICcode.Length; i++)
            {
                line = IBASICcode[i];
                line = line.Trim();
                keyword = line.Substring(0, 6);
                string therest = line.Substring(6);
                therest = therest.Trim();
                char qm = '"';

                if (keyword == "OUTPUT")
                {
                    string[] eachString = therest.Split(',');
                    string outputstring = "";
                    ///This loop is to change , to + but it doesnt have to do it for the last eachstring
                    for(int z = 0; z < eachString.Length-1; z++)
                    {
                        ///The if statement is to determine if the comma is within a string or a string add operation
                        if (eachString[z].StartsWith(qm.ToString()) == true && eachString[z].EndsWith(qm.ToString()) == true
                            || eachString[z].Contains(qm.ToString()) == false || eachString[z].EndsWith(qm.ToString()) == true)
                        {
                            /// if eachstring[z] is just a " would mean that , is the first char of that string value
                            /// so i wont change , to + but if eachstring[z] contains a " but isnt just " it would mean that
                            ///  " is at the end so i'd change , to +. This also make sure that if 
                            ///  , is part of a variable name it wont get converted to +
                            if(eachString[z] != qm.ToString() && eachString[z].Contains(qm.ToString()) == true)
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
                    outputstring = outputstring + eachString[eachString.Length-1];

                    line = "Console.WriteLine(" + outputstring + ")";
                }
                else if(keyword == "INPUT")
                {
                    line = therest + " = " + "Console.ReadLine()";
                }
            }
            return line;
        }
    }
}

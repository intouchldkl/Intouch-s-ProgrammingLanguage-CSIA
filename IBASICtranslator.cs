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
        private const string VBdivfunction = "Function DIV(i As Integer, z As Integer)" + "\n" + " Return Math.Floor(i / z)" + "\n" + "End Function";
        private const string VBmodfunction = "Function MODULO(i As Integer, z As Integer)" + "\n" + " Return i Mod z" + "\n" + "End Function";

        public IBASICtranslator(string[] IBASICcode)
        {
            this.IBASICcode = IBASICcode;
        }
        public string Toutput()
        {
            string keyword = "OUTPUT ";
            for(int i=0; i < IBASICcode.Length; i++)
            {
                if (IBASICcode[i].Contains(keyword) == true)
                {
                    if (IBASICcode[i].TrimStart().Substring(0, 7) == keyword)
                    {
                        IBASICcode[i] = IBASICcode[i].Replace(IBASICcode[i].TrimStart().Substring(0, 6), "Console.WriteLine( ");
                        IBASICcode[i] = IBASICcode[i] + ")";
                        line = IBASICcode[i];
                    }
                }
                
            }
        }
        public void Tinput()
        {
            string line = "";
            string keyword = "INPUT";
            for (int i = 0; i < IBASICcode.Length; i++)
            {
                if (IBASICcode[i].Contains("INPUT ") == true)
                {
                    try
                    {
                        line = IBASICcode[i].Trim();
                        ///This if statement makes sure "INPUT" is not part of a variable name
                        if (line.Substring(5, 1) == " " && line.Substring(5) != null && line.Substring(0, 5) == keyword)
                        {
                            keyword = line.Substring(0, 5);
                            string therest = line.Substring(5);
                            therest = therest.Trim();
                            IBASICcode[i] = therest + " = " + "Console.ReadLine()";

                        }
                    }
                    catch
                    {

                    }
                }
            }
        }

        public void TvarDeclaration()
        {
            string line = "";
            string keyword = "DECLARE";
            for (int i = 0; i < IBASICcode.Length; i++)
            {
                if (IBASICcode[i].Contains("DECLARE ") == true)
                {
                    line = IBASICcode[i].Trim();
                    string arraycheck = string.Concat(IBASICcode[i].Where(c => !Char.IsWhiteSpace(c)));
                    if (line.Substring(7) != null)
                    {
                        try
                        {
                            ///This if statement makes sure "DECLARE" is not part of a variable name and its not array declaration
                            if (line.Substring(0, 7) == keyword && line.Substring(7, 1) == " " &&
                                arraycheck.Contains("ARRAY[") == false)
                            {
                                string therest = line.Substring(7);
                                therest = therest.Trim();
                                string[] variable = therest.Split(':');
                                string variableName = variable[0].Trim();
                                variable[1] = variable[1].Trim();
                                string type1 = variable[1].Substring(0, 1).ToUpper();
                                string type2 = variable[1].Substring(1).ToLower();
                                IBASICcode[i] = "Dim " + variableName + " As " + type1 + type2;

                            }
                        }
                        catch
                        {

                        }
                    }
                }

            }
        }


            public void TarrayDeclaration()
        {
            string line = "";
            string keyword = "DECALRE";
            for (int i = 0; i < IBASICcode.Length; i++)
            {
                try
                {
                    ///get rid of all the spaces
                    string arraycheck = string.Concat(IBASICcode[i].Where(c => !Char.IsWhiteSpace(c)));
                    if (arraycheck.Contains("ARRAY[") == true && arraycheck.Substring(0, 7) == keyword)
                    {
                        line = IBASICcode[i].Trim();
                        ///This if statement makes sure "DECLARE" is not part of a variable name and isa array declaration
                        if (line.Substring(7, 1) == " " && IBASICcode[i].Contains(",") == false)
                        {

                            string therest = line.Substring(7);
                            if (therest.Contains("OF") == true && therest.Contains("]") == true)
                                therest = string.Concat(therest.Where(c => !Char.IsWhiteSpace(c)));
                            string[] variablearray = therest.Split(':');
                            if (variablearray.Length == 3)
                            {
                                string variableName = variablearray[0];
                                string[] indexandtype = variablearray[2].Split(']');
                                string type = indexandtype[1];
                                string[] types = type.Split('F');
                                if (types.Length == 2 && types[1] != "")
                                {
                                    types[1] = types[1].Trim();
                                    string type1 = types[1].Substring(0, 1).ToUpper();
                                    string type2 = types[1].Substring(1).ToLower();
                                    bool IsThereIndex = int.TryParse(indexandtype[0], out int index);
                                    if (IsThereIndex == true)
                                    {
                                        IBASICcode[i] = "Dim " + variableName + "(" + index + ")" + " As " + type1 + type2;
                                    }

                                }

                            }
                        }

                    }
                }
                catch
                {

                }

            }
        }

        public void T2dArrayDeclaration()
        {
            string line = "";
            string keyword = "DECLARE";
            for (int i = 0; i < IBASICcode.Length; i++)
            {
                try
                { 
                ///get rid of all the spaces
                string arraycheck = string.Concat(IBASICcode[i].Where(c => !Char.IsWhiteSpace(c)));
                if(arraycheck.Contains("ARRAY[") == true && arraycheck.Substring(0, 7) == keyword)
                { 
                line = IBASICcode[i].Trim();
                        ///This if statement makes sure "DECLARE" is not part of a variable name and isa array declaration
                        if (line.Substring(7, 1) == " " && IBASICcode[i].Contains(",") == true)
                        {

                            string therest = line.Substring(7);
                            if (therest.Contains("OF") == true && therest.Contains("]") == true)
                                therest = string.Concat(therest.Where(c => !Char.IsWhiteSpace(c)));
                            string[] variablearray = therest.Split(':');
                            if (variablearray.Length == 4)
                            {
                                string variableName = variablearray[0];
                                string[] uncutindex1 = variablearray[2].Split(',');
                                bool isThereIndex1 = int.TryParse(uncutindex1[0], out int index1);
                                if (isThereIndex1 == true)
                                {
                                    string[] index2andtype = variablearray[3].Split(']');
                                    string type = index2andtype[1];
                                    string[] types = type.Split('F');
                                    if (types.Length == 2 && types[1] != "")
                                    {
                                        types[1] = types[1];
                                        string type1 = types[1].Substring(0, 1).ToUpper();
                                        string type2 = types[1].Substring(1).ToLower();
                                        bool IsThereIndex2 = int.TryParse(index2andtype[0], out int index2);
                                        if (IsThereIndex2 == true)
                                        {
                                            IBASICcode[i] = "Dim " + variableName + "(" + index1 + ", " + index2 + ")" + " As " + type1 + type2;

                                        }

                                    }
                                }

                            }
                        }

                    }
                }
                catch
                {

                }

            }
            
        }

        public void TForloop()
        {
            string keyword1 = "FOR ";
            string keyword2 = "NEXT ";
            string keyword3 = " TO ";
            string keyword4 = " STEP ";
            for(int i = 0; i < IBASICcode.Length; i++)
            {
                if(IBASICcode[i].Contains(keyword1) == true)
                {
                    if (IBASICcode[i].TrimStart().Substring(0, 4) == keyword1)
                    {
                      IBASICcode[i] = IBASICcode[i].Replace(IBASICcode[i].Trim().Substring(0, 3), "For ");
                    }
                }
                if (IBASICcode[i].Contains(keyword2) == true)
                {
                    if (IBASICcode[i].TrimStart().Substring(0, 5) == keyword2)
                    {
                      IBASICcode[i] = IBASICcode[i].Replace(IBASICcode[i].Trim().Substring(0, 4), "Next ");
                    }

                }
                if (IBASICcode[i].Contains(keyword3) == true)
                {                  
                     IBASICcode[i] =  IBASICcode[i].Replace(keyword3, " To ");
                }
                if (IBASICcode[i].Contains(keyword4) == true)
                {
                    IBASICcode[i] = IBASICcode[i].Replace(keyword4, " Step ");
                }
            }
        }
        public void TIfstatement()
        {
            string keyword1 = "IF ";
            string keyword2 = "ENDIF";
            string keyword3 = "ELSEIF ";
            string keyword4 = "ELSE";
            string keyword5 = " THEN";
            for (int i = 0; i < IBASICcode.Length; i++)
            {
                if (IBASICcode[i].Contains(keyword1) == true)
                {
                    if (IBASICcode[i].TrimStart().Substring(0, 3) == keyword1)
                    {
                        IBASICcode[i] = IBASICcode[i].Replace(IBASICcode[i].TrimStart().Substring(0, 2), "If ");
                        if (IBASICcode[i].Contains(keyword5) == true)
                        {
                            IBASICcode[i] = IBASICcode[i].Replace(keyword5, " Then ");
                        }
                    }
                }
                if (IBASICcode[i].Contains(keyword2) == true)
                {
                    if (IBASICcode[i].TrimStart().Substring(0, 5) == keyword2)
                    {
                        IBASICcode[i] = IBASICcode[i].Replace(keyword2, "End If");
                    }

                }
                if (IBASICcode[i].Contains(keyword3) == true)
                {
                    if (IBASICcode[i].TrimStart().Substring(0, 7) == keyword3)
                    {
                        IBASICcode[i] = IBASICcode[i].Replace(IBASICcode[i].TrimStart().Substring(0, 6), "ElseIf ");
                        if (IBASICcode[i].Contains(keyword5) == true)
                        {
                            IBASICcode[i] = IBASICcode[i].Replace(keyword5, " Then ");
                        }
                    }
                }
                if (IBASICcode[i].Contains(keyword4) == true)
                {
                    if (IBASICcode[i].TrimStart().Substring(0, 4) == keyword4)
                    {
                        IBASICcode[i] = IBASICcode[i].Replace(keyword4, "Else");
                    }
                }

            }
        }

        public void Twhileloop()
        {
            string keyword1 = "WHILE ";
            string keyword2 = "ENDWHILE";
            string keyword3 = " DO";
            for (int i = 0; i < IBASICcode.Length; i++)
            {
                if (IBASICcode[i].Contains(keyword1) == true)
                {
                    if (IBASICcode[i].TrimStart().Substring(0, 6) == keyword1)
                    {
                        IBASICcode[i] = IBASICcode[i].Replace(IBASICcode[i].TrimStart().Substring(0, 5), "While ");
                        if (IBASICcode[i].Contains(keyword3) == true)
                        {
                            IBASICcode[i] = IBASICcode[i].Replace(keyword3," ");
                        }
                    }
                }
                if (IBASICcode[i].Contains(keyword2) == true)
                {
                    if (IBASICcode[i].TrimStart().Substring(0, 8) == keyword2)
                    {
                        IBASICcode[i] = IBASICcode[i].Replace(keyword2, "EndWhile");
                    }

                }
            }
        }
        public void TrepeatUntil()
        {
            string keyword1 = "REPEAT";
            string keyword2 = "UNTIL ";
            for (int i = 0; i < IBASICcode.Length; i++)
            {
                if (IBASICcode[i].Contains(keyword1) == true)
                {
                    if (IBASICcode[i].TrimStart().Substring(0, 6) == keyword1 )
                    {
                        IBASICcode[i] = IBASICcode[i].Replace(keyword1, "Do");                     
                    }
                }
                if (IBASICcode[i].Contains(keyword2) == true)
                {
                    if (IBASICcode[i].TrimStart().Substring(0, 6) == keyword2 )
                    {
                        IBASICcode[i] = IBASICcode[i].Replace(IBASICcode[i].TrimStart().Substring(0, 5), "Loop Until ");
                    }

                }
            }
        }
        public void TconstantDeclaration()
        {
            string keyword1 = "CONSTANT ";
            for (int i = 0; i < IBASICcode.Length; i++)
            {
                if (IBASICcode[i].Contains(keyword1) == true)
                {
                    if (IBASICcode[i].TrimStart().Substring(0,9) == keyword1)
                    {
                        IBASICcode[i] = IBASICcode[i].Replace(IBASICcode[i].TrimStart().Substring(0,8), "Const ");
                    }
                };
            }
        }
        public void Tmod()
        {
            string keyword1 = "MOD(";
            string lineNoSpace = "";
            for (int i = 0; i < IBASICcode.Length; i++)
            {
                lineNoSpace = string.Concat(IBASICcode[i].Where(c => !Char.IsWhiteSpace(c)));
                if (lineNoSpace.Contains(keyword1) == true)
                {
                        IBASICcode[i] = IBASICcode[i].Replace(keyword1, "MODULO(");
                }
            }
        }
   
    }
}

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
        private string Translatedcode;
        private string errmsg;
        private List<string> arrayvar = new List<string>();
        private List<string> IBfunctionsNsub = new List<string>();
        private List<string> errormessages = new List<string>();
        private const string VBdivfunction = "Function DIV(i As Integer, z As Integer)" + "\n" + " Return Math.Floor(i / z)" + "\n" + "End Function";
        private const string VBmodfunction = "Function MODULO(i As Integer, z As Integer)" + "\n" + " Return i Mod z" + "\n" + "End Function";
        private const string VBlengthfunction = "Function LENGTH(s As String)" + "\n" + "Dim ss As String = s" + "\n" + "Return ss.Length" + "\n" + "End Function";
        private const string VBUcasefunction = "Function UCASE(s As String)" + "\n" + "Dim ss As String = s" + "\n" + "Return ss.ToUpper" + "\n" + "End Function";
        private const string VBLcasefunction = "Function LCASE(s As String)" + "\n" + "Dim ss As String = s" + "\n" + "Return ss.ToLower" + "\n" + "End Function";
        private const string VBsubstringfunction = "Function SUBSTRING(s As String, i As Integer, z As Integer)" + "\n" + "Dim ss As String = s" + "\n" + "Return ss.Substring(i, z)" + "\n" + "End Function";
        private const string VBsubstringfunctionOVL = "Function SUBSTRING(s As String, i As Integer)" + "\n" + "Dim ss As String = s" + "\n" + "Return ss.Substring(i)" + "\n" + "End Function";
        private const string VBroundfunction = "Function ROUND(d As Double, place As Integer)" + "\n" + "Return Math.Round(d, place)" + "\n" + "End Function";
        private const string Header = "Imports System" + "\n" + "Module Program" + "\n" + "Sub Main(args As String())" + "\n";
        private const string endSubMain = "End Sub";
        private const string endModule = "End Module";
        private const string endmsg = "Press any key to continue";

        public IBASICtranslator(string[] IBASICcode)
        {
            this.IBASICcode = IBASICcode;
        }
        public void Toutput()
        {
            string keyword = "OUTPUT ";
            for (int i = 0; i < IBASICcode.Length; i++)
            {
                if (IBASICcode[i].Contains(keyword) == true)
                {
                    if (IBASICcode[i].TrimStart().Substring(0, 7) == keyword)
                    {
                        IBASICcode[i] = IBASICcode[i].Replace(IBASICcode[i].TrimStart().Substring(0, 6), "Console.WriteLine( ");
                        IBASICcode[i] = IBASICcode[i] + ")";
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
            }
        }

        public void TvarDeclaration()
        {
            string keyword = "DECLARE ";
            string keyword2 = ":";
            for (int i = 0; i < IBASICcode.Length; i++)
            {
                if (IBASICcode[i].Contains(keyword) == true)
                {
                    string arraycheck = string.Concat(IBASICcode[i].Where(c => !Char.IsWhiteSpace(c)));
                    ///This if statement makes sure "DECLARE" is not part of a variable name and its not array declaration
                    if (IBASICcode[i].TrimStart().Substring(0, 8) == keyword && arraycheck.Contains("ARRAY[") == false)
                    {
                        IBASICcode[i] = IBASICcode[i].Replace(IBASICcode[i].TrimStart().Substring(0, 7), "Dim ");

                        if (IBASICcode[i].Contains(keyword2) == true)
                        {
                            IBASICcode[i] = IBASICcode[i].Replace(keyword2, " As ");
                        }
                        else
                        {
                            errormessages.Add("Line " + (i + 1) + " : Syntax error : Could be because ':' is missing ");
                        }
                    }



                }

            }
        }


        public void TarrayDeclaration()
        {
            string line = "";
            string keyword = "DECLARE ";
            for (int i = 0; i < IBASICcode.Length; i++)
            {

                ///get rid of all the spaces
                string arraycheck = string.Concat(IBASICcode[i].Where(c => !Char.IsWhiteSpace(c)));
                if (arraycheck.Contains("ARRAY[") == true && IBASICcode[i].TrimStart().Substring(0, 8) == keyword)
                {
                    line = IBASICcode[i].Trim();
                    ///This if statement makes sure "DECLARE" is not part of a variable name and isa array declaration
                    if (line.Substring(7, 1) == " " && IBASICcode[i].Contains(",") == false)
                    {

                        string therest = line.Substring(7);
                        if (therest.Contains("OF") == true && therest.Contains("]") == true)
                        {
                            therest = string.Concat(therest.Where(c => !Char.IsWhiteSpace(c)));
                            if (therest.Contains(":") == true)
                            {
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
                                            arrayvar.Add(variableName);
                                        }
                                        else
                                        {
                                            errormessages.Add("Line " + (i + 1) + " : Syntax error: could be because an idex is missing");
                                        }

                                    }
                                }
                            }
                            else
                            {
                                errormessages.Add("Line " + (i + 1) + " : Syntax error: could be because ':' is missing");
                            }
                        }
                        else
                        {
                            errormessages.Add("Line " + (i + 1) + " : Syntax error: could be because 'OF' or ']' is missing");
                        }
                    }

                }
            }
        }

        public void T2dArrayDeclaration()
        {
            string line = "";
            string keyword = "DECLARE ";
            for (int i = 0; i < IBASICcode.Length; i++)
            {

                ///get rid of all the spaces
                string arraycheck = string.Concat(IBASICcode[i].Where(c => !Char.IsWhiteSpace(c)));
                if (arraycheck.Contains("ARRAY[") == true && IBASICcode[i].TrimStart().Substring(0, 8) == keyword)
                {
                    line = IBASICcode[i].Trim();
                    ///This if statement makes sure "DECLARE" is not part of a variable name and isa array declaration
                    if (line.Substring(7, 1) == " " && IBASICcode[i].Contains(",") == true)
                    {

                        string therest = line.Substring(7);
                        if (therest.Contains("OF") == true && therest.Contains("]") == true)
                        {
                            therest = string.Concat(therest.Where(c => !Char.IsWhiteSpace(c)));
                            if (therest.Contains(":") == true)
                            {
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
                                                arrayvar.Add(variableName);
                                            }
                                            else
                                            {
                                                errormessages.Add("Line " + (i + 1) + " : Syntax error: could be because there is an index missing");
                                            }

                                        }
                                        else
                                        {
                                            errormessages.Add("Line " + (i + 1) + " : Syntax error: could be because data type is missing");
                                        }

                                    }
                                    else
                                    {
                                        errormessages.Add("Line " + (i + 1) + " : Syntax error: could be because there is an index missing");
                                    }
                                }
                                else
                                {
                                    errormessages.Add("Line " + (i + 1) + " : Syntax error: could be because ':' is missing or unneccessary ':'");
                                }
                            }
                            else
                            {
                                errormessages.Add("Line " + (i + 1) + " : Syntax error: could be because ':' is missing");
                            }

                        }
                        else
                        {
                            errormessages.Add("Line " + (i + 1) + " : Syntax error: could be because 'OF' or ']' is missing");
                        }
                    }

                }
            }
        }

        public void TForloop()
        {
            string keyword1 = "FOR ";
            string keyword2 = "NEXT ";
            string keyword3 = " TO ";
            string keyword4 = " STEP ";
            for (int i = 0; i < IBASICcode.Length; i++)
            {
                if (IBASICcode[i].Contains(keyword1) == true)
                {
                    if (IBASICcode[i].TrimStart().Substring(0, 4) == keyword1)
                    {
                        IBASICcode[i] = IBASICcode[i].Replace(IBASICcode[i].Trim().Substring(0, 3), "For ");
                        if (IBASICcode[i].Contains(keyword3) == true)
                        {
                            IBASICcode[i] = IBASICcode[i].Replace(keyword3, " To ");
                        }
                        else
                        {
                            errormessages.Add("Line " + (i + 1) + " : Syntax error : Could be becuase 'TO' is missing or incorrect spacing");
                        }
                        for (int z = i; z < IBASICcode.Length; z++)
                        {
                            if (IBASICcode[z].Contains(keyword2) == true)
                            {
                                break;
                            }
                            if (z == (IBASICcode.Length - 1) && IBASICcode[z].Contains(keyword2) == false)
                            {
                                errormessages.Add("Syntax error : NEXT or an identifier is expected somewhere ");
                            }
                        }
                    }
                }
                if (IBASICcode[i].Contains(keyword2) == true)
                {
                    if (IBASICcode[i].TrimStart().Substring(0, 5) == keyword2)
                    {
                        IBASICcode[i] = IBASICcode[i].Replace(IBASICcode[i].Trim().Substring(0, 4), "Next ");
                    }

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
            string keyword6 = "AND";
            string keyword7 = "OR";
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
                        else
                        {
                            errormessages.Add("Line " + (i + 1) + " : Syntax error : Could be because 'THEN' is expected or incorrect spacing");
                        }
                        if (IBASICcode[i].Contains(keyword6) == true)
                        {
                            IBASICcode[i] = IBASICcode[i].Replace(keyword6, " And ");
                        }
                        if (IBASICcode[i].Contains(keyword7) == true)
                        {
                            IBASICcode[i] = IBASICcode[i].Replace(keyword7, " Or ");
                        }
                        for (int z = i; z < IBASICcode.Length; z++)
                        {
                            if (IBASICcode[z].Contains(keyword2) == true)
                            {
                                break;
                            }
                            if (z == (IBASICcode.Length - 1) && IBASICcode[z].Contains(keyword2) == false)
                            {
                                errormessages.Add("Syntax error : ENDIF is expected somewhere");
                            }
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
                        else
                        {
                            errormessages.Add("Line " + (i + 1) + " : Syntax error : Could be because 'THEN' is expected or incorrect spacing");
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
                            IBASICcode[i] = IBASICcode[i].Replace(keyword3, " ");
                        }
                        else
                        {
                            errormessages.Add("Line " + (i + 1) + " : Syntax error : Could be because 'DO' is expected or incorrect spacing");
                        }
                        for (int z = i; z < IBASICcode.Length; z++)
                        {
                            if (IBASICcode[z].Contains(keyword2) == true)
                            {
                                break;
                            }
                            if (z == (IBASICcode.Length - 1) && IBASICcode[z].Contains(keyword2) == false)
                            {
                                errormessages.Add("Syntax error : ENDWHILE is expected somewhere");
                            }
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
                    if (IBASICcode[i].TrimStart().Substring(0, 6) == keyword1)
                    {
                        IBASICcode[i] = IBASICcode[i].Replace(keyword1, "Do");
                        for (int z = i; z < IBASICcode.Length; z++)
                        {
                            if (IBASICcode[z].Contains(keyword2) == true)
                            {
                                if (IBASICcode[z].TrimStart().Substring(0, 6) == keyword2)
                                {
                                    IBASICcode[z] = IBASICcode[z].Replace(IBASICcode[z].TrimStart().Substring(0, 5), "Loop Until ");
                                }
                                break;
                            }
                            if (z == (IBASICcode.Length - 1) && IBASICcode[z].Contains(keyword2) == false)
                            {
                                errormessages.Add("Syntax error : UNTIL or UNTIL condition is expected somewhere ");
                            }
                        }
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
                    if (IBASICcode[i].TrimStart().Substring(0, 9) == keyword1)
                    {
                        IBASICcode[i] = IBASICcode[i].Replace(IBASICcode[i].TrimStart().Substring(0, 8), "Const ");
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
        public void Tcomment()
        {
            string keyword1 = "//";
            for (int i = 0; i < IBASICcode.Length; i++)
            {
                if (IBASICcode[i].Contains(keyword1) == true)
                {
                    IBASICcode[i] = IBASICcode[i].Replace(keyword1, "'");
                }
            }
        }
        public void TdataType()
        {
            string keyword1 = "INTEGER";
            string keyword2 = " REAL";
            string keyword3 = "BOOLEAN";
            string keyword4 = "CHAR";
            string keyword5 = "STRING";
            for (int i = 0; i < IBASICcode.Length; i++)
            {
                if (IBASICcode[i].Contains(keyword1) == true)
                {
                    IBASICcode[i] = IBASICcode[i].Replace(keyword1, " Integer");
                }
                if (IBASICcode[i].Contains(keyword2) == true)
                {
                    IBASICcode[i] = IBASICcode[i].Replace(keyword2, " Double");
                }
                if (IBASICcode[i].Contains(keyword3) == true)
                {
                    IBASICcode[i] = IBASICcode[i].Replace(keyword3, " Boolean");
                }
                if (IBASICcode[i].Contains(keyword4) == true)
                {
                    IBASICcode[i] = IBASICcode[i].Replace(keyword4, " Char");
                }
                if (IBASICcode[i].Contains(keyword5) == true)
                {
                    IBASICcode[i] = IBASICcode[i].Replace(keyword5, " String");
                }
            }

        }
        public void Trandomfunc()
        {
            string keyword1 = "RANDOM()";
            for (int i = 0; i < IBASICcode.Length; i++)
            {
                if (IBASICcode[i].Contains(keyword1) == true)
                {
                    IBASICcode[i] = IBASICcode[i].Replace(keyword1, "Rnd()");
                }
            }
        }
        public void Tarrays()
        {
            string keyword1 = "[";
            string keyword2 = "]";
            for (int i = 0; i < IBASICcode.Length; i++)
            {
                if (IBASICcode[i].Contains("Dim") == false)
                {
                    foreach (string arrayname in arrayvar)
                        if (IBASICcode[i].Contains(arrayname) == true)
                        {
                            if (IBASICcode[i].Contains(keyword1) == true)
                            {
                                IBASICcode[i] = IBASICcode[i].Replace(keyword1, "(");
                            }
                            else
                            {
                                errormessages.Add("Line " + (i + 1) + " : Syntax error " + arrayname + " is an array and '[' is expected");
                            }
                            if (IBASICcode[i].Contains(keyword2) == true)
                            {
                                IBASICcode[i] = IBASICcode[i].Replace(keyword2, ")");
                            }
                            else
                            {
                                errormessages.Add("Line " + (i + 1) + " : Syntax error " + arrayname + " is an array and ']' is expected");
                            }
                        }
                }
            }
        }
        public void Tcasestatement()
        {
            string keyword1 = "CASE OF ";
            string keyword2 = "CASE ";
            string keyword3 = "OTHERWISE ";
            string keyword4 = ":";
            string keyword5 = "ENDCASE";
            for (int i = 0; i < IBASICcode.Length; i++)
            {
                if (IBASICcode[i].Contains(keyword1) == true)
                {
                    if (IBASICcode[i].TrimStart().Substring(0, 8) == keyword1)
                    {
                        IBASICcode[i] = IBASICcode[i].Replace(IBASICcode[i].TrimStart().Substring(0, 7), "Select Case ");
                        for (int z = i; z < IBASICcode.Length; z++)
                        {
                            if (IBASICcode[z].Contains(keyword5) == true)
                            {
                                break;
                            }
                            if (IBASICcode[z].Contains(keyword2) == true)
                            {
                                if (IBASICcode[z].TrimStart().Substring(0, 5) == keyword2)
                                {
                                    IBASICcode[z] = IBASICcode[z].Replace(IBASICcode[z].TrimStart().Substring(0, 4), "Case ");
                                    if (IBASICcode[z].Contains(keyword4) == true)
                                    {
                                        IBASICcode[z] = IBASICcode[z].Replace(keyword4, Environment.NewLine);
                                    }
                                    else
                                    {
                                        errormessages.Add("Line " + (z + 1) + " : Syntax error : ':' after the condition");
                                    }
                                }
                                else
                                {
                                    errormessages.Add("Line " + (z + 1) + " : Syntax error : 'CASE' is expected at the start of the line");
                                }

                            }
                            if (z == (IBASICcode.Length - 1) && IBASICcode[z].Contains(keyword5) == false)
                            {
                                errormessages.Add("Syntax error : ENDCASE is expected somewhere ");
                            }
                        }
                    }
                }

                if (IBASICcode[i].Contains(keyword3) == true)
                {
                    if (IBASICcode[i].TrimStart().Substring(0, 10) == keyword3)
                    {
                        IBASICcode[i] = IBASICcode[i].Replace(IBASICcode[i].TrimStart().Substring(0, 9), "Case Else " + "\n");
                    }

                }
                if (IBASICcode[i].Contains(keyword5) == true)
                {
                    if (IBASICcode[i].TrimStart().Substring(0, 7) == keyword5)
                    {
                        IBASICcode[i] = IBASICcode[i].Replace(IBASICcode[i].TrimStart().Substring(0, 7), "End Select ");
                    }
                }
            }
        }
        public void Tfunction()
        {
            string keyword1 = "FUNCTION ";
            string keyword2 = "ENDFUNCTION";
            string keyword3 = "RETURN ";
            string keyword4 = ":";
            string keyword5 = "RETURNS";
            for (int i = 0; i < IBASICcode.Length; i++)
            {
                if (IBASICcode[i].Contains(keyword1) == true)
                {
                    if (IBASICcode[i].TrimStart().Substring(0, 9) == keyword1)
                    {
                        IBASICcode[i] = IBASICcode[i].Replace(IBASICcode[i].TrimStart().Substring(0, 8), "Function");
                        if (IBASICcode[i].Contains(keyword4) == true)
                        {
                            IBASICcode[i] = IBASICcode[i].Replace(keyword4, " As ");
                        }
                        if (IBASICcode[i].Contains(keyword5) == true)
                        {
                            IBASICcode[i] = IBASICcode[i].Replace(keyword5, " As ");
                        }
                        else
                        {
                            errormessages.Add("Line " + (i + 1) + " 'RETURNS' is expected, A function must return value");
                        }
                        ///Loop until ENDFUNCTION is found
                        for (int z = i; z < IBASICcode.Length; z++)
                        {
                            if (IBASICcode[z].Contains(keyword3) == true)
                            {
                                IBASICcode[z] = IBASICcode[z].Replace(keyword3, "Return ");
                            }
     
                            if (IBASICcode[z].Contains(keyword2) == true)
                            {
                                if (IBASICcode[z].TrimStart().Substring(0, 11) == keyword2)
                                {
                                    IBASICcode[z] = IBASICcode[z].Replace(keyword2, "End Function");
                                    IBfunctionsNsub.Add(IBASICcode[z]);
                                    IBASICcode[z] = "";
                                    //Stop the process when ENDFUNCTION is found
                                    break;
                                }
                            }
                            if (z == (IBASICcode.Length - 1) && IBASICcode[z].Contains(keyword2) == false)
                            {
                                errormessages.Add(" ENDFUNCTION is expected somewhere");
                            }
                            ///Put all the code within the function in a list called IBfunctionsNsub and remove that code 
                            ///from IBASICcode because it has to be put outside of VB main sub
                            IBfunctionsNsub.Add(IBASICcode[z]);
                            IBASICcode[z] = "";
                        }
                    }
                }
            }
        }
        public void Tprocedure()
        {
            string keyword1 = "PROCEDURE ";
            string keyword2 = "ENDPROCEDURE";
            string keyword3 = ":";
            for (int i = 0; i < IBASICcode.Length; i++)
            {
                if (IBASICcode[i].Contains(keyword1) == true)
                {
                    if (IBASICcode[i].TrimStart().Substring(0, 10) == keyword1)
                    {
                        IBASICcode[i] = IBASICcode[i].Replace(IBASICcode[i].TrimStart().Substring(0, 9), "Sub ");
                        if (IBASICcode[i].Contains(keyword3) == true)
                        {
                            IBASICcode[i] = IBASICcode[i].Replace(keyword3, " As ");
                        }
                        if (IBASICcode[i].Contains("(") == true && IBASICcode[i].Contains(keyword3) == false && IBASICcode[i].Contains(")") == true)
                        {
                            errormessages.Add("Line " + (i + 1) + " : Syntax error : Could be because datatype hasn't been specified");
                        }
                        for (int z = i; z < IBASICcode.Length; z++)
                        {

                            if (IBASICcode[z].Contains(keyword2) == true)
                            {
                                if (IBASICcode[z].TrimStart().Substring(0, 12) == keyword2)
                                {
                                    IBASICcode[z] = IBASICcode[z].Replace(keyword2, "End Sub");
                                    IBfunctionsNsub.Add(IBASICcode[z]);
                                    IBASICcode[z] = "";
                                    break;
                                }
                            }
                            if (z == (IBASICcode.Length - 1) && IBASICcode[z].Contains(keyword2) == false)
                            {
                                errormessages.Add(" ENDPROCEDURE is expected somewhere");
                            }
                            IBfunctionsNsub.Add(IBASICcode[z]);
                            IBASICcode[z] = "";
                        }
                    }
                }
            }
        }
        public void Tcallprocedure()
        {
            string keyword = "CALL ";
            for (int i = 0; i < IBASICcode.Length; i++)
            {
                if (IBASICcode[i].Contains(keyword) == true)
                {
                    if (IBASICcode[i].TrimStart().Substring(0, 5) == keyword)
                    {
                        IBASICcode[i] = IBASICcode[i].Replace(IBASICcode[i].TrimStart().Substring(0, 4), "Call ");
                    }
                }
            }

        }
        public void TtrueNfalse()
        {
            string keyword = "TRUE";
            string keyword2 = "FALSE";
            for (int i = 0; i < IBASICcode.Length; i++)
            {
                if (IBASICcode[i].Contains(keyword) == true)
                {

                    IBASICcode[i] = IBASICcode[i].Replace(keyword, "True");
                }
                if (IBASICcode[i].Contains(keyword2) == true)
                {

                    IBASICcode[i] = IBASICcode[i].Replace(keyword2, "False");
                }
            }
        }
        public void TranslateAll()
        {
            Tcomment();
            TdataType();
            TtrueNfalse();
            TvarDeclaration();
            TarrayDeclaration();
            T2dArrayDeclaration();
            TconstantDeclaration();
            Tarrays();
            Toutput();
            Tinput();
            TIfstatement();
            Twhileloop();
            TForloop();
            TrepeatUntil();
            Trandomfunc();
            Tmod();
            Tcallprocedure();
            Tcasestatement();
            Tfunction();
            Tprocedure();
            if (errormessages != null)
            {
                foreach (string msg in errormessages)
                {
                    errmsg = errmsg + msg + "\n";
                }
            }
        }
        public void putinFormat()
        {
            Translatedcode = Header;
            TranslateAll();
            foreach (string line in IBASICcode)
            {
                Translatedcode = Translatedcode + "\n" + line;
            }
            char qm = '"';
            Translatedcode = Translatedcode + "\n"  + "Console.WriteLine(" + qm + endmsg + qm + ")";
            Translatedcode = Translatedcode + "\n" + "Console.ReadKey()";
            Translatedcode = Translatedcode + "\n" + endSubMain;
            Translatedcode = Translatedcode + "\n" + VBdivfunction;
            Translatedcode = Translatedcode + "\n" + VBlengthfunction;
            Translatedcode = Translatedcode + "\n" + VBLcasefunction;
            Translatedcode = Translatedcode + "\n" + VBmodfunction;
            Translatedcode = Translatedcode + "\n" + VBUcasefunction;
            Translatedcode = Translatedcode + "\n" + VBsubstringfunction;
            Translatedcode = Translatedcode + "\n" + VBsubstringfunctionOVL;
            Translatedcode = Translatedcode + "\n" + VBroundfunction;
            foreach (string line in IBfunctionsNsub)
            {
                Translatedcode = Translatedcode + "\n" + line;
            }
            Translatedcode = Translatedcode + "\n" + endModule;
        }
        public string getTranslatedcode()
        {
            return Translatedcode;
        }
        public string getIBASICerrormessages()
        {

            return errmsg;
        }

   
    }
}


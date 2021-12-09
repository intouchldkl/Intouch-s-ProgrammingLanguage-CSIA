using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace CS_IA_Ibasic_Intouch_Re
{
    class IBASICtranslator
    {
        private string[] IBASICcode;
        private string Translatedcode;
        private string errmsg;
        TextInfo textinfo = new CultureInfo(0x040A, false).TextInfo;
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
        private const string Header = "Imports System" + "\n" + "Module Program" + "\n";
        private const string submain = "Sub Main(args As String())" + "\n";
        private const string endSubMain = "End Sub";
        private const string endModule = "End Module";
        private const string endmsg = "Press any key to continue";
        private const string VBrandomNFunction = "Function GETRANDOMNUMBER(min As Integer, max As Integer)" + "\n" + "Dim  random As New Random()" + "\n" + "Return random.Next(min,max)" + "\n" + "End Function";
        private const string VBConvertToStringFunction = "Function CONVERTTOSTRING(s As Integer)" + "\n" + "Return s.ToString" + "\n" + "End Function";
        private const string VBConvertToStringFunction2 = "Function CONVERTTOSTRING(s As Boolean)" + "\n" + "Return s.ToString" + "\n" + "End Function";
        private const string VBConvertToStringFunction3 = "Function CONVERTTOSTRING(s As Double)" + "\n" + "Return s.ToString" + "\n" + "End Function";
        private List<string> declarelines = new List<string>();
        private bool isLocal;
        private List<string> keywords;
 


        public object XmlFileManager { get; private set; }

        /// <summary>
        /// Constructor for IBASICtranslator class
        /// </summary>
        /// <param name="IBASICcode"></param>
        public IBASICtranslator(string[] IBASICcode)
        {
            this.IBASICcode = IBASICcode;
            if (File.Exists(@"C:\Users\ADMINS\Source\Repos\CS-IA-Ibasic-Intouch-Re\XMLsyntax.xml"))
            {
                XmlSerializer ser = new XmlSerializer(typeof(XMLdata.Syntax));
                XMLdata.Syntax syntax = new XMLdata.Syntax();
                using (XmlReader reader = XmlReader.Create(@"C:\Users\ADMINS\Source\Repos\CS-IA-Ibasic-Intouch-Re\XMLsyntax.xml"))
                {
                    syntax = (XMLdata.Syntax)ser.Deserialize(reader);
                }
                keywords = syntax.Array.Item;
                if (StringExtension.compare(syntax.IsLocal.ToString(), "True"))
                {
                    isLocal = true;
                }
                else
                {
                    isLocal = false;
                }

            }


        }
        public void Toutput(string keyword)
        {
            for (int i = 0; i < IBASICcode.Length; i++)
            {
                if (StringExtension.Contains(IBASICcode[i], keyword) == true)
                {
                    if (StringExtension.compare(IBASICcode[i].TrimStart().Substring(0, keyword.Length), keyword) == true)
                    {
                        IBASICcode[i] = IBASICcode[i].Replace(IBASICcode[i].TrimStart().Substring(0, 6), "Console.Write( ");
                        IBASICcode[i] = IBASICcode[i] + ")";

                    }
                }

            }
        }
        public void Toutputline(string keyword)
        {
            for (int i = 0; i < IBASICcode.Length; i++)
            {
                if (StringExtension.Contains(IBASICcode[i], keyword) == true)
                {
                    if (StringExtension.compare(IBASICcode[i].TrimStart().Substring(0, keyword.Length), keyword) == true)
                    {
                        IBASICcode[i] = IBASICcode[i].Replace(IBASICcode[i].TrimStart().Substring(0, keyword.Length-1), "Console.WriteLine( ");
                        IBASICcode[i] = IBASICcode[i] + ")";

                    }
                }

            }
        }
        public void Tclearoutput(string keyword)
        {
            for (int i = 0; i < IBASICcode.Length; i++)
            {
                if (StringExtension.Contains(IBASICcode[i], keyword) == true)
                {
                    if (StringExtension.compare(IBASICcode[i].TrimStart().Substring(0, keyword.Length), keyword) == true)
                    {
                        IBASICcode[i] = IBASICcode[i].Replace(IBASICcode[i].TrimStart().Substring(0, keyword.Length), "Console.Clear()");

                    }
                }
            }
        }
        public void Tinput(string keyword)
        {
            string line = "";
            for (int i = 0; i < IBASICcode.Length; i++)
            {
                if (StringExtension.Contains(IBASICcode[i], keyword) == true)
                {

                    line = IBASICcode[i].TrimStart();
                    ///This if statement makes sure "INPUT" is not part of a variable name
                    if (line.Substring(5) != null && StringExtension.compare(line.Substring(0, keyword.Length), keyword) == true)
                    {
                        string therest = line.Substring(keyword.Length);
                        therest = therest.Trim();
                        IBASICcode[i] = therest + " = " + "Console.ReadLine()";

                    }


                }
            }
        }

        public void TvarDeclaration(string keyword)
        {
            string keyword2 = ":";
            for (int i = 0; i < IBASICcode.Length; i++)
            {
                if (StringExtension.Contains(IBASICcode[i], keyword) == true)
                {
                    string arraycheck = string.Concat(IBASICcode[i].Where(c => !Char.IsWhiteSpace(c)));
                    ///This if statement makes sure "DECLARE" is not part of a variable name and its not array declaration
                    if (StringExtension.compare(IBASICcode[i].TrimStart().Substring(0, keyword.Length), keyword) == true && StringExtension.Contains(arraycheck, "ARRAY[") == false)
                    {
                        if (isLocal == false)
                        {
                            IBASICcode[i] = IBASICcode[i].Replace(IBASICcode[i].TrimStart().Substring(0, keyword.Length-1), "Public ");
                            string line = IBASICcode[i];
                            if (IBASICcode[i].Contains(keyword2) == true)
                            {
                                IBASICcode[i] = IBASICcode[i].Replace(keyword2, " As ");
                                declarelines.Add(IBASICcode[i]);
                                IBASICcode[i] = "";
                            }
                            else
                            {
                                errormessages.Add("Line " + (i + 1) + " : Syntax error : Could be because ':' is missing ");
                            }
                        }
                        else
                        {
                            IBASICcode[i] = IBASICcode[i].Replace(IBASICcode[i].TrimStart().Substring(0, keyword.Length-1), "Dim ");

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
        }

        /// <summary>
        /// Translate IBASIC array declaration to VB
        /// </summary>
        public void TarrayDeclaration(string keyword)
        {
            string line = "";
            for (int i = 0; i < IBASICcode.Length; i++)
            {
                ///get rid of all the spaces
                string arraycheck = string.Concat(IBASICcode[i].Where(c => !Char.IsWhiteSpace(c)));
                if (StringExtension.Contains(arraycheck, "ARRAY[") == true
                    && StringExtension.compare(IBASICcode[i].TrimStart().Substring(0, keyword.Length), keyword) == true)
                {
                    line = IBASICcode[i].Trim();
                    ///This if statement makes sure "DECLARE" is not part of a variable name and isa array declaration
                    if (line.Substring(keyword.Length-1, 1) == " " && IBASICcode[i].Contains(",") == false)
                    {
                        //Get rid of the word "Declare" as it's already checked out
                        string therest = line.Substring(keyword.Length - 1);
                        if (StringExtension.Contains(therest, "OF") == true && therest.Contains("]") == true)
                        {
                            therest = string.Concat(therest.Where(c => !Char.IsWhiteSpace(c)));
                            if (therest.Contains(":") == true)
                            {
                                //Split the variable name from the rest of its properties
                                string[] variablearray = therest.Split(':');
                                if (variablearray.Length == 3)
                                {
                                    string variableName = variablearray[0];
                                    //Split to get index and data type
                                    string[] indexandtype = Regex.Split(variablearray[2], @"(?i)[]of]+");
                                    if (indexandtype.Length == 2 && indexandtype[1] != "")
                                    {
                                        indexandtype[1] = indexandtype[1].Trim();
                                        //Check if the index is valid
                                        bool IsThereIndex = int.TryParse(indexandtype[0], out int index);
                                        if (IsThereIndex == true)
                                        {
                                            //Put the parts back in VB syntax
                                            IBASICcode[i] = "Dim " + variableName + "(" + index + ")" + " As " + indexandtype[1];
                                            arrayvar.Add(variableName);// Add to list for later use in arraytranslation
                                            if (isLocal == false)
                                            {
                                                string globaldeclare = "Public " + variableName + "()" + " As " + indexandtype[1];
                                                declarelines.Add(globaldeclare);
                                            }

                                        }
                                        else
                                        {
                                            //Invalid array index
                                            errormessages.Add("Line " + (i + 1) +
                                                " : Syntax error: could be because an idex is missing");
                                        }
                                    }
                                }
                            }
                            else
                            {
                                //Missing ":"
                                errormessages.Add("Line " + (i + 1) +
                                    " : Syntax error: could be because ':' is missing");
                            }
                        }
                        else
                        {
                            //Missing "OF" or "]"
                            errormessages.Add("Line " + (i + 1) +
                                " : Syntax error: could be because 'OF' or ']' is missing");
                        }
                    }

                }
            }
        }

        public void T2dArrayDeclaration(string keyword)
        {
            string line = "";
            for (int i = 0; i < IBASICcode.Length; i++)
            {

                ///get rid of all the spaces
                string arraycheck = string.Concat(IBASICcode[i].Where(c => !Char.IsWhiteSpace(c)));
                if (StringExtension.Contains(arraycheck, "ARRAY[") == true && StringExtension.compare(IBASICcode[i].TrimStart().Substring(0, keyword.Length), keyword) == true)
                {
                    line = IBASICcode[i].Trim();
                    ///This if statement makes sure "DECLARE" is not part of a variable name and isa array declaration
                    if (line.Substring(keyword.Length - 1, 1) == " " && IBASICcode[i].Contains(",") == true)
                    {

                        string therest = line.Substring(keyword.Length - 1);
                        if (StringExtension.Contains(therest, "OF") == true && therest.Contains("]") == true)
                        {
                            therest = string.Concat(therest.Where(c => !Char.IsWhiteSpace(c)));
                            if (therest.Contains(":") == true)
                            {
                                string[] variablearray = therest.Split(':');
                                if (variablearray.Length == 4)
                                {
                                    string variableName = variablearray[0];
                                    string[] uncutindex1 = variablearray[2].Split(',');
                                    string index1 = uncutindex1[0];
                                    string[] index2andtype = variablearray[3].Split(']');
                                    string type = index2andtype[1];
                                    string[] types = new string[2];
                                    types = Regex.Split(type, @"(?i)[f]+");
                                    if (types.Length == 2 && types[1] != "")
                                    {

                                        string index2 = index2andtype[0];
                                        IBASICcode[i] = "Dim " + variableName + "(" + index1 + ", " + index2 + ")" + " As " + types[1];
                                        arrayvar.Add(variableName);
                                        if (isLocal == false)
                                        {
                                            string globaldeclare = "Public " + variableName + "(1000,1000)" + " As " + types[1];
                                            declarelines.Add(globaldeclare);
                                        }

                                    }
                                    else
                                    {
                                        errormessages.Add("Line " + (i + 1) + " : Syntax error: could be because data type is missing");
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

        public void TForloop(string keyword1, string keyword2, string keyword3, string keyword4)
        {

            for (int i = 0; i < IBASICcode.Length; i++)
            {
                if (StringExtension.Contains(IBASICcode[i], keyword1) == true)
                {
                    if (StringExtension.compare(IBASICcode[i].TrimStart().Substring(0, keyword1.Length), keyword1) == true)
                    {
                        IBASICcode[i] = IBASICcode[i].Replace(IBASICcode[i].Trim().Substring(0, keyword1.Length-1), "For ");
                        if (StringExtension.Contains(IBASICcode[i], keyword3) == true)
                        {
                            IBASICcode[i] = Regex.Replace(IBASICcode[i], @"\b(?i)( TO )\b", " To ");
                        }
                        else
                        {
                            errormessages.Add("Line " + (i + 1) + " : Syntax error : Could be becuase 'TO' is missing or incorrect spacing");
                        }

                        if (StringExtension.Contains(IBASICcode[i], keyword4) == true)
                        {
                            IBASICcode[i] = Regex.Replace(IBASICcode[i], @"\b(?i)( STEP)\b", " Step ");
                        }
                        for (int z = i; z < IBASICcode.Length; z++)
                        {
                            if (StringExtension.Contains(IBASICcode[z], keyword2) == true)
                            {
                                if (StringExtension.compare(IBASICcode[z].TrimStart().Substring(0, keyword2.Length), keyword2) == true)
                                {
                                    IBASICcode[z] = IBASICcode[z].Replace(IBASICcode[z].Trim(), "Next ");
                                }
                                break;
                            }
                            if (z == (IBASICcode.Length - 1) && StringExtension.Contains(IBASICcode[z], keyword2) == false)
                            {
                                errormessages.Add("Syntax error : NEXT or an identifier is expected somewhere ");
                            }
                        }
                    }
                }

            }
        }
        public void TIfstatement(string keyword1, string keyword2, string keyword3,
            string keyword4, string keyword5, string keyword6, string keyword7)
        {

            for (int i = 0; i < IBASICcode.Length; i++)
            {
                if (StringExtension.Contains(IBASICcode[i], keyword1) == true)
                {
                    if (StringExtension.compare(IBASICcode[i].TrimStart().Substring(0, keyword1.Length), keyword1) == true)
                    {
                        IBASICcode[i] = IBASICcode[i].Replace(IBASICcode[i].TrimStart().Substring(0, keyword1.Length-1), "If ");
                        if (StringExtension.Contains(IBASICcode[i], keyword5) == true)
                        {
                            IBASICcode[i] = Regex.Replace(IBASICcode[i], @"\b(?i)( THEN)\b", " Then ");
                        }
                        else
                        {
                            errormessages.Add("Line " + (i + 1) + " : Syntax error : Could be because 'THEN' is expected or incorrect spacing");
                        }
                        if (StringExtension.Contains(IBASICcode[i], keyword6) == true)
                        {
                            IBASICcode[i] = Regex.Replace(IBASICcode[i], @"\b(?i)(AND)\b", " And ");
                        }
                        if (StringExtension.Contains(IBASICcode[i], keyword7) == true)
                        {
                            IBASICcode[i] = Regex.Replace(IBASICcode[i], @"\b(?i)(OR)\b", " or ");
                        }
                        for (int z = i; z < IBASICcode.Length; z++)
                        {
                            if (StringExtension.Contains(IBASICcode[z], keyword2) == true)
                            {
                                if (StringExtension.compare(IBASICcode[z].TrimStart().Substring(0, keyword2.Length), keyword2) == true)
                                {
                                    IBASICcode[z] = Regex.Replace(IBASICcode[z], @"\b(?i)(ENDIF)\b", "End If");
                                }
                                break;
                            }
                            if (z == (IBASICcode.Length - 1) && StringExtension.Contains(IBASICcode[z], keyword2) == false)
                            {
                                errormessages.Add("Syntax error : ENDIF is expected somewhere");
                            }
                        }
                    }
                }
                if (StringExtension.Contains(IBASICcode[i], keyword3) == true)
                {
                    if (StringExtension.compare(IBASICcode[i].TrimStart().Substring(0, keyword3.Length), keyword3) == true)
                    {
                        IBASICcode[i] = IBASICcode[i].Replace(IBASICcode[i].TrimStart().Substring(0, keyword3.Length-1), "ElseIf ");
                        if (StringExtension.Contains(IBASICcode[i], keyword5) == true)
                        {
                            IBASICcode[i] = Regex.Replace(IBASICcode[i], @"\b(?i)( THEN)\b", " Then ");
                        }
                        else
                        {
                            errormessages.Add("Line " + (i + 1) + " : Syntax error : Could be because 'THEN' is expected or incorrect spacing");
                        }
                    }
                }
                if (StringExtension.Contains(IBASICcode[i], keyword4) == true)
                {
                    if (StringExtension.compare(IBASICcode[i].TrimStart().Substring(0, keyword4.Length), keyword4) == true)
                    {
                        IBASICcode[i] = Regex.Replace(IBASICcode[i], @"\b(?i)(ELSE)\b", "Else ");
                    }
                }

            }
        }

        public void Twhileloop(string keyword1, string keyword2, string keyword3)
        {
            for (int i = 0; i < IBASICcode.Length; i++)
            {
                if (StringExtension.Contains(IBASICcode[i], keyword1) == true)
                {
                    if (StringExtension.compare(IBASICcode[i].TrimStart().Substring(0, keyword1.Length), keyword1) == true)
                    {
                        IBASICcode[i] = IBASICcode[i].Replace(IBASICcode[i].TrimStart().Substring(0, keyword1.Length-1), "While ");
                        if (StringExtension.Contains(IBASICcode[i], keyword3) == true)
                        {
                            IBASICcode[i] = Regex.Replace(IBASICcode[i], @"\b(?i)(DO)\b", " ");
                        }
                        else
                        {
                            errormessages.Add("Line " + (i + 1) + " : Syntax error : Could be because 'DO' is expected or incorrect spacing");
                        }
                        for (int z = i; z < IBASICcode.Length; z++)
                        {
                            if (StringExtension.Contains(IBASICcode[z], keyword2) == true)
                            {
                                if (StringExtension.compare(IBASICcode[z].TrimStart().Substring(0, keyword2.Length), keyword2) == true)
                                {
                                    IBASICcode[z] = Regex.Replace(IBASICcode[z], @"\b(?i)(ENDWHILE)\b", "End While");
                                }
                                break;
                            }
                            if (z == (IBASICcode.Length - 1) && StringExtension.Contains(IBASICcode[z], keyword2) == false)
                            {
                                errormessages.Add("Syntax error : ENDWHILE is expected somewhere");
                            }
                        }
                    }
                }
            }
        }
        public void TrepeatUntil(string keyword1,string keyword2)
        {
            for (int i = 0; i < IBASICcode.Length; i++)
            {
                if (StringExtension.Contains(IBASICcode[i], keyword1) == true)
                {
                    if (StringExtension.compare(IBASICcode[i].TrimStart().Substring(0, keyword1.Length), keyword1) == true)
                    {
                        IBASICcode[i] = IBASICcode[i].Replace(IBASICcode[i].TrimStart().Substring(0, keyword1.Length), "Do");
                        for (int z = i; z < IBASICcode.Length; z++)
                        {
                            if (StringExtension.Contains(IBASICcode[z], keyword2) == true)
                            {
                                if (StringExtension.compare(IBASICcode[z].TrimStart().Substring(0, keyword2.Length), keyword2) == true)
                                {
                                    IBASICcode[z] = IBASICcode[z].Replace(IBASICcode[z].TrimStart().Substring(0, keyword2.Length-1), "Loop Until ");
                                }
                                break;
                            }
                            if (z == (IBASICcode.Length - 1) && StringExtension.Contains(IBASICcode[z], keyword2) == false)
                            {
                                errormessages.Add("Syntax error : UNTIL or UNTIL condition is expected somewhere ");
                            }
                        }
                    }

                }

            }
        }
        public void TconstantDeclaration(string keyword1)
        {
            for (int i = 0; i < IBASICcode.Length; i++)
            {
                if (StringExtension.Contains(IBASICcode[i], keyword1) == true)
                {
                    if (StringExtension.compare(IBASICcode[i].TrimStart().Substring(0, keyword1.Length), keyword1) == true)
                    {
                        IBASICcode[i] = IBASICcode[i].Replace(IBASICcode[i].TrimStart().Substring(0, keyword1.Length-1), "Public Const ");
                        declarelines.Add(IBASICcode[i]);
                        IBASICcode[i] = "";
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
                    // IBASICcode[i] = IBASICcode[i].Replace(keyword1, "'");
                    string[] stringSeparators = new string[] { keyword1 };
                    string[] splitstring = IBASICcode[i].Split(stringSeparators, StringSplitOptions.None);
                    IBASICcode[i] = splitstring[0];
                }
            }
        }
        public void TdataType(string[] keywords)
        {
            for (int i = 0; i < IBASICcode.Length; i++)
            {
                foreach (string keyword in keywords)
                {
                    if (StringExtension.compare("REAL", keyword) == true)
                    {
                        IBASICcode[i] = Regex.Replace(IBASICcode[i], @"\b(?i)(REAL)\b", "Double");
                    }
                    else if (StringExtension.Contains(IBASICcode[i], keyword))
                    {
                        IBASICcode[i] = IBASICcode[i].Replace(keyword, textinfo.ToTitleCase(keyword));

                    }
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
                        if (IBASICcode[i].Contains(arrayname + "[") == true)
                        {
                            if (IBASICcode[i].Contains(keyword1) == true)
                            {
                                IBASICcode[i] = IBASICcode[i].Replace(keyword1, "(");
                            }
                            else if (IBASICcode[i].Contains(keyword1) == false && IBASICcode[i].Contains("(") == false)
                            {
                                errormessages.Add("Line " + (i + 1) + " : Syntax error " + arrayname + " is an array and '[' is expected");
                            }
                            if (IBASICcode[i].Contains(keyword2) == true)
                            {
                                IBASICcode[i] = IBASICcode[i].Replace(keyword2, ")");
                            }
                            else if (IBASICcode[i].Contains(keyword2) == false && IBASICcode[i].Contains(")") == false)
                            {
                                errormessages.Add("Line " + (i + 1) + " : Syntax error " + arrayname + " is an array and ']' is expected");
                            }
                            if (IBASICcode[i].Contains(")(") == true)
                            {
                                IBASICcode[i] = IBASICcode[i].Replace(")(", ",");
                            }

                        }
                }
            }
        }
        public void Tcasestatement(string keyword1, string keyword2, string keyword3, string keyword5)
        {
            string keyword4 = ":";
            for (int i = 0; i < IBASICcode.Length; i++)
            {
                if (StringExtension.Contains(IBASICcode[i], keyword1) == true)
                {
                    if (StringExtension.compare(IBASICcode[i].TrimStart().Substring(0, keyword1.Length), keyword1) == true)
                    {
                        IBASICcode[i] = IBASICcode[i].Replace(IBASICcode[i].TrimStart().Substring(0, keyword1.Length-1), "Select Case ");
                        for (int z = i; z < IBASICcode.Length; z++)
                        {
                            if (StringExtension.Contains(IBASICcode[z], keyword5) == true)
                            {
                                if (StringExtension.compare(IBASICcode[z].TrimStart().Substring(0, keyword5.Length), keyword5) == true)
                                {
                                    IBASICcode[z] = IBASICcode[z].Replace(IBASICcode[z].TrimStart().Substring(0, keyword5.Length), "End Select ");
                                }
                                break;
                            }
                            if (StringExtension.Contains(IBASICcode[z], keyword2) == true)
                            {
                                if (StringExtension.compare(IBASICcode[z].TrimStart().Substring(0, keyword2.Length), keyword2) == true)
                                {
                                    IBASICcode[z] = IBASICcode[z].Replace(IBASICcode[z].TrimStart().Substring(0, keyword2.Length-1), "Case ");
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
                            if (StringExtension.Contains(IBASICcode[z], keyword3) == true)
                            {
                                if (StringExtension.compare(IBASICcode[z].TrimStart().Substring(0, keyword3.Length), keyword3) == true)
                                {
                                    IBASICcode[i] = IBASICcode[i].Replace(IBASICcode[i].TrimStart().Substring(0, keyword3.Length-1), "Case Else " + "\n");
                                }

                            }
                            if (z == (IBASICcode.Length - 1) && StringExtension.Contains(IBASICcode[z], keyword5) == false)
                            {
                                errormessages.Add("Syntax error : ENDCASE is expected somewhere ");
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Translate IBASIC function to VB
        /// </summary>
        public void Tfunction(string keyword1, string keyword2, string keyword3, string keyword5)
        {
            //All keywords
            string keyword4 = ":";
            for (int i = 0; i < IBASICcode.Length; i++)
            {
                if (StringExtension.Contains(IBASICcode[i], keyword1) == true)
                {
                    //Check if if the first word is keyword1
                    if (StringExtension.compare(IBASICcode[i].TrimStart().Substring(0, keyword1.Length), keyword1) == true)
                    {
                        //Translate keyword1
                        IBASICcode[i] = IBASICcode[i].Replace(IBASICcode[i].TrimStart().Substring(0, keyword1.Length-1), "Function");
                        //Repeat the process for other keyword
                        if (IBASICcode[i].Contains(keyword4) == true)
                        {
                            IBASICcode[i] = IBASICcode[i].Replace(keyword4, " As ");
                        }
                        if (StringExtension.Contains(IBASICcode[i], keyword5) == true)
                        {
                            //Use regex (?i) means case insensitive
                            IBASICcode[i] = Regex.Replace(IBASICcode[i], @"\b(?i)(RETURNS)\b", " As ");
                        }
                        else
                        {
                            errormessages.Add("Line " + (i + 1) +
                                " 'RETURNS' is expected, Return data type must be specified");
                        }
                        //When the declaration line is checked out
                        //Loop until ENDFUNCTION is found
                        for (int z = i; z < IBASICcode.Length; z++)
                        {
                            //Check and translate
                            if (StringExtension.Contains(IBASICcode[z], keyword3) == true)
                            {
                                IBASICcode[z] = Regex.Replace(IBASICcode[z], @"\b(?i)(RETURN)\b", textinfo.ToTitleCase(keyword3));
                            }
                            //When keyword2 is found means the function has been closed
                            if (StringExtension.compare(IBASICcode[z].TrimStart().Substring(0, keyword2.Length), keyword2) == true)
                            {
                                IBASICcode[z] = Regex.Replace(IBASICcode[z], @"\b(?i)(ENDFUNCTION)\b", "End Function");
                                //Store the line in a list
                                IBfunctionsNsub.Add(IBASICcode[z]);
                                //Remove the line from the main body
                                IBASICcode[z] = "";
                                //Stop the process when ENDFUNCTION is found
                                break;
                            }
                            //If it reaches the end and keyword2 is still not found
                            //then add an error message
                            if (z == (IBASICcode.Length - 1) && StringExtension.Contains(IBASICcode[z], keyword2) == false)
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
        public void Tprocedure(string keyword1, string keyword2)
        {

            string keyword3 = ":";
            for (int i = 0; i < IBASICcode.Length; i++)
            {
                if (StringExtension.Contains(IBASICcode[i], keyword1) == true)
                {
                    if (StringExtension.compare(IBASICcode[i].TrimStart().Substring(0, keyword1.Length), keyword1) == true)
                    {
                        IBASICcode[i] = IBASICcode[i].Replace(IBASICcode[i].TrimStart().Substring(0, keyword1.Length-1), "Sub ");
                        if (IBASICcode[i].Contains(keyword3) == true)
                        {
                            IBASICcode[i] = IBASICcode[i].Replace(keyword3, " As ");
                        }

                        for (int z = i; z < IBASICcode.Length; z++)
                        {

                            if (StringExtension.Contains(IBASICcode[z], keyword2) == true)
                            {
                                if (StringExtension.compare(IBASICcode[z].TrimStart().Substring(0, keyword2.Length), keyword2) == true)
                                {
                                    IBASICcode[z] = IBASICcode[z].Replace(IBASICcode[z].TrimStart().Substring(0, keyword2.Length), "End Sub");
                                    IBfunctionsNsub.Add(IBASICcode[z]);
                                    IBASICcode[z] = "";
                                    break;
                                }
                            }
                            if (z == (IBASICcode.Length - 1) && StringExtension.Contains(IBASICcode[z], keyword2) == false)
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
        public void Tcallprocedure(string keyword)
        {

            for (int i = 0; i < IBASICcode.Length; i++)
            {
                if (StringExtension.Contains(IBASICcode[i], keyword) == true)
                {
                    if (StringExtension.compare(IBASICcode[i].TrimStart().Substring(0, keyword.Length), keyword) == true)
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
                if (StringExtension.Contains(IBASICcode[i], keyword) == true)
                {

                    IBASICcode[i] = Regex.Replace(IBASICcode[i], @"\b(?i)(TRUE)\b", "True");
                }
                if (StringExtension.Contains(IBASICcode[i], keyword2) == true)
                {

                    IBASICcode[i] = Regex.Replace(IBASICcode[i], @"\b(?i)(FALSE)\b", "False");
                }
            }
        }
        public void Tchar()
        {
            string pattern = "\'.+?\'";
            for (int i = 0; i < IBASICcode.Length; i++)
            {
                MatchCollection stringMatches = Regex.Matches(IBASICcode[i], pattern);
                foreach (Match m in stringMatches)
                {
                    string temp = m.ToString().Replace("'", "\"");
                    temp = temp + "c";
                    IBASICcode[i] = IBASICcode[i].Replace(m.ToString(), temp);
                }
            }
        }
        /// <summary>
        /// Call all translation methods
        /// </summary>
        public void TranslateAll()
        {
            Tcomment();
            TdataType(getDataTypes());
            TtrueNfalse();
            TvarDeclaration(keywords[3]);
            TarrayDeclaration(keywords[3]);
            T2dArrayDeclaration(keywords[3]);
            TconstantDeclaration(keywords[37]);
            Tchar();
            Tarrays();
            Toutput(keywords[0]);
            Toutputline(keywords[1]);
            Tclearoutput(keywords[36]);
            Tinput(keywords[2]);
            TIfstatement(keywords[17], keywords[21], keywords[20], keywords[19], keywords[18], keywords[25], keywords[26]);
            Twhileloop(keywords[14], keywords[16], keywords[15]);
            TForloop(keywords[11], keywords[13], keywords[12], keywords[22]);
            TrepeatUntil(keywords[38],keywords[39]);
            Trandomfunc();
            Tmod();
            Tcallprocedure(keywords[35]);
            Tcasestatement(keywords[23], keywords[24], keywords[27], keywords[28]);
            Tfunction(keywords[29], keywords[32], keywords[31], keywords[30]);
            Tprocedure(keywords[33], keywords[34]);
            if (errormessages != null)
            {
                foreach (string msg in errormessages)
                {
                    errmsg = errmsg + msg + "\n";
                }
            }
        }
        /// <summary>
        /// Translate IBASIC code and put it in VB format
        /// </summary>
        public void putinFormat()
        {
            //Put in Imports System and  Module Program
            Translatedcode = Header;
            //Call all the IBASIC-VB translation methods
            TranslateAll();
            //Put in all the variable declarations
            foreach (string line in declarelines)
            {
                Translatedcode = Translatedcode + line + "\n";
            }
            //Put in Sub Main(args As String())
            Translatedcode = Translatedcode + submain;
            //Put in all the main translated code
            foreach (string line in IBASICcode)
            {
                Translatedcode = Translatedcode + "\n" + line;
            }
            //Put all the built-in functions
            Translatedcode = Translatedcode + "\n" + "Console.WriteLine(" + "\"" + endmsg + "\"" + ")";
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
            Translatedcode = Translatedcode + "\n" + VBrandomNFunction;
            Translatedcode = Translatedcode + "\n" + VBConvertToStringFunction;
            Translatedcode = Translatedcode + "\n" + VBConvertToStringFunction2;
            Translatedcode = Translatedcode + "\n" + VBConvertToStringFunction3;
            //Put in user-written functions or procedures
            foreach (string line in IBfunctionsNsub)
            {
                Translatedcode = Translatedcode + "\n" + line;
            }
            //Put in end module
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
        private string[] getDataTypes()
        {
            string[] types = new string[5];
            for (int i = 0; i < types.Length; i++)
            {
                types[i] = keywords[4 + i];
            }
            return types;
        }





    }
}


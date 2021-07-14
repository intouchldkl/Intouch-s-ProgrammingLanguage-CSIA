using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Microsoft.VisualBasic;

namespace CS_IA_Ibasic_Intouch_Re
{
    class Compiler
    {
        private VBCodeProvider codeprovider;
        private CompilerParameters parameters;
        private string codeToCompile;
        private string output;
        private string ErrorMessage;

        public Compiler(string codeToCompile)
        {
            this.codeToCompile = codeToCompile;
            codeprovider = new VBCodeProvider();
            parameters = new CompilerParameters();

        }

        public void launchEXE()
        {
            output = "out.exe";
            ///Make sure to generate an EXE, not a DLL
            parameters.GenerateExecutable = true;
            parameters.OutputAssembly = output;
            CompilerResults results = codeprovider.CompileAssemblyFromSource(parameters, codeToCompile);
            if (results.Errors.Count > 0)
            {

                foreach (CompilerError CompErr in results.Errors)
                {
                    getErrorMessages(CompErr);
                }
            }
            else
            {
                Process.Start(output);
            }

        }
        public string getErrorMessages(CompilerError CompErr)
        {
            ErrorMessage = "Line number " + CompErr.Line + ", Error Number: " + CompErr.ErrorNumber +
             ", '" + CompErr.ErrorText + ";" + Environment.NewLine + Environment.NewLine; ;
            return ErrorMessage;
        }

    }
}

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
        private CompilerResults results;
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
             results = codeprovider.CompileAssemblyFromSource(parameters, codeToCompile);
       
                Process.Start(output);
            

        }
        public string getErrorMessages()
        {
            foreach (CompilerError CompErr in results.Errors)
            {
                ErrorMessage = "Line number " + CompErr.Line + ", Error Number: " + CompErr.ErrorNumber +
             ", '" + CompErr.ErrorText + ";" + Environment.NewLine + Environment.NewLine; ;
                
            }
            return ErrorMessage;
        }

    }
}

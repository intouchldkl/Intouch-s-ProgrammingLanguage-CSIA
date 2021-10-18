using System.CodeDom.Compiler;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.IO;
using System.Management.Automation;
using Microsoft.Win32;
using System;
using System.Threading;
using System.Management.Automation.Runspaces;
namespace CS_IA_Ibasic_Intouch_Re
{
    class Compiler
    {
        private VBCodeProvider codeprovider;
        private CompilerParameters parameters;
        private CompilerResults results;
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
            Process myprocess = new Process();
            output = "out.exe";
            ///Make sure to generate an EXE, not a DLL
            parameters.GenerateExecutable = true;
            parameters.OutputAssembly = output;
            results = codeprovider.CompileAssemblyFromSource(parameters, codeToCompile);
            if (results.Errors.Count == 0)
            {              
                myprocess.StartInfo.FileName = output;
                myprocess.Start();
      
            }
            else
            {
                foreach (CompilerError CompErr in results.Errors)
                {
                    string[] VBmsg = CompErr.ErrorText.Split('.');

                    ErrorMessage = ErrorMessage + " VBcompile error:  may be because of " +
                         VBmsg[0] + "\n";

                }
            }

        }
        public string getErrorMessages()
        {
            return ErrorMessage;
        }


    }
}

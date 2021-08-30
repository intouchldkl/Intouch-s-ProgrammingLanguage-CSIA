using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.IO;

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
            Process myprocess = new Process();
            output = "out.exe";
            ///Make sure to generate an EXE, not a DLL
            parameters.GenerateExecutable = true;
            parameters.OutputAssembly = output;
            parameters.TempFiles.KeepFiles = true;
            parameters.TempFiles.AddFile(output, true);
            results = codeprovider.CompileAssemblyFromSource(parameters, codeToCompile);
            if (results.Errors.Count == 0)
            {
                myprocess.StartInfo.FileName = output;
                myprocess.Start();
                myprocess.WaitForExit(1000);
                IBASICForm.Instance.CaptureMyScreen();
 
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

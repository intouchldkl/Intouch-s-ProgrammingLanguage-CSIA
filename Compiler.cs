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
        /// <summary>
        /// Compile VB code and output in EXE file
        /// </summary>
        public void launchEXE()
        {
            Process myprocess = new Process();
            output = "out.exe";
            ///Make sure to generate an EXE, not a DLL
            parameters.GenerateExecutable = true;
            parameters.OutputAssembly = output;
            //Compile the code..
            results = codeprovider.CompileAssemblyFromSource(parameters, codeToCompile);
            if (results.Errors.Count == 0)//If there's no error then..
            {              
                myprocess.StartInfo.FileName = output;
                //Launch EXE file
                myprocess.Start();      
            }
            else
            {
                foreach (CompilerError CompErr in results.Errors)
                {
                    //Get only the relevant message
                    string[] VBmsg = CompErr.ErrorText.Split('.');
                    ErrorMessage = ErrorMessage + " VBcompile error: " +
                         VBmsg[0] + "\n";
                }
            }

        }
        /// <summary>
        /// Accessor to VB provided error messages
        /// </summary>
        /// <returns></returns>VB eror messages
        public string getErrorMessages()
        {
            return ErrorMessage;
        }


    }
}

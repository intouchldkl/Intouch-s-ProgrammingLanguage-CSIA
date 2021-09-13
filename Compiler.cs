using System.CodeDom.Compiler;
using System.Diagnostics;
using Microsoft.VisualBasic;
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
            results = codeprovider.CompileAssemblyFromSource(parameters, codeToCompile);
            if (results.Errors.Count == 0)
            {

                /*

                string MyCommand = "PS > Get - Process - Name MyFile | Out - File - Path C:\\Foo\\MyFile.txt";
                string MyCommand2 = "PS> Get-Content -Path C:\\Foo\\MyFile.txt";

                ProcessStartInfo MyProcInfo = new ProcessStartInfo();
                MyProcInfo.FileName = output;
                MyProcInfo.Arguments = MyCommand;
                MyProcInfo.Arguments = MyCommand2;

                Process MyProcess = new Process();
                MyProcess.StartInfo = MyProcInfo;
                MyProcess.Start();
                MyProcess.WaitForExit();
                
                var lines = File.ReadLines("C:\\Foo\\MyFile.txt");
 
                StreamWriter sw = new StreamWriter("out.txt");
                foreach (var line in lines)
                    {
                    sw.WriteLine(line);
                    }
                sw.Close();

                    myprocess.StartInfo.FileName = output;
                   myprocess.StartInfo.UseShellExecute = false;
                  myprocess.StartInfo.RedirectStandardOutput = true;
                    myprocess.Start();
                   myprocess.WaitForExit();
                  string outputtext = myprocess.StandardOutput.ReadToEnd();
                 StreamWriter sw = new StreamWriter("out.txt");
                   sw.WriteLine(line);


                 sw.Close();*/
                myprocess.StartInfo.FileName = output;
                myprocess.Start();
              //  myprocess.WaitForExit();
                /*
                Runspace runspace = RunspaceFactory.CreateRunspace();
                runspace.Open();
                Pipeline pipeline = runspace.CreatePipeline();
                Command command = new Command(@"C:\Users\ADMINS\Dropbox\My PC (DESKTOP-QFR4487)\Desktop\command.ps1");
           //     Command command1 = new Command("Set - ExecutionPolicy unrestricted");
             //   Command command2 = new Command("PS> Get-Content -Path C:\\Foo\\out.txt");
             //   pipeline.Commands.Add(command1);
                pipeline.Commands.Add(command);
                pipeline.Invoke();
                runspace.Close();*/

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

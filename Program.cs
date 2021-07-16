using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_IA_Ibasic_Intouch_Re
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IBASICForm IBASICform = new IBASICForm();
            GGDrive ggdrive = new GGDrive();

            Application.Run(IBASICform);

            
        }
    }
}

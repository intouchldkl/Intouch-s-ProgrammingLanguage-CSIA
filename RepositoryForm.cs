using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS_IA_Ibasic_Intouch_Re
{
    public partial class RepositoryForm : Form
    {
        private GGDriveFile[] DriveFiles;
        private string[] fileNames;
        public RepositoryForm()
        {
            InitializeComponent();
            GGDrive.Instance.Authentication();          
            DriveFiles = GGDrive.Instance.retrieveFile();
            for (int i = 0; i < DriveFiles.Length; i++)
            {
                ///FilelistView.Items.Add(DriveFiles[i].Name);
            }
        }

       
    }
}

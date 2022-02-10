using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CS_IA_Ibasic_Intouch_Re
{
    public partial class RepositoryForm : Form
    {
        RichTextBox currentRtb;
        TabPage tabPage;
        public RepositoryForm()
        {
            InitializeComponent();
            GGDrive.Instance.Authentication();
            displayAllFiles();       
        }
        /// <summary>
        /// Get all the non duplicate file names from IBASIC folder and display them on a list view
        /// </summary>
        public void displayAllFiles()
        {
            
            if (GGDrive.Instance.checkForIBasicFolder() == true)
            {
                if (GGDrive.Instance.retrieveFile() != null)
                {
                    var displayFileNames = GGDrive.Instance.getDisplayFileNames();
                    foreach (var FileName in displayFileNames)
                    {
                        string fileName = FileName.Name;
                        if (fileName.Contains(".txt") == true)
                        {
                            fileName = fileName.Replace(".txt", "");
                        }                   
                        var LVI = new ListViewItem(fileName);
                        FilelistView.Items.Add(LVI);
                        LVI.Tag = FileName.Name;
                    }

                }

            }
            


        }

     
        /// <summary>
        /// Display the version when the display file is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FilelistView_Click(object sender, EventArgs e)
        {
            VersionListView.Clear();
            displayVersionFiles();            
        }
        /// <summary>
        /// Get the number of duplicate files(version files) within the selected file name
        /// </summary>
        private void displayVersionFiles()
        {
            string FileName = (string)FilelistView.SelectedItems[0].Tag ;
            var AllVersionFiles = GGDrive.Instance.getVersionFiles(FileName); 
            int i = AllVersionFiles.Count;
            foreach (var version in AllVersionFiles)
            {
                if(FileName.Contains(".txt") == true)
                {
                    FileName = FileName.Remove(FileName.Length - 4);
                }
                string time = version.createdTime.ToString();
                var row = new string[] { "Version " + i, time };
                i--;
                var LVI = new ListViewItem(row);
                LVI.Text = FileName + "-" + LVI.Text + "     " + time;
                LVI.Tag = version;
                VersionListView.Items.Add(LVI);
            }
        }
        /// <summary>
        /// Perform download file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VersionListView_Click(object sender, EventArgs e)
        {
            downloadFile();
            Close();
        }
        /// <summary>
        /// download the file from the version file clicked and display on the coding box
        /// </summary>
        private void downloadFile()
        {
            GGDriveFile GFlie = (GGDriveFile)VersionListView.SelectedItems[0].Tag;
            string fileId = GFlie.Id;
            openFileDialog1.FileName = GGDrive.Instance.DownloadGoogleFile(fileId);
            string tabname = openFileDialog1.FileName;
            if (tabname.Contains(".txt") == true)
            {
                tabname = tabname.Remove(tabname.Length - 4);
                
            }
            IBASICForm.Instance.createNewTabPage(tabname);
            currentRtb = IBASICForm.Instance.getCurrentRtb();
            tabPage = IBASICForm.Instance.getCurrentTabpage();
            using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
            {
                RichTextBox buffer = new RichTextBox();
                currentRtb.Text = sr.ReadToEnd();
                buffer.Rtf = currentRtb.Rtf; //Using a buffer to prevent flickering
                IBASICForm.Instance.syntaxhighlightall(buffer);
                currentRtb.Rtf = buffer.Rtf;
                sr.Close();
            }
        }
    }
}

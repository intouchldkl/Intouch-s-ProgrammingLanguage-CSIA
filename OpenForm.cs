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
    public partial class OpenForm : Form
    {
        RichTextBox currentRtb;
        TabPage tabPage;
        public OpenForm()
        {
            InitializeComponent();
            if(IBASICForm.Instance.isLogin() == true)
            {
                DriveButton.Enabled = true;
            }
        }
        /// <summary>
        /// Open local drive
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LocalDButton_Click(object sender, EventArgs e)
        {
            openFileFromLocalD();
        }
        /// <summary>
        /// Open repository form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DriveButton_Click(object sender, EventArgs e)
        {
            RepositoryForm repos = new RepositoryForm();
            Close();
            repos.Show();
            
        }
        /// <summary>
        /// Open and read file from local drive to coding box
        /// </summary>
        private void openFileFromLocalD()
        {
            // Open file 

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                IBASICForm.Instance.createNewTabPage(openFileDialog1.SafeFileName);
                currentRtb = IBASICForm.Instance.getCurrentRtb();
                tabPage = IBASICForm.Instance.getCurrentTabpage();
                //  read file
                using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                {
                    RichTextBox buffer = new RichTextBox();
                    currentRtb.Text = sr.ReadToEnd();
                    buffer.Rtf = currentRtb.Rtf;
                    IBASICForm.Instance.syntaxhighlightall(buffer);
                    currentRtb.Rtf = buffer.Rtf;
                    sr.Close();
                }
                Close();

            }
        }
    }
}

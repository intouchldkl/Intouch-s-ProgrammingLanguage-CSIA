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
    public partial class SaveAsForm : Form
    {
        RichTextBox currentRtb;
        TabPage tabpage;
        public SaveAsForm()
        {
            InitializeComponent();
            this.currentRtb = IBASICForm.Instance.getCurrentRtb();
            this.tabpage = IBASICForm.Instance.getCurrentTabpage();
            if (IBASICForm.Instance.isLogin() == true)
            {
                GDriveBut.Enabled = true;
            }
        }

        private void LocalDBut_Click(object sender, EventArgs e)
        {
            savetoLocalD();
        }

        private void savetoLocalD()
        {
            if(tabpage.Text.Last() == '*')
            {
                saveFileDialog1.FileName = tabpage.Text.Remove(tabpage.Text.Length - 1);
            }
            else
            {
                saveFileDialog1.FileName = tabpage.Text;
            }
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tabpage.Text = Path.GetFileNameWithoutExtension(saveFileDialog1.FileName);
                StreamWriter CodeToBeSaved = new StreamWriter(saveFileDialog1.FileName + ".txt");
                CodeToBeSaved.Write(currentRtb.Text);
                CodeToBeSaved.Close();
                Close();
            }
        }

        private void GDrivebut_Click(object sender, EventArgs e)
        {
            SaveToDriveForm SaveDriveForm = new SaveToDriveForm();
            SaveDriveForm.Show();
            Close();

        }
    }
}

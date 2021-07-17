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
    public partial class SaveToDriveForm : Form
    {
        RichTextBox currentRtb = new RichTextBox();
        public SaveToDriveForm(RichTextBox currentRtb)
        {
            InitializeComponent();
            this.currentRtb = currentRtb;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (GGDrive.Instance.checkForIBasicFolder() == false)
            {
                GGDrive.Instance.CreateIBASICFolder("IBASIC-FOLDER");
            }

            saveFileDialog1.FileName = FileNameBox.Text;
            StreamWriter CodeToBeSaved = new StreamWriter(saveFileDialog1.FileName);
            CodeToBeSaved.Write(currentRtb.Text);
            CodeToBeSaved.Close();
            Close();

            GGDrive.Instance.Upload(saveFileDialog1.FileName);
        }
    }
}

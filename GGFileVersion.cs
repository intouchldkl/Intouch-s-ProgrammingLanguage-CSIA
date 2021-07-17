using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_IA_Ibasic_Intouch_Re
{
    class GGFileVersion
    {
        private string versionName;
        private string fileID;

        private DateTime date;

        public GGFileVersion(string versionName, string fileID,DateTime date)
        {
            this.versionName = versionName;
            this.fileID = fileID;
            this.date = date;
        }
        
        public string getVersionName()
        {
            return versionName;
        }

        public string getFileID()
        {
            return fileID;
        }
        public string getDate()
        {
            return date.ToString();
        }

        
    }
}

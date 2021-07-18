﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.IO;
using System.Security.Claims;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;

namespace CS_IA_Ibasic_Intouch_Re
{
   
    class GGDrive
    {
        static GGDrive instance;
        private DriveService Service;
        private string credPath = "token.json";
        private FileDataStore token;
        private UserCredential credential;
        private string IBASICfolderid = "";
        
        /// <summary>
        /// To make use of a singleton pattern and let instance be accessible to every forms and classes
        /// </summary>
        public static GGDrive Instance
        {
            get { return instance ?? (instance = new GGDrive()); }
        }
        public void Authentication()
        {
            //Scopes for use with the Google Drive API
            string[] scopes = new string[] { DriveService.Scope.Drive,
            DriveService.Scope.DriveFile};
            var CId = "226219782694-ob2mo6n00u3stkecpt81ue7nnkhvof23.apps.googleusercontent.com"; // Fromhttps://console.developers.google.com
            var CSecret = "_8vMgfs53veWJAU2IwMnjFxH";
            // Fromhttps://console.developers.google.com
            // Request the user to give us access, or use the Refresh Token that waspreviously stored in % AppData %

         
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.

                token = new FileDataStore(credPath);
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    new ClientSecrets
                    {
                        ClientId = CId,
                        ClientSecret = CSecret

                    },
                    scopes,
                    "user",
                    CancellationToken.None,
                   token).Result;

            }

            // Create Drive API service.
             Service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "IBASIC",
            });
            Service.HttpClient.Timeout = TimeSpan.FromMinutes(100);
        }

        public Permission AddPermission(string FileID, string Type)
        {
            Permission newPermission = new Permission();
            newPermission.Type = Type;
            newPermission.Role = "reader";
            var request = Service.Permissions.Create(newPermission, FileID);
            try
            {
                return request.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request Permissions.Create failed.", ex);
            }
        }
        public string GetMimeType(string FileName)
        {
            string mimeType = "application/unknown";
            string ext = Path.GetExtension(FileName).ToLower();
            Microsoft.Win32.RegistryKey regKey =
            Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey != null && regKey.GetValue("Content Type") != null)
                mimeType = regKey.GetValue("Content Type").ToString();
            return mimeType;
        }
        public Google.Apis.Drive.v3.Data.File Upload(string FilePath)
        {
            if (System.IO.File.Exists(FilePath))
            {
                Google.Apis.Drive.v3.Data.File body = new
                Google.Apis.Drive.v3.Data.File();
                body.Name = Path.GetFileName(FilePath);
                //body.Description = "";
                body.MimeType = "txt";
                ///Make sure the file end up in the IBASICfolder
                body.Parents = new List<string> { IBASICfolderid };
                byte[] byteArray = System.IO.File.ReadAllBytes(FilePath);
                MemoryStream stream = new MemoryStream(byteArray);
                try
                {
                    FilesResource.CreateMediaUpload request =
                    Service.Files.Create(body, stream, GetMimeType(FilePath));
                    request.Upload();

                    return request.ResponseBody;

                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message, "Error Occured");

                    return null;

                }
            }
            else
            {
                MessageBox.Show("The file does not exist.", "404");
                return null;
            }
        }

        public void Download(string FilePath)
        {
            var request = Service.Files.Get(FilePath);
            var stream = new MemoryStream();
            string documentpath =
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string folderpath = "/ExperienceManager/";
            string savingpath = documentpath + folderpath + FilePath + ".jpg";
            // Add a handler which will be notified on progress changes.
            // It will notify on each chunk download and when the
            // download is completed or failed.
            request.MediaDownloader.ProgressChanged +=
            (Google.Apis.Download.IDownloadProgress progress) =>
            {
                switch (progress.Status)
                {
                    case Google.Apis.Download.DownloadStatus.Downloading:
                        {
                            Console.WriteLine(progress.BytesDownloaded);

                            break;
                        }
                    case Google.Apis.Download.DownloadStatus.Completed:
                        {
                            Console.WriteLine("Download complete.");
                            SaveStream(stream, savingpath);
                            break;
                        }
                    case Google.Apis.Download.DownloadStatus.Failed:
                        {
                            Console.WriteLine("Download failed.");

                            break;
                        }
                }
            };
            request.Download(stream);
        }
        public void SaveStream(MemoryStream Stream, string Path)
        {
            using (FileStream file = new FileStream(Path, FileMode.Create,
            FileAccess.Write))
            {
                Stream.WriteTo(file);
            }
        }
        /// <summary>
        /// Revoke and delete token.json to logout
        /// </summary>
        public void logout()
        {
            credential.RevokeTokenAsync(CancellationToken.None);
            token.DeleteAsync<string>(credPath);
        }
        public void CreateIBASICFolder(string folderName)
        {
            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
            {
                Name = folderName,
                MimeType = "application/vnd.google-apps.folder"
            };
            var request = Service.Files.Create(fileMetadata);
            request.Fields = "id";
            var file = request.Execute();
            IBASICfolderid = file.Id;
            

        }
        public string getIBASICFolderId()
        {
            return IBASICfolderid;
        }
        public GGDriveFile[] retrieveFile()
        {
            Authentication();
            // Define parameters of request.
            FilesResource.ListRequest listRequest = Service.Files.List();
            ///Make sure it gets id,name,version and createdTime
            listRequest.Fields = "nextPageToken, files(id, name,version,createdTime)";
            ///Make sure it retrieves from the right folder
            listRequest.Q = listRequest.Q = ("(" + "'" + IBASICfolderid + "'" + " in parents" + ")" + "");
            // List files.
            IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute().Files;

            GGDriveFile[] driveFiles = new GGDriveFile[files.Count];
            if (files != null && files.Count > 0)
            {
                for (int i = 0; i < files.Count; i++)
                {
                    var file = files[i];
                    driveFiles[i] = new GGDriveFile
                    {
                        Id = file.Id,
                        Name = file.Name,
                        Version = file.Version,
                        createdTime = file.CreatedTime
                    };
                }
            }
            return driveFiles;
        }
        public bool checkForIBasicFolder()
        {
            Authentication();
            FilesResource.ListRequest listRequest = Service.Files.List();
            listRequest.Fields = "nextPageToken, files(id, name)";

            // List files.
            IList<Google.Apis.Drive.v3.Data.File> files = listRequest.Execute()
                .Files;
            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                    if(file.Name == "IBASIC-FOLDER")
                    {
                        IBASICfolderid = file.Id;
                        return true;
                        
                    }
                
                }
            }

            return false;
        }
      
    }
}
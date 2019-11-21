using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace T227679 {
    public partial class FileDialogControl : System.Web.UI.UserControl {
        private string clientInstanceName;

        public string ClientInstanceName {
            get { return String.IsNullOrEmpty(clientInstanceName) ? this.ClientID : this.clientInstanceName; }
            set { this.clientInstanceName = value; }
        }

        public FileDialogControl() {
            clientInstanceName = null;            
        }

        protected void Page_Init(object sender, EventArgs e) {
            fileManager.Settings.RootFolder = FilesystemReportStorageWebExtension.STORAGE_FOLDER_PATH;

            popup.ClientSideEvents.Init = String.Format("function(s, e) {{ {0}.initializeControl(); }}", this.ClientInstanceName);
            fileManager.ClientSideEvents.SelectionChanged = String.Format("function(s, e) {{ {0}.fileManager_SelectionChanged(s, e); }}", this.ClientInstanceName);
            buttonCancel.ClientSideEvents.Click = String.Format("function(s, e) {{ {0}.buttonCancel_Click(); }}", this.ClientInstanceName);
            buttonOk.ClientSideEvents.Click = String.Format("function(s, e) {{ {0}.buttonOk_Click(); }}", this.ClientInstanceName);
            validationCallback.ClientSideEvents.CallbackComplete = String.Format("function(s, e) {{ {0}.validationCallback_CallbackComplete(s, e); }}", this.ClientInstanceName);            
        }

        protected void validationCallback_Callback(object source, DevExpress.Web.CallbackEventArgs e) {
            try {
                
                string[] parameters = e.Parameter.Split('|');
                string dialogMode = parameters[0];
                string fileName = Server.MapPath(Path.Combine(fileManager.Settings.RootFolder, parameters[1]));
                switch (dialogMode) {
                    case "OPEN":
                        using (var file = File.OpenRead(fileName)) {
                        }
                        break;
                    case "SAVE":
                        if (!File.Exists(fileName)) {
                            using (var file = File.Create(fileName)) {
                            }
                            File.Delete(fileName);
                        }
                        break;
                }
                e.Result = String.Empty;
            }
            catch (Exception ex) {
                string rootPath = Server.MapPath(fileManager.Settings.RootFolder);
                e.Result = ex.Message.Replace(rootPath, fileManager.Settings.RootFolder);
            }
        }
    }
}
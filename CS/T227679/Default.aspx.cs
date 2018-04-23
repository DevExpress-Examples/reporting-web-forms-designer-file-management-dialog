using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.XtraReports.Web;
using DevExpress.Web;
using DevExpress.XtraReports.UI;
using System.IO;

namespace T227679 {
    public partial class Default : System.Web.UI.Page {
        protected void NewReport() {
            reportDesigner.OpenReport(new ReportTemplate());
        }

        protected void OpenReport(string fileName) {
            XtraReport report = new XtraReport();
            report.LoadLayout(Server.MapPath(fileName));
            reportDesigner.OpenReport(report);
        }

        protected void SaveReport(string fileName, byte[] reportLayout) {
            throw new NotSupportedException("Saving is not allowed."); //Comment this line to enable saving
            File.WriteAllBytes(Server.MapPath(fileName), reportLayout);
        }

        protected void Page_Init(object sender, EventArgs e) {
            if (!IsPostBack) {
                NewReport();
            }
        }

        protected void callbackPanel_Callback(object sender, CallbackEventArgsBase e) {
            try {
                string[] parameters = e.Parameter.Split('|');
                string command = parameters[0];
                switch (command) {
                    case "NEW":
                        NewReport();
                        break;
                    case "OPEN":
                        string fileName = HttpUtility.UrlDecode(parameters[1]);
                        OpenReport(fileName);
                        break;
                }
                callbackPanel.JSProperties["cpResult"] = String.Empty;
            }
            catch (Exception ex) {
                callbackPanel.JSProperties["cpResult"] = ex.Message;
            }
        }

        protected void reportDesigner_SaveReportLayout(object sender, SaveReportLayoutEventArgs e) {
            try {
                string fileName = HttpUtility.UrlDecode(e.Parameters);
                SaveReport(fileName, e.ReportLayout);
                reportDesigner.JSProperties["cpResult"] = String.Empty;
            }
            catch (Exception ex) {
                reportDesigner.JSProperties["cpResult"] = ex.Message;
            }
        }
    }
}
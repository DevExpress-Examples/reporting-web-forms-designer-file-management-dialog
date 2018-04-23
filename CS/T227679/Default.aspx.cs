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
        protected void Page_Init(object sender, EventArgs e) {
            if (!IsPostBack) {
                reportDesigner.OpenReport(new XtraReport());
            }
        }
    }
}
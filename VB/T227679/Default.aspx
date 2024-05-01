<%@ Page Language="VB" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="T227679.Default" %>

<%@ Register Assembly="DevExpress.Web.v22.2, Version=22.2.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraReports.v22.2.Web.WebForms, Version=22.2.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraReports.v22.2.Web.WebForms, Version=22.2.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraReports.Web.ClientControls" TagPrefix="cc1" %>
<%@ Register Src="~/FileDialogControl.ascx" TagPrefix="uc" TagName="FileDialogControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="Scripts/ClientFileDialogControl.js"></script>
    <script type="text/javascript">
        function GetDesignerUrl() {
            return reportDesigner.GetDesignerModel().navigateByReports.currentTab().url();
        }

        function reportDesigner_Open() {
            fileDialog.ShowOpenFileDialog(OpenFileDialogResult);
        }

        function reportDesigner_Save() {
            var fileName = GetDesignerUrl();
            if (fileName) {
                reportDesigner.SaveReport()
                    .done(function (r) {
                        alert("Report " + fileName + " was saved.");
                    });
            }
            else {
                reportDesigner_SaveAs();
            }
        }

        function reportDesigner_SaveAs() {
            fileDialog.ShowSaveFileDialog(SaveFileDialogResult);
        }

        function OpenFileDialogResult(fileName) {
            reportDesigner.OpenReport(fileName);
        }

        function SaveFileDialogResult(fileName) {
            reportDesigner.SaveNewReport(fileName)
                .done(function (result) {
                    alert("Report " + result + " was saved.");
                });
        }

        function reportDesigner_CustomizeMenuActions(s, e) {
            var defaultOpenAction = e.GetById(DevExpress.Reporting.Designer.Actions.ActionId.OpenReport);
            var defaultSaveAction = e.GetById(DevExpress.Reporting.Designer.Actions.ActionId.Save);
            var defaultSaveAsAction = e.GetById(DevExpress.Reporting.Designer.Actions.ActionId.SaveAs);

            if (defaultOpenAction)
                defaultOpenAction.clickAction = reportDesigner_Open;

            if (defaultSaveAction) {
                defaultSaveClickAction = defaultSaveAction.clickAction;
                defaultSaveAction.clickAction = reportDesigner_Save;
            }

            if (defaultSaveAsAction)
                defaultSaveAsAction.clickAction = reportDesigner_SaveAs;
        }

        function reportDesigner_OnServerError(s, e) {
            var errorMessage = e.Error.data.error;
            alert("A server-side exception occured: " + errorMessage);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dx:ASPxReportDesigner ID="reportDesigner" runat="server" ClientInstanceName="reportDesigner">
            <ClientSideEvents CustomizeMenuActions="reportDesigner_CustomizeMenuActions" OnServerError="reportDesigner_OnServerError" />
        </dx:ASPxReportDesigner>
        <uc:FileDialogControl ID="fileDialog" runat="server" ClientInstanceName="fileDialog">
        </uc:FileDialogControl>
    </div>
    </form>
</body>
</html>

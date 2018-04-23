<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="T227679.Default" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.11.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraReports.v16.1.Web, Version=16.1.11.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraReports.v16.1.Web, Version=16.1.11.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
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

        function SetDesignerUrl(url) {
            reportDesigner.GetDesignerModel().navigateByReports.currentTab().url(url);
        }

        function ClearUndoEngine() {
            reportDesigner.GetDesignerModel().navigateByReports.currentTab().undoEngine.clearHistory();
        }
        
        function reportDesigner_Open() {
            fileDialog.ShowOpenFileDialog(OpenFileDialogResult);
        }

        function reportDesigner_Save() {
            var fileName = GetDesignerUrl();
            if (fileName) {
                DevExpress.Designer.Report.ReportStorageWeb.setData(reportDesigner.GetDesignerModel().model().serialize(), fileName)
                    .done(function (r) {
                        ClearUndoEngine();
                        alert("Report " + fileName + " was saved.");
                    })
                    .fail(function (f) {
                        var errorMessage = f.responseJSON.error;
                        alert("An exception occured while saving the report: " + errorMessage);
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
            DevExpress.Designer.Report.ReportStorageWeb.getData(fileName)
                .done(function (result) {
                    var model = new DevExpress.Designer.Report.ReportViewModel(JSON.parse(result.reportLayout));
                    model.dataSourceRefs = result.dataSourceRefInfo;
                    reportDesigner.GetDesignerModel().model(model);
                    SetDesignerUrl(fileName);
                })
                .fail(function (f, status, errorMessage) {
                    var errorMessage = f.responseJSON.error;
                    alert("An exception occured while opening the report: " + errorMessage);
                });
        }

        function SaveFileDialogResult(fileName) {
            DevExpress.Designer.Report.ReportStorageWeb.setNewData(reportDesigner.GetDesignerModel().model().serialize(), fileName)
                .done(function (result) {
                    SetDesignerUrl(result);
                    ClearUndoEngine();
                    alert("Report " + result + " was saved.");
                })
                .fail(function (f) {
                    var errorMessage = f.responseJSON.error;
                    alert("An exception occured while saving the report: " + errorMessage);
                });
        }

        function reportDesigner_CustomizeMenuActions(s, e) {
            var defaultOpenAction = e.GetById(DevExpress.Designer.Report.ActionId.OpenReport);
            var defaultSaveAction = e.GetById(DevExpress.Designer.Report.ActionId.Save);
            var defaultSaveAsAction = e.GetById(DevExpress.Designer.Report.ActionId.SaveAs);

            if (defaultOpenAction)
                defaultOpenAction.clickAction = reportDesigner_Open;

            if (defaultSaveAction) {
                defaultSaveClickAction = defaultSaveAction.clickAction;
                defaultSaveAction.clickAction = reportDesigner_Save;
            }

            if (defaultSaveAsAction)
                defaultSaveAsAction.clickAction = reportDesigner_SaveAs;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dx:ASPxReportDesigner ID="reportDesigner" runat="server" ClientInstanceName="reportDesigner">
            <ClientSideEvents CustomizeMenuActions="reportDesigner_CustomizeMenuActions" />
        </dx:ASPxReportDesigner>
        <uc:FileDialogControl ID="fileDialog" runat="server" ClientInstanceName="fileDialog">
        </uc:FileDialogControl>
    </div>
    </form>
</body>
</html>

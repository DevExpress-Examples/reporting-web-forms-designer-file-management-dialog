<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="T227679.Default" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraReports.v14.2.Web, Version=14.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraReports.v14.2.Web, Version=14.2.9.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraReports.Web.ClientControls" TagPrefix="cc1" %>

<%@ Register Src="~/FileDialogControl.ascx" TagPrefix="uc" TagName="FileDialogControl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/DesignerIconStyles.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Scripts/ClientFileDialogControl.js"></script>
    <script type="text/javascript">
        var saveAction;
        var currentFileName = "";

        function reportDesigner_New() {
            currentFileName = "";            
            callbackPanel.PerformCallback("NEW");
        }

        function reportDesigner_Open() {
            fileDialog.ShowOpenFileDialog(OpenFileDialogResult);
        }

        function reportDesigner_Save() {
            if (currentFileName !== "") {
                reportDesigner.PerformCallback(currentFileName);
            }
        }

        function reportDesigner_SaveAs() {            
            fileDialog.ShowSaveFileDialog(SaveFileDialogResult);
        }

        function OpenFileDialogResult(fileName) {
            currentFileName = fileName;
            callbackPanel.PerformCallback("OPEN|" + fileName);
        }

        function SaveFileDialogResult(fileName) {
            currentFileName = fileName;
            reportDesigner.PerformCallback(currentFileName);
        }

        function InitializeWizardActions() {
            saveAction.disabled = ko.observable(currentFileName == "");
        }

        function reportDesigner_CustomizeMenuActions(s, e) {
            var defaultSaveAction = e.Actions.filter(function (x) { return x.text === 'Save' })[0];            
            defaultSaveAction.visible = false;
            
            saveAction = e.Actions.filter(function (x) { return x.text === 'Save' })[1];
            InitializeWizardActions();
        }

        function callbackPanel_EndCallback(s, e) {
            if (s.cpResult !== "") {
                alert("An exception occured while opening the report: " + s.cpResult);
            }
        }

        function reportDesigner_EndCallback(s, e) {
            if (s.cpResult !== "") {
                alert("An exception occured while saving the report: " + s.cpResult);
            }
            else {
                alert("Report " + currentFileName + " was saved.");
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dx:ASPxCallbackPanel ID="callbackPanel" runat="server" ClientInstanceName="callbackPanel"
            Width="100%" OnCallback="callbackPanel_Callback">
            <ClientSideEvents EndCallback="callbackPanel_EndCallback" />
            <PanelCollection>
                <dx:PanelContent runat="server">
                    <dx:ASPxReportDesigner ID="reportDesigner" runat="server" ClientInstanceName="reportDesigner"
                        OnSaveReportLayout="reportDesigner_SaveReportLayout">
                        <ClientSideEvents CustomizeMenuActions="reportDesigner_CustomizeMenuActions" EndCallback="reportDesigner_EndCallback" />
                        <MenuItems>
                            <cc1:ClientControlsMenuItem JSClickAction="reportDesigner_New" Text="New" ImageClassName="reportDesignerIconNew" />
                            <cc1:ClientControlsMenuItem JSClickAction="reportDesigner_Open" Text="Open" ImageClassName="reportDesignerIconOpen" />
                            <cc1:ClientControlsMenuItem JSClickAction="reportDesigner_Save" Text="Save" ImageClassName="reportDesignerIconSave" />
                            <cc1:ClientControlsMenuItem JSClickAction="reportDesigner_SaveAs" Text="Save As" ImageClassName="reportDesignerIconSaveAs" />
                        </MenuItems>
                    </dx:ASPxReportDesigner>
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxCallbackPanel>
        <uc:FileDialogControl ID="fileDialog" runat="server" ClientInstanceName="fileDialog">
        </uc:FileDialogControl>
    </div>
    </form>
</body>
</html>

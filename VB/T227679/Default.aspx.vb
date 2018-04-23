Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.XtraReports.Web
Imports DevExpress.Web
Imports DevExpress.XtraReports.UI
Imports System.IO

Namespace T227679
    Partial Public Class [Default]
        Inherits System.Web.UI.Page

        Protected Sub NewReport()
            reportDesigner.OpenReport(New ReportTemplate())
        End Sub

        Protected Sub OpenReport(ByVal fileName As String)
            Dim report As New XtraReport()
            report.LoadLayout(Server.MapPath(fileName))
            reportDesigner.OpenReport(report)
        End Sub

        Protected Sub SaveReport(ByVal fileName As String, ByVal reportLayout() As Byte)
            Throw New NotSupportedException("Saving is not allowed.") 'Comment this line to enable saving
            File.WriteAllBytes(Server.MapPath(fileName), reportLayout)
        End Sub

        Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
            If Not IsPostBack Then
                NewReport()
            End If
        End Sub

        Protected Sub callbackPanel_Callback(ByVal sender As Object, ByVal e As CallbackEventArgsBase)
            Try
                Dim parameters() As String = e.Parameter.Split("|"c)
                Dim command As String = parameters(0)
                Select Case command
                    Case "NEW"
                        NewReport()
                    Case "OPEN"
                        Dim fileName As String = HttpUtility.UrlDecode(parameters(1))
                        OpenReport(fileName)
                End Select
                callbackPanel.JSProperties("cpResult") = String.Empty
            Catch ex As Exception
                callbackPanel.JSProperties("cpResult") = ex.Message
            End Try
        End Sub

        Protected Sub reportDesigner_SaveReportLayout(ByVal sender As Object, ByVal e As SaveReportLayoutEventArgs)
            Try
                Dim fileName As String = HttpUtility.UrlDecode(e.Parameters)
                SaveReport(fileName, e.ReportLayout)
                reportDesigner.JSProperties("cpResult") = String.Empty
            Catch ex As Exception
                reportDesigner.JSProperties("cpResult") = ex.Message
            End Try
        End Sub
    End Class
End Namespace
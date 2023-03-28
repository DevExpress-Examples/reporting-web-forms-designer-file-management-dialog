Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.XtraReports.UI

Namespace T227679

    Public Partial Class [Default]
        Inherits Page

        Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
            If Not IsPostBack Then
                reportDesigner.OpenReport(New XtraReport())
            End If
        End Sub
    End Class
End Namespace

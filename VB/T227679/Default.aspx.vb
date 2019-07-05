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

		Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
			If Not IsPostBack Then
				reportDesigner.OpenReport(New XtraReport())
			End If
		End Sub
	End Class
End Namespace
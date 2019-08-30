Imports System.IO
Imports System.Collections.Generic
Imports System
Imports DevExpress.XtraReports.UI
Imports System.Web
Imports System.ServiceModel

Namespace T227679
	Public Class FilesystemReportStorageWebExtension
		Inherits DevExpress.XtraReports.Web.Extensions.ReportStorageWebExtension

		Private _context As HttpContext

		Public Sub New(ByVal context As HttpContext)
			Me._context = context
		End Sub

		Public ReadOnly Property Context() As HttpContext
			Get
				Return _context
			End Get
		End Property

		Protected Function GetPath(ByVal url As String) As String
			If Path.IsPathRooted(url) Then
				Return url
			End If

			Return Context.Server.MapPath(url)
		End Function

		Public Overrides Function CanSetData(ByVal url As String) As Boolean
			Dim filePath As String = GetPath(url)
			Return File.Exists(filePath)
		End Function

		Public Overrides Function GetData(ByVal url As String) As Byte()
			Try
				Dim filePath As String = GetPath(url)
				Return File.ReadAllBytes(filePath)
			Catch ex As Exception
				'Pass readable exception message to the Web Report Designer
				Throw New FaultException(ex.Message)
			End Try
		End Function

		Public Overrides Function GetUrls() As Dictionary(Of String, String)
			Dim storagePath As String = Context.Server.MapPath("~\ReportsStorage\")

			Dim urls As New Dictionary(Of String, String)()
			Dim reportFiles() As String = Directory.GetFiles(storagePath, "*.repx", SearchOption.AllDirectories)
			For Each filePath As String In reportFiles
				urls.Add(filePath, filePath.Replace(storagePath, String.Empty))
			Next filePath
			Return urls
		End Function

		Public Overrides Function IsValidUrl(ByVal url As String) As Boolean
			Dim filePath As String = GetPath(url)
			If File.Exists(filePath) Then
				Return True
			End If

			Try
				File.Create(filePath).Close()
				File.Delete(filePath)
				Return True
			Catch
				Return False
			End Try
		End Function

		Public Overrides Sub SetData(ByVal report As XtraReport, ByVal url As String)
			Try
				Dim filePath As String = GetPath(url)
				Throw New NotSupportedException("Saving is not allowed.") 'Comment this line to enable saving
				report.SaveLayoutToXml(filePath)
			Catch ex As Exception
				'Pass readable exception message to the Web Report Designer
				Throw New FaultException(ex.Message)
			End Try
		End Sub

		Public Overrides Function SetNewData(ByVal report As XtraReport, ByVal defaultUrl As String) As String
			Try
				Dim filePath As String = GetPath(defaultUrl)
				Throw New NotSupportedException("Saving is not allowed.") 'Comment this line to enable saving
				report.SaveLayoutToXml(filePath)
				Return filePath
			Catch ex As Exception
				'Pass readable exception message to the Web Report Designer
				Throw New FaultException(ex.Message)
			End Try
		End Function
	End Class
End Namespace

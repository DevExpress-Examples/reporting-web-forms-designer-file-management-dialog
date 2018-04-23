Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.IO

Namespace T227679
    Partial Public Class FileDialogControl
        Inherits System.Web.UI.UserControl


        Private clientInstanceName_Renamed As String

        Public Property ClientInstanceName() As String
            Get
                Return If(String.IsNullOrEmpty(clientInstanceName_Renamed), Me.ClientID, Me.clientInstanceName_Renamed)
            End Get
            Set(ByVal value As String)
                Me.clientInstanceName_Renamed = value
            End Set
        End Property

        Public Sub New()
            clientInstanceName_Renamed = Nothing
        End Sub

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            popup.ClientSideEvents.Init = String.Format("function(s, e) {{ {0}.initializeControl(); }}", Me.ClientInstanceName)
            fileManager.ClientSideEvents.SelectionChanged = String.Format("function(s, e) {{ {0}.fileManager_SelectionChanged(s, e); }}", Me.ClientInstanceName)
            buttonCancel.ClientSideEvents.Click = String.Format("function(s, e) {{ {0}.buttonCancel_Click(); }}", Me.ClientInstanceName)
            buttonOk.ClientSideEvents.Click = String.Format("function(s, e) {{ {0}.buttonOk_Click(); }}", Me.ClientInstanceName)
            validationCallback.ClientSideEvents.CallbackComplete = String.Format("function(s, e) {{ {0}.validationCallback_CallbackComplete(s, e); }}", Me.ClientInstanceName)
        End Sub

        Protected Sub validationCallback_Callback(ByVal source As Object, ByVal e As DevExpress.Web.CallbackEventArgs)
            Try
                Dim parameters() As String = e.Parameter.Split("|"c)
                Dim dialogMode As String = parameters(0)
                Dim fileName As String = Server.MapPath(parameters(1))
                Select Case dialogMode
                    Case "OPEN"
                        Using file = System.IO.File.OpenRead(fileName)
                        End Using
                    Case "SAVE"
                        If Not System.IO.File.Exists(fileName) Then
                            Using file = System.IO.File.Create(fileName)
                            End Using
                            System.IO.File.Delete(fileName)
                        End If
                End Select
                e.Result = String.Empty
            Catch ex As Exception
                Dim rootPath As String = Server.MapPath(fileManager.Settings.RootFolder)
                e.Result = ex.Message.Replace(rootPath, fileManager.Settings.RootFolder)
            End Try
        End Sub
    End Class
End Namespace
Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.IO

Namespace T227679

    Public Partial Class FileDialogControl
        Inherits UserControl

        Private clientInstanceNameField As String

        Public Property ClientInstanceName As String
            Get
                Return If(String.IsNullOrEmpty(clientInstanceNameField), ClientID, clientInstanceNameField)
            End Get

            Set(ByVal value As String)
                clientInstanceNameField = value
            End Set
        End Property

        Public Sub New()
            clientInstanceNameField = Nothing
        End Sub

        Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
            fileManager.Settings.RootFolder = FilesystemReportStorageWebExtension.STORAGE_FOLDER_PATH
            popup.ClientSideEvents.Init = String.Format("function(s, e) {{ {0}.initializeControl(); }}", ClientInstanceName)
            fileManager.ClientSideEvents.SelectionChanged = String.Format("function(s, e) {{ {0}.fileManager_SelectionChanged(s, e); }}", ClientInstanceName)
            buttonCancel.ClientSideEvents.Click = String.Format("function(s, e) {{ {0}.buttonCancel_Click(); }}", ClientInstanceName)
            buttonOk.ClientSideEvents.Click = String.Format("function(s, e) {{ {0}.buttonOk_Click(); }}", ClientInstanceName)
            validationCallback.ClientSideEvents.CallbackComplete = String.Format("function(s, e) {{ {0}.validationCallback_CallbackComplete(s, e); }}", ClientInstanceName)
        End Sub

        Protected Sub validationCallback_Callback(ByVal source As Object, ByVal e As DevExpress.Web.CallbackEventArgs)
            Try
                Dim parameters As String() = e.Parameter.Split("|"c)
                Dim dialogMode As String = parameters(0)
                Dim fileName As String = Server.MapPath(Path.Combine(fileManager.Settings.RootFolder, parameters(1)))
                Select Case dialogMode
                    Case "OPEN"
                        Using file = IO.File.OpenRead(fileName)
                        End Using

                    Case "SAVE"
                        If Not File.Exists(fileName) Then
                            Using file = IO.File.Create(fileName)
                            End Using

                            File.Delete(fileName)
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

﻿Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Security
Imports System.Web.SessionState

Namespace T227679
    Public Class [Global]
        Inherits System.Web.HttpApplication

        Protected Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
            DevExpress.XtraReports.Web.Extensions.ReportStorageWebExtension.RegisterExtensionGlobal(New FileReportStorageWebExtension(Me.Context))
            DevExpress.XtraReports.Web.ReportDesigner.DefaultReportDesignerContainer.RegisterDataSourceWizardConfigFileConnectionStringsProvider()
        End Sub

        Protected Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)

        End Sub

        Protected Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)

        End Sub

        Protected Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)

        End Sub

        Protected Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)

        End Sub

        Protected Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)

        End Sub

        Protected Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)

        End Sub
    End Class
End Namespace
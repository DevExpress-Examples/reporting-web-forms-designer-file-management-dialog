<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128597856/22.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T227679)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
*Files to look at*:



# Reporting for Web Forms - Report Designer with the ASPxFileManager Control in the Open Report Dialog

<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/t227679/)**
<!-- run online end -->


In this example, the Open/Save Report dialog boxes are implemented with the [ASPxFileManager](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxFileManager) control.

A custom [ASP.NET UserControl](https://learn.microsoft.com/en-us/previous-versions/aspnet/y6wb1a0e(v=vs.100)) implements the **Open/Save** file dialog window. The [ASPxCallback](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxCallback) control validates the file name that the user enters in the dialog. 

The **FileDialogControl** is the custom control. Its client-side functionality is located in the `ClientFileDialogControl` JavaScript class.

> **Note** The `SetData` and `SetNewData` method implementations in the `FilesystemReportStorageWebExtension` class does not allow you to save a report. You can modify these methods if needed.

![Report Designer with the ASPxFileManager Control in the Open Report Dialog](Images\screenshot.png)
## Files to Look At

* [Default.aspx](./CS/T227679/Default.aspx)
* [Default.aspx.cs](./CS/T227679/Default.aspx.cs)
* [FileDialogControl.ascx](./CS/T227679/FileDialogControl.ascx)
* [FileDialogControl.ascx.cs](./CS/T227679/FileDialogControl.ascx.cs)
* [ClientFileDialogControl.js](./CS/T227679/Scripts/ClientFileDialogControl.js)  
* [FilesystemReportStorageWebExtension.cs](./CS/T227679/FilesystemReportStorageWebExtension.cs)
* [Global.asax.cs](./CS/T227679/Global.asax.cs) 


## Documentation

- [Create an ASP.NET Web Forms Application with a Report Designer](http://docs.devexpress.devx/XtraReports/119172/web-reporting/asp-net-webforms-reporting/end-user-report-designer-in-asp-net-web-forms-reporting/quick-start/create-an-aspnet-webforms-application-with-a-report-designer)
- [Add a Report Storage (ASP.NET Web Forms)](http://docs.devexpress.devx/XtraReports/17553/web-reporting/asp-net-webforms-reporting/end-user-report-designer-in-asp-net-web-forms-reporting/add-a-report-storage)
- [End-User Report Designer Customization (ASP.NET Web Forms)](http://docs.devexpress.devx/XtraReports/17546/web-reporting/asp-net-webforms-reporting/end-user-report-designer-in-asp-net-web-forms-reporting/customization)

## More Examples

- [How to Customize the Save As and Open Dialogs in the Web End-User Report Designer](https://github.com/DevExpress-Examples/Reporting-How-To-Customize-Open-And-Save-As-Dialogs)


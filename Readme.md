<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/T227679/Default.aspx) (VB: [Default.aspx](./VB/T227679/Default.aspx))
* [Default.aspx.cs](./CS/T227679/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/T227679/Default.aspx.vb))
* [FileDialogControl.ascx](./CS/T227679/FileDialogControl.ascx) (VB: [FileDialogControl.ascx](./VB/T227679/FileDialogControl.ascx))
* [FileDialogControl.ascx.cs](./CS/T227679/FileDialogControl.ascx.cs) (VB: [FileDialogControl.ascx.vb](./VB/T227679/FileDialogControl.ascx.vb))
* **[FilesystemReportStorageWebExtension.cs](./CS/T227679/FilesystemReportStorageWebExtension.cs) (VB: [FilesystemReportStorageWebExtension.vb](./VB/T227679/FilesystemReportStorageWebExtension.vb))**
* [Global.asax.cs](./CS/T227679/Global.asax.cs) (VB: [Global.asax.vb](./VB/T227679/Global.asax.vb))
* [ClientFileDialogControl.js](./CS/T227679/Scripts/ClientFileDialogControl.js) (VB: [ClientFileDialogControl.js](./VB/T227679/Scripts/ClientFileDialogControl.js))
<!-- default file list end -->
# ASPxReportDesigner - How to create an ASP.NET End-User reporting application with the filesystem report storage managed by the ASPxFileManager control


<p>This example demonstrates how to create an End-User Reporting Application similar to a <strong>WinForms</strong> application that stores reports in the web server's filesystem. The <a href="https://documentation.devexpress.com/#AspNet/clsDevExpressWebASPxFileManagertopic">ASPxFileManager</a> control is used to implement the file Open and Save dialog boxes.</p>
<p> </p>
<p>In this example, a separate <a href="https://msdn.microsoft.com/en-us/library/fb3w5b53%28v=vs.140%29.aspx">ASP.NET UserControl</a> named "FileDialogControl" is used to implement the Open/Save file dialog window. The ASPxCallback control is used to validate an entered file name in the dialog. FileDialogControl's client-side functionality is moved to a separate javascript class named ClientFileDialogControl (its source code is located in the ClientFileDialogControl.js file).<br><br></p>
<p><strong>Important Note:</strong> Data modifications are not allowed in our code examples, so there is code in the FilesystemReportStorageWebExtension class's SetData and SetNewData methods that throws exceptions when a report is saved. You should comment out these lines in the mentioned methods after downloading this code example to allow data modifications on your side.</p>
<br><strong>See also:</strong><br><a href="https://www.devexpress.com/Support/Center/p/T178798">How to integrate the Web Report Designer into a web application</a>

<br/>



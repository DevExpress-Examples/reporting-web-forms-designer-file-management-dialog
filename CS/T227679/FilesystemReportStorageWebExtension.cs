using System.IO;
using System.Collections.Generic;
using System;
using DevExpress.XtraReports.UI;
using System.Web;
using System.ServiceModel;

namespace T227679 {
    public class FilesystemReportStorageWebExtension : DevExpress.XtraReports.Web.Extensions.ReportStorageWebExtension {
        HttpContext _context;

        public FilesystemReportStorageWebExtension(HttpContext context) {
            this._context = context;
        }

        public HttpContext Context {
            get {
                return _context;
            }
        }

        protected string GetPath(string url) {
            if (Path.IsPathRooted(url)) {
                return url;
            }

            return Context.Server.MapPath(url);
        }

        public override bool CanSetData(string url) {
            string filePath = GetPath(url);
            return File.Exists(filePath);
        }

        public override byte[] GetData(string url) {
            try {
                string filePath = GetPath(url);
                return File.ReadAllBytes(filePath);
            }
            catch (Exception ex) {
                //Pass readable exception message to the Web Report Designer
                throw new FaultException(ex.Message);
            }
        }

        public override Dictionary<string, string> GetUrls() {
            string storagePath = Context.Server.MapPath(@"~\ReportsStorage\");

            Dictionary<string, string> urls = new Dictionary<string, string>();
            string[] reportFiles = Directory.GetFiles(storagePath, "*.repx", SearchOption.AllDirectories);
            foreach (string filePath in reportFiles) {
                urls.Add(filePath, filePath.Replace(storagePath, String.Empty));
            }
            return urls;
        }

        public override bool IsValidUrl(string url) {
            string filePath = GetPath(url);
            if (File.Exists(filePath))
                return true;

            try {
                File.Create(filePath).Close();
                File.Delete(filePath);
                return true;
            }
            catch {
                return false;
            }
        }

        public override void SetData(XtraReport report, string url) {
            try {
                string filePath = GetPath(url);
                throw new NotSupportedException("Saving is not allowed."); //Comment this line to enable saving
                report.SaveLayoutToXml(filePath);
            }
            catch (Exception ex) {
                //Pass readable exception message to the Web Report Designer
                throw new FaultException(ex.Message);
            }
        }

        public override string SetNewData(XtraReport report, string defaultUrl) {
            try {
                string filePath = GetPath(defaultUrl);
                throw new NotSupportedException("Saving is not allowed."); //Comment this line to enable saving
                report.SaveLayoutToXml(filePath);
                return filePath;
            }
            catch (Exception ex) {
                //Pass readable exception message to the Web Report Designer
                throw new FaultException(ex.Message);
            }
        }
    }
}

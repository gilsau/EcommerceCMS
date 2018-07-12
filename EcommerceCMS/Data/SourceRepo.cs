using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EcommerceCMS.Models;

namespace EcommerceCMS.Data
{
    public static class SourceRepo
    {
        public static FileInfoModel GetSourceFile(int id) {
            EcommerceCMSEntities db = new EcommerceCMSEntities();

            SupplierSource ss = db.SupplierSources.SingleOrDefault(s => s.Id == id);

            FileInfoModel fi = new FileInfoModel();
            fi.Url = ss.FileSample != null ? string.Format("{0}/data/sourcefiles/{1}", HttpContext.Current.Request.Url.AbsoluteUri, ss.FileSample) : null;
            fi.FileFields = ss.CSVColumns != null ? ss.CSVColumns.Split(',').ToList() : null;
            fi.DBFields = ss.DBColumns != null ? ss.DBColumns.Split(',').ToList() : null;

            return fi;
        }
    }
}
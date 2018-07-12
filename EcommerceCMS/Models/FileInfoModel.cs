using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceCMS.Models
{
    public class FileInfoModel
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public List<string> FileFields { get; set; }
        public List<string> DBFields { get; set; }
    }
}
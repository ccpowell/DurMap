using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DurMap.Site.Models
{
    public class ReportType
    {
        public string Name { get; set; }
    }

    public class Category
    {
        public string Name { get; set; }

        public List<ReportType> ReportTypes { get; set; }
    }
}
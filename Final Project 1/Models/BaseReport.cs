using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_1.Models
{
    public abstract class BaseReport
    {
        public string UserName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public DateTime ReportDate { get; set; }
        public abstract string GetReportType();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_1.Models
{
    public class MedicalReport : BaseReport
    {
        public string PatientName { get; set; }
        public string description { get; set;}
        public string location { get; set; }
        public string Severity { get; set; }

        public override string GetReportType()
        {
            return "Medical";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_1.Models
{
    public class AccidentReport : BaseReport
    {
        public string Severity { get; set; }
        public string MediaPath { get; set; }

        public override string GetReportType()
        {
            return "Accident";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_1.Models
{
    public class BloodRequest
    {
        public string PatientName { get; set; }
        public string BloodGroup { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public bool IsUrgent { get; set; }
        public DateTime RequestDate { get; set; }
        public string Status { get; set; }
    }
}

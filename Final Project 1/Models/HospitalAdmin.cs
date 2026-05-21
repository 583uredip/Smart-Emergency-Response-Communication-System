using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_1.Models
{
  public  class HospitalAdmin:BaseAccount
    {
        public override string GetRole()
        {
            return "HospitalAdmin";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_1.Models
{

    public class User : BaseAccount
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string BloodGroup { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public override string GetRole()
        {
            return Role ?? "User";
        }
    }


}

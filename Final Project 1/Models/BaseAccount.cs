using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project_1.Models
{
    public abstract class BaseAccount
    {
        
        public int LoginId { get; set; }
        public string Name { get; set; }
        public abstract string GetRole();
    }
}


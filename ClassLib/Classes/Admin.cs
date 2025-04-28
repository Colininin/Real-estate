using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLib.Classes
{
    public class Admin:User
    {
        public Admin(int id, string accType, string name, string email, int phoneNumber) : base(id, accType, name, email, phoneNumber)
        {
            
        }
    }
}

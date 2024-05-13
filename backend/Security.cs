using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend
{
    public static class Security
    {
        public static bool activeSession(object user)
        {
            User person = user != null ? (User)user : null;
            if (person != null && person.Id != 0)
                return true;
            else
                return false;
        }
    }
}

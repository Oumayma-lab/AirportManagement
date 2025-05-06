using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Applactioncore.Domaine;

namespace AM.Applactioncore.Services
{
    public static class PassengerExtension
    {
            public static void UpperFullName(this Passenger p)
            {
                p.FullName.FirstName = p.FullName.FirstName[0].ToString().ToUpper() + p.FullName.FirstName.Substring(1);
                p.FullName.Lastname = p.FullName.Lastname[0].ToString().ToUpper() + p.FullName.Lastname.Substring(1);
            }
        }
    }


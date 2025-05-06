using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Applactioncore.Domaine;
using AM.Applactioncore.Intterfaces;
using AM.ApplicationCore.Interfaces;
using AM.ApplicationCore.Services;

namespace AM.Applactioncore.Services
{
    public class ServiceFlight : Service<Flight>, IServiceFlight
    {
        public ServiceFlight(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}

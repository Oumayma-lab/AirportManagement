using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Applactioncore.Domaine;
using AM.ApplicationCore.Interfaces;
using AM.Applactioncore.Domaine;

namespace AM.Applactioncore.Intterfaces
{
    public interface IServicePlane : IService<Plane>
    {

        IEnumerable<Passenger> GetPassenger(Plane p);
        IEnumerable<Flight> GetFlights(int n);
        bool IsAvailablePlane(Flight flight, int n);

        void DeletePlanes();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Applactioncore.Domaine;

namespace AM.Applactioncore.Intterfaces
{
    public interface IFlightMethods
    {
        IEnumerable<DateTime> GetFlightDates(string destination);
        void ShowFlightDetails(Plane plane);
        int ProgrammedFlightNumber(DateTime startDate);
        //question12
        double DurationAverage(string destination);
        //question13
        IEnumerable<Flight> OrderedDurationFlights();
        //question14
        //IEnumerable<Traveller> SeniorTravellers(Flight flight);
        //queston15
        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights();






    }


}

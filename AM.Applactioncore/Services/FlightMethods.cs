using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AM.Applactioncore.Domaine;
using AM.Applactioncore.Intterfaces;

namespace AM.Applactioncore.Services
{
    public class FlightMethods : IFlightMethods
    {
        public List<Flight> Flights { get; set; } = new List<Flight>();

        //qestion6
        //public IEnumerable<DateTime> GetFlightDates(string destination)
        //{
        //    List<DateTime> flightDates = new List<DateTime>();
        //    for (int i = 0; i < Flights.Count; i++)
        //    {
        //        if (Flights[i].Destination == destination)
        //        {
        //            flightDates.Add(Flights[i].FlightDate);
        //        }
        //    }
        //    return flightDates;
        //}



        //qestion7
        //public IEnumerable<DateTime> GetFlightDates(string destination)
        //{
        //    IEnumerable<DateTime> flightDates = new List<DateTime>();
        //    //foreach (var flight in Flights)
        //    //{
        //    //    if (flight.Destination == destination)
        //    //    {
        //    //        flightDates.Add(flight.FlightDate);
        //    //    }
        //    //}

        //    //Lnagage Link question 9
        //    //flightDates = from f in Flights
        //    //              where f.Destination == destination
        //    //              select FlightDate;

        //    ////Expression Lamda
        //    //flightDates = Flights.Where(f => f.Destination == destination)
        //    //                     .Select(f => f.FlightDate);

        //    //return flightDates;
        //}
        //question8
        public void GetFlights(string filterType, string filterValue)
        {
            List<Flight> filteredFlights = new List<Flight>();
            if (filterType == "Destination")
            {
                filteredFlights = Flights.Where(f => f.Destination == filterValue).ToList();
            }
        }





        public IEnumerable<DateTime> GetFlightDates(string destination)
        {
            // LINQ 
            var flightDates = Flights.Where(f => f.Destination == destination)
                                     .Select(f => f.FlightDate);
            return flightDates;
        }




        // Implémentation de ShowFlightDetails
        public void ShowFlightDetails(Plane plane)
        {
            var flights = Flights.Where(f => f.plane == plane)
                                 .Select(f => new { f.FlightDate, f.Destination });

            Console.WriteLine($"Détails des vols pour l'avion {plane.planeType}:");
            foreach (var flight in flights)
            {
                Console.WriteLine($"Décollage : {flight.FlightDate}, Destination : {flight.Destination}");
            }
        }

        //questio 11 avec LINQ
        public int ProgrammedFlightNumber(DateTime startDate)

        { var rep = from f in Flights
                    where DateTime.Compare(startDate, f.FlightDate) < 0
                    && (f.FlightDate - startDate).TotalDays < 8
                    select f;
            return rep.Count();
        }
        //question 11 Expressions Lambda

        public int ProgrammedFlightNumber2(DateTime startDate)

        {
            var rep = from f in Flights
                      where DateTime.Compare(startDate, f.FlightDate) < 0
                      && (f.FlightDate - startDate).TotalDays < 8
                      select f;
            var req = Flights.Where(f => DateTime.Compare(startDate, f.FlightDate) < 0
            && (f.FlightDate - startDate).TotalDays < 8);
            return rep.Count();
        }

        //question12
        //avec LINQ
        public double DurationAverage(string destination)
        {
            var req = from f in Flights
                      where f.Destination == destination
                      select f.EstimationDuration;
            return req.Average();
        }
        //question 12 Expressions Lambda

        public double DurationAverage2(string destination)
        {
            return Flights.Where(f => f.Destination == destination)
                          .Average(f => f.EstimationDuration);
        }

        //question13
        public IEnumerable<Flight> OrderedDurationFlights()
        {
            var req = from f in Flights
                      orderby f.EstimationDuration descending
                      select f;
            return req;

        }
        //question 13 Expressions Lambda

        public IEnumerable<Flight> OrderedDurationFlights2()
        {
            return Flights.OrderByDescending(f => f.EstimationDuration);
        }

        //question14
        //public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        //{
        //    var req = from t in flight.passengers.OfType<Traveller>()
        //              orderby t.BrithDate
        //              select t;
        //    return req.Take(3);
        //}
        //question 14 Expressions Lambda

        //public IEnumerable<Traveller> SeniorTravellers2(Flight flight)
        //{
        //    //return flight.passengers
        //    //             .OfType<Traveller>()
        //    //             .OrderBy(t => t.BrithDate)
        //    //             .Take(3);
        //    return null;
        //}


        //queston15


        //public void DestinationGroupedFlights()
        //{
        //    var groupedFlights = Flights.GroupBy(f => f.Destination);

        //    foreach (var group in groupedFlights)
        //    {
        //        Console.WriteLine($"Destination {group.Key}");
        //        foreach (var flight in group)
        //        {
        //            Console.WriteLine($"Décollage : {flight.FlightDate:dd/MM/yyyy HH:mm:ss}");
        //        }
        //    }
        //}


        //question 15
        //public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        //{
        //    var req = from f in Flights
        //              group f by f.Destination;
        //    foreach (var g in req)
        //    {
        //        Console.WriteLine("Destination" + g.Key);
        //        foreach (var f in g)
        //            Console.WriteLine(f);
        //        return req;
        //    }
        //}
        // Retourne une collection de vols groupés par destination
        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            // Regrouper les vols par destination
            var req = from f in Flights
                      group f by f.Destination;

            // Affichage des résultats
            foreach (var g in req)
            {
                Console.WriteLine("Destination " + g.Key);
                foreach (var f in g)
                {
                    Console.WriteLine("Décollage : " + f.FlightDate.ToString("dd/MM/yyyy HH:mm:ss"));
                }
            }

            // Retourner la liste des groupes
            return req;
        }

     


        //question 16
        public Action<Plane> FlightDetailsDel;
        public Func<string, double> DurationAverageDe;

        //constructeur
        //question 17 et 18
        public FlightMethods()
        {
            FlightDetailsDel = pl =>
            {
                var req = from f in Flights
                          where f.plane == pl
                          select new { f.FlightDate, f.Destination };


                foreach (var f in req)
                {
                    Console.WriteLine(f);
                }
            };

            DurationAverageDe = dest =>
            {
                var req = from f in Flights
                          where f.Destination == dest
                          select f.EstimationDuration;
                return req.Average();
            };
        }
    


        }


    }



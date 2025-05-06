// See https://aka.ms/new-console-template for more information
using System.Runtime.Intrinsics.X86;
using AM.Applactioncore.Domaine;
using AM.Applactioncore.Services;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using AM.Infrastructeur;
using AM.Infrastructure;
//question7
Plane plane = new Plane();

plane.planeType = planeType.Airbus;
plane.Capacity = 200;
plane.ManufactureDate = DateTime.Now;
plane.ManufactureDate = new DateTime(2024, 03, 04);
Console.WriteLine("Hello, World!");

//question8
Plane plane1 = new Plane(300,DateTime.Now,planeType.Boing);
//question9
Plane plane2 = new Plane { Capacity = 200 };


Console.WriteLine();
Console.WriteLine("******************Testing*************");
Passenger p1 = new Passenger { FullName = new FullName { FirstName = "steve", Lastname = "jobs" }, EmailAddress = "amouna" };
Console.WriteLine("la meth checkpassenger");
Console.WriteLine(p1.CheckProfile1("x","jobs"));
Console.WriteLine(p1.CheckProfile2("steave","jobs","steeve.jobs@gmail.com"));


Staff s1 = new Staff {FullName = new FullName { FirstName = "Mark", Lastname = "Zuckerberg" }, EmailAddress = "Mark.Zuckerberg@gmail.com", function = "steward" };
Traveller t1 = new Traveller {FullName =new FullName { FirstName = "emna", Lastname = "khammassi" }, EmailAddress = "emna.khammassi@gmail.com", HealthInfo = "rien a signaler" };
p1.PassengerType();
s1.PassengerType();
t1.PassengerType();

//TP2
//Question 5
FlightMethods fm = new FlightMethods();
fm.Flights = TestData.listFlights;
Console.WriteLine("Service ");
foreach (var x in fm.GetFlightDates("Paris"))
    Console.WriteLine(x);
//quesion10
fm.ShowFlightDetails(TestData.BoingPlane);


// Filtrer par destination
fm.GetFlights("Destination", "Paris");

//question11
Console.WriteLine("Nombre de vols programmés en une semaine : " + fm.ProgrammedFlightNumber(new DateTime(2022, 01, 01)));



//question12
Console.WriteLine("Moyenne des durées estimées des vols vers Paris : " + fm.DurationAverage("Paris"));


//question13
//Console.WriteLine("Vols triés par durée estimée (du plus long au plus court) :");
//foreach (var flight in fm.OrderedDurationFlights())
//{
//    Console.WriteLine($"Destination: {flight.Destination}, Durée: {flight.EstimationDuration} heures");
//}

//question14
Console.WriteLine("Les 3 voyageurs les plus âgés du vol :");
//foreach (var traveller in fm.SeniorTravellers(fm.Flights.First()))
//{
//    Console.WriteLine($"Nom: {traveller.FullName.FirstName} {traveller.FullName.Lastname}, Date de naissance: {traveller.BrithDate}");
//}
//queston15

Console.WriteLine("Vols groupés par destination :");
fm.DestinationGroupedFlights();


//Les méthodes d’extension

// Création d'un passager
Passenger passenger = new Passenger
{
    FullName = new FullName
    {
        FirstName = "emna",
        Lastname = "khammassi"
    }
};

// Affichage du nom avant la modification
Console.WriteLine($"Avant modification : {passenger.FullName.FirstName} {passenger.FullName.Lastname}");

// Appel de la méthode d'extension
passenger.UpperFullName();

// Affichage du nom après la modification
Console.WriteLine($"Après modification : {passenger.FullName.FirstName} {passenger.FullName.Lastname}");



////insertion dans le BD
//AMContext ctx = new AMContext();

var context = new AMContext(); // ou ton vrai DbContext configuré
IUnitOfWork uow = new UnitOfWork(context);
ServicePlane servicePlane = new ServicePlane(uow);
ServiceFlight serviceFlight = new ServiceFlight(uow);

////instanciation des objets
//Plane palne1 = new Plane
//{
//    planeType = planeType.Airbus,
//    Capacity = 150,
//    ManufactureDate = new DateTime(2015, 02, 03)

//};

//Flight f1 = new Flight
//{
//    Departure = "Tunis",
//    Airline = "Tunisair",
//    FlightDate = new DateTime(2022, 02, 01, 21, 10, 10),
//    Destination = "Paris",
//    EffectiveArrival = new DateTime(2022, 02, 01, 23, 10, 10),
//    EstimationDuration = 105,
//    plane = plane1
//};

////instanciation des objets
servicePlane.Add(TestData.Airbusplane);
servicePlane.Add(TestData.BoingPlane);
servicePlane.Add(plane1);
servicePlane.Commit();


////Ajout des objets aux bdset
//ctx.Planes.Add(TestData.Airbusplane);
//ctx.Planes.Add(TestData.BoingPlane);
//ctx.Flights.Add(f1);




////persister les données 
//ctx.SaveChanges();
//Console.WriteLine("Ajout effectuée avec succées");

////persister les données
//foreach (Flight f in ctx.Flights) 
//    Console.WriteLine("Date: "+f.FlightDate+"Des:"+f.Destination
//        +""+"plane capacité"+f.plane.Capacity)
//        ;






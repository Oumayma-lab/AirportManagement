using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AM.Applactioncore.Domaine
{
    public class Staff : Passenger
    {
        public DateTime EmployementDate { get; set; }
        public string function { get; set; }

        //doit être une valeur monétaire

        [DataType(DataType.Currency)]
        public int Salary { get; set; }
    

    public override void PassengerType()
        {
            base.PassengerType();
            Console.WriteLine("and I'm a traveller");
        } }
}

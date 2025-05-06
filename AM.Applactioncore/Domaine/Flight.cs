using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AM.Applactioncore.Domaine
{
    public class Flight
    {
        public int FlightId { get; set; } //classId

        [ForeignKey("planeFK")] // ou bien [ForeignKey("plane")]

        public virtual Plane plane { get; set; }
        public int planeFK { get; set; }


        public string Destination { get; set; }
        public string Departure { get; set; }
        public DateTime FlightDate { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public int EstimationDuration { get; set; }
        //public ICollection<Passenger> passengers { get; set; }

        public virtual ICollection<Ticket> tickets { get; set; }

        public string Airline { get; set; }



    }
}

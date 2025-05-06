using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Applactioncore.Domaine
{
    public class Passenger
    {
        //public int Id { get; set; }
        [Key]
        [StringLength(7)]
        public string PassportNumber { get; set; }

       

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime BrithDate { get; set; }

        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [RegularExpression("^[0,9]{8}$")]
        public int TelNumber { get; set; }


        //public ICollection<Flight> flights { get; set; }
        public virtual ICollection<Ticket> tickets { get; set; }


        public override string? ToString()
        {
            return "Date" + BrithDate;
        }


        //[Required(ErrorMessage = "Le prénom est obligatoire.")]
        //[StringLength(25, MinimumLength = 3, ErrorMessage = "Le prénom doit contenir entre 3 et 25 caractères.")]
        //public string FirstName { get; set; }



        public FullName FullName { get; set; }

        //question10-a
        public bool CheckProfile1(string firstName, string lastName)
        {
            return FullName.FirstName == firstName && FullName.Lastname == lastName;
        }
        //question10-b
        public bool CheckProfile2(string firstName, string lastName, string email) {
            return FullName.FirstName == firstName && FullName.Lastname == lastName && EmailAddress == email;
        }
        //question10-c

         public bool CheckProfile3(string firstName, string lastName, string email = null)

         {   if(email != null) 
             return FullName.FirstName == firstName && FullName.Lastname == lastName && EmailAddress == email;
         else
                 return FullName.FirstName == firstName && FullName.Lastname == lastName;

         }


        //question11
        public virtual void PassengerType()
        {
            Console.WriteLine("i am a passenger");
        }
    }
}

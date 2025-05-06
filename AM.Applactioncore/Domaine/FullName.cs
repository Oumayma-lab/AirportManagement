using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Applactioncore.Domaine
{
    public class FullName

    {
        [MinLength(3, ErrorMessage = "FirstName must be at least 3 characters long.")]
        [MaxLength(25, ErrorMessage = "FirstName cannot exceed 25 characters.")]
        public string FirstName { get; set; }
        public string Lastname { get; set; }
    }
}

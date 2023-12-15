using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pleberr.Models
{
    public class User
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string School { get; set; }
        public string Work { get; set; }
        public string Location { get; set; }
        public string Relationship { get; set; }
        public DateTime Birthdate { get; set; }
        public int? Weight { get; set; }
        public double? Height { get; set; }
        public string Friends { get; set; }
        public bool Online { get; set; }
        public string Gender { get; set; }
        public string Email2 { get; set; }
        public string Telephone { get; set; }
    }
}

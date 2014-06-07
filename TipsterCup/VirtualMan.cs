using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipsterCup
{
    public class VirtualMan
    {

        public int Id { get; set;}
        public String FirstName {get; set;}
        public String LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public VirtualMan(int id, String firstName, String lastName, DateTime dateOfBirth)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }
    }
}

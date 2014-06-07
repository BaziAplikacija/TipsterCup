using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipsterCup
{
    public class Manager : VirtualMan
    {

        public Double Experience { get; set; }

        public Manager(int id, String firstName, String lastName, DateTime dateOfBirth, double experience)
            : base(id, firstName, lastName, dateOfBirth)
        {
            Experience = experience;
        }
    }
}

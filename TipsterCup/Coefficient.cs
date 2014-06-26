using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipsterCup
{
    public class Coefficient
    {
        public int IdShowCoeff { get; set; }
        public int IdCoefficient { get; set; }
        public int IdMatch { get; set; }
        public double Value { get; set; }
        public String Description { get; set; }


        public Coefficient(int idShowCoeff, int idCoefficient, int idMatch, double value, String description)
        {
            IdShowCoeff = idShowCoeff;
            IdCoefficient = idCoefficient;
            IdMatch = idMatch;
            Value = value;
            Description = description;
        }

        public override string ToString()
        {
            return Description + " " + Value.ToString();
        }
        

    }
}

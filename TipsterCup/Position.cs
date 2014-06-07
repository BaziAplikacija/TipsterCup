using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipsterCup
{
    public class Position
    {
        //IDPOSITION	NAME	FACTORGOAL	FACTORASSISTS	FACTORINTERRUPTS	FACTORSAVE

        public int Id { get; set; }
        public String Description { get; set; }
        public double FactorGoal { get; set; }
        public double FactorAssist { get; set; }
        public double FactorInterrupt { get; set; }
        public double FactorSave { get; set; }

        // FactorGoal + FactorAssist + Factor Interrupt + FactorSave == 1

        public Position(int id, String description, double factorGoal, double factorAssist, double factorInterrupt, double factorSave)
        {
            if (Math.Abs((factorGoal + factorAssist + factorInterrupt + factorSave) - 1) > 0.000001)
            {
                throw new Exception("ZBIROT NA FAKTORITE MORA DA BIDE EDNAKOV NA 1");
            }

            Id = id;
            Description = description;
            FactorGoal = factorGoal;
            FactorAssist = factorAssist;
            FactorInterrupt = factorInterrupt;
            FactorSave = factorSave;
        }

        
    }
}

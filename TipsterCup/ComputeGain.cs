using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipsterCup
{
    class ComputeGain
    {
        //IDTIPSTER	IDCOEFFICIENT	DESCRIPTION	AMOUNT	VALUE	IDMATCH	IDROUND	GOALSHOME	GOALSGUEST	VALIDATED

        public int IdTipster { get; set; }
        public int IdCoefficient { get; set; }
        public String Description { get; set; }
        public int Amount { get; set; }
        public Double Value { get; set; }
        public int IdMatch { get; set; }
        public int IdRound { get; set; }
        public int GoalsHome { get; set; }
        public int GoalsGuest { get; set; }
        public String Validated { get; set; } // dali e presmetan ovoj tiket

        public ComputeGain(int idTipster, int idCoefficient, String description, int amount, double value, int idMatch, int idRound, int goalsHome, int goalsGuest, String validated)
        {
            IdTipster = idTipster;
            IdCoefficient = idCoefficient;
            Description = description;
            Amount = amount;
            Value = value;
            IdMatch = idMatch;
            IdRound = idRound;
            GoalsHome = goalsHome;
            GoalsGuest = goalsGuest;
            Validated = validated;
        }


        public Double GetGain()
        {
            return Amount * Value;
        }

        public Boolean IsWinning()
        {
            if (IdCoefficient == 1)
            {
                return GoalsHome > GoalsGuest;
            }

            if (IdCoefficient == 2)
            {
                return GoalsHome == GoalsGuest;
            }

            if (IdCoefficient == 3)
            {
                return GoalsHome < GoalsGuest;
            }

            if (IdCoefficient == 4)
            {
                return GoalsHome + GoalsGuest <= 2;
            }

            if (IdCoefficient == 5)
            {
                return GoalsHome + GoalsGuest >= 3;
            }

            if (IdCoefficient == 6)
            {
                return GoalsHome + GoalsGuest >= 4;
            }
            return GoalsHome + GoalsGuest >= 7;
        }

    }
}

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

        public Boolean IsWinning()
        {
            return true;
        }

    }
}

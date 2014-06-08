using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipsterCup
{
    public class Round : IComparable<Round>
    {
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }


        List<Match> Matches { get; set; }

        public Round(int id, DateTime dateFrom, DateTime dateTo)
        {
            Id = id;
            DateFrom = dateFrom;
            DateTo = dateTo;
            Matches = new List<Match>();
        }


        public void addMatch(Match match)
        {
            Matches.Add(match);
        }

        

        public int CompareTo(Round other)
        {
            return Id - other.Id;
        }
    }
}

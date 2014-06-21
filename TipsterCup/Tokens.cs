using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipsterCup
{
    class Tokens
    {
        public int FirstToken { get; set; }
        public int LastToken { get; set; }

        public Tokens(int firstToken, int lastToken)
        {
            FirstToken = firstToken;
            LastToken = lastToken;
        }


    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipsterCup
{
    class Tipster
    {
        public int IdTipster { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public int Money { get; set; }
        public String Email { get; set; }
        public string Valid { get; set; }

        public Tipster(int idTipster, String username, String password, String name, String surname, int money, String email, String valid)
        {
            this.IdTipster = idTipster;
            this.Username = username;
            this.Password = password;
            this.Name = name;
            this.Surname = surname;
            this.Money = money;
            this.Email = email;
            this.Valid = valid;
        }

        public override string ToString()
        {
            return String.Format("{0,-20}\t{1}", Username, Money);
        }
    }
}

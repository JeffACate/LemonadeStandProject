﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Customer
    {
        private List<string> names;
        public string name;

        public Customer(Random rng)
        {
            names = new List<string> { "Jeff", "John", "James", "Sarah", "Nathan", "Liam", "Noah", "William", "James", "Benjamin", "Elijah", "Lucas", "Mason", "Logan"};
            name = names[rng.Next(0, names.Count)];
        }
    }
}

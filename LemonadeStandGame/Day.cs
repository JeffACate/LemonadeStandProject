using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Day
    {
        public Weather weather;
        public List<Customer> customers;

        public Day(Random rng)
        {
            weather = new Weather(rng);
            customers = new List<Customer>();
            CreateCustomersList(rng);
        }

        private void CreateCustomersList(Random rng)
        {
            int numberOfCustomers = rng.Next(0,100);
            for (int i = 0; i < numberOfCustomers; i++)
            {
                customers.Add(new Customer(rng));
            }
        }
    }
}

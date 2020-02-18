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
        public void DisplayWeather(int day)
        {
            Console.WriteLine("Today, day " + day + ", will be: " + weather.temperature + "° and " + weather.condition);
        }
        private void CreateCustomersList(Random rng)
        {
            int numberOfCustomers = rng.Next(0, 100);
            for (int i = 0; i < numberOfCustomers; i++)
            {
                customers.Add(new Customer(rng));
            }
        }
        public void FactorWeather(Customer customer)
        {
            switch (weather.condition)
            {
                case "sunny":
                    customer.buyProbability += 10;
                    break;
                case "rainy":
                    customer.buyProbability -= 10;
                    break;
            }
        }
        public void FactorTemperature(Customer customer)
        {
            
            if (weather.temperature >= 100)
            {
                customer.buyProbability += 15;
            }
            else if(weather.temperature >= 90)
            {
                customer.buyProbability += 10;
            }
            else if(weather.temperature >= 80)
            {
                customer.buyProbability += 5;
            }
        }
    }
}

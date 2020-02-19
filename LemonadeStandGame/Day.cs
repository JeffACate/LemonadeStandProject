using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Day
    {
        //open weather api
            // how to make and api call
            // learn to use api call
        public Weather weather;
        public List<Customer> customers;

        public Day(Random rng, int numberOfCustomers)
        {
            weather = new Weather(rng);
            customers = new List<Customer>();
            CreateCustomersList(numberOfCustomers, rng);
        }
        //SOLID PRINCIPLE ~~ SUBSTITUTION ~~ CAN CHANGE NUMBER OF CUSTOMERS BY PASSING IN AN INTEGER
        private void CreateCustomersList(int numberOfCustomers, Random rng)
        {
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

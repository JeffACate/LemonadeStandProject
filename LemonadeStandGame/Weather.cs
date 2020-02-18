using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Weather
    {
        public string condition;
        public int temperature;
        List<string> weatherConditions;

        public Weather(Random rng)
        {
            weatherConditions = new List<string>{ "sunny", "cloudy", "sunny", "rainy", "cloudy", "sunny" };
            condition = weatherConditions[rng.Next(0, weatherConditions.Count)];
            temperature = rng.Next(60, 110);
        }

    }
}

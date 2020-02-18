using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();
            Game game = new Game();
            //game.RunGame();
            game.GenerateDays(rng);
            for (int i = 0; i < game.days.Count; i++)
            {
                Console.WriteLine($"      Day : {i+1}" + "\n" +
                                  "    Weather: " + game.days[i].weather.condition + "\n" +
                                  "Temperature: " + game.days[i].weather.temperature + "\n");
                int customerCount = 1;
                foreach (Customer customer in game.days[i].customers)
                {
                    Console.WriteLine($"Customer {customerCount}:" + customer.name);
                    customerCount++;
                }
                Console.WriteLine("customers count: " + game.days[i].customers.Count);
                
            }
            Console.WriteLine("days count " + game.days.Count);
            Console.ReadKey();
        }
    }
}

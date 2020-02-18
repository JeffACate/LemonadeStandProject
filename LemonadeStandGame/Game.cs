using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Game
    {
        Player player;
        List<Day> days;
        int currentDay;
        //public Random randomNumberGenerator;  
        Store store = new Store();
        
        public Game()
        {

            player = new Player("Jeff" /* GetPlayerName() */);
            currentDay = 1;
            days = new List<Day>() { new Day() };
            /* 1
             * ADD ==> MULTIPLE NUMBER OF DAYS
             * =====================================
             * days = new List<Day>(GenerateDays());
             * for (int i = 0; i < days.Count; i++)
             * {
             *      Console.WriteLine($"{days[i]} {i+1}");
             * }
             * =====================================
             */


            /*
             *ADD ==> USER INPUT FOR NUMBER OF DAYS
             * ===================================
             * 
             * currentDay = 0 or 1;
             * days = GenerateDays();
             * Console.ReadKey();
            */
        }
        private string GetPlayerName()
        {
            Console.Write("What is your name?");
            return Console.ReadLine();
        }

        private List<Day> GenerateDays()
        {
            List<Day> localDays = new List<Day>();
            try
            {
                Console.WriteLine("How many days would you like to play? ");
                int daysToPlay = 7;// Player picks number of days ===> Int32.Parse(Console.ReadLine());

                if (daysToPlay > 7)
                {
                    throw new ArithmeticException("Too Many Days! Please enter a smaller number.");
                }
                else
                {
                    for (int i = 0; i <= daysToPlay-1; i++)
                    {
                        localDays.Add(new Day());
                    }
                    return localDays;
                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return GenerateDays();
            }
        }
        public void RunGame()
        {
            DisplayRules();
            player.GetReady();
            StartDay();
            

            // Sell Lemonade


             
        }
        private void DisplayRules()
        {
            Console.WriteLine("Welcome to the lemonade stand game."     + "\n" +
                              "Your task is to sell lemonade. You"      + "\n" +
                              "will start with ${0} and no supplies"    + "\n" +
                              "the weather and price  will affect the"  + "\n" +
                              "customer's willingness to buy."          + "\n" +
                              "--------------------------------------",player.wallet.Money);
        }
        private void StartDay()
        {
            //DisplayWeather();
            while (true)
            {
                int task = ChooseTask();
                switch (task)
                {
                    case 0:
                        store.PurchaseItems(player);
                        break;
                    case 1:
                        player.EditRecipe();
                        break;
                    case 2:
                        player.MakeLemonade();
                        break;
                    case 3:
                        SimulateDay();
                        break;
                }
                player.GetReady();
            }
        }
        private int ChooseTask()
        {
            int task = -1;
            while (task < 0 || task > 4)
            {
                Console.Write("What would you like to do? " + "\n" +
                              "  0) Go to store" + "\n" +
                              "  1) Edit recipe" + "\n" +
                              "  2) Make lemonade" + "\n" +
                              "  3) Sell lemonade" +
                            "\n  ");
                task = Console.ReadKey().KeyChar - '0';
                Console.WriteLine();
            }
            return task;
        }

        private void SimulateDay()
        {

        }
    }
}
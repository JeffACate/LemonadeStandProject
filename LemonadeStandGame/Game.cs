using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Game
    {
        private Player player;
        public List<Day> days;
        private int currentDay;
        private Random rng;  
        private Store store = new Store();
        private int numberOfDays;
        public Game()
        {
            rng = new Random();
            player = new Player("Jeff" /* GetPlayerName() */);
            currentDay = 0;
            numberOfDays = 7;
            days = new List<Day>();
            GenerateDays(rng);
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

        public void GenerateDays(Random rng)
        {
            for (int i = 0; i < numberOfDays; i++)
            {
                days.Add(new Day(rng));
            }
            //List<Day> localDays = new List<Day>();
            //try
            //{
            //    Console.WriteLine("How many days would you like to play? ");
            //    int daysToPlay = 7;// Player picks number of days ===> Int32.Parse(Console.ReadLine());

            //    if (daysToPlay > 7)
            //    {
            //        throw new ArithmeticException("Too Many Days! Please enter a smaller number.");
            //    }
            //    else
            //    {
            //        for (int i = 0; i <= daysToPlay-1; i++)
            //        {
            //            localDays.Add(new Day());
            //        }
            //        return localDays;
            //    }

            //}
            //catch(Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //    return GenerateDays();
            //}
        }
        public void RunGame()
        {
            currentDay = 1;
            for (int i = 0; i < days.Count; i++)
            {
                StartDay();
                currentDay++;
            }
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
            bool isDayOver = false;
            while (isDayOver == false)
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
                        SimulateDay(days[currentDay-1]);
                        isDayOver = true;
                        break;
                }
            }
        }
        private int ChooseTask()
        {
            int task = -1;
            while (task < 0 || task > 4)
            {
                DisplayRules();
                days[currentDay-1].DisplayWeather(currentDay);
                player.GetReady();
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("What would you like to do? " + "\n" +
                              "  0) Go to store" + "\n" +
                              "  1) Edit recipe" + "\n" +
                              "  2) Make lemonade" + "\n" +
                              "  3) Sell lemonade");
                task = Console.ReadKey().KeyChar - '0';
                Console.WriteLine();
            }
            return task;
        }
        private void SimulateDay(Day today)
        {
            // SIMULATE DAY
            // FOREACH CUSTOMER
            for (int i = 0; i < today.customers.Count; i++)
            {
                today.FactorWeather(today.customers[i]);
                today.FactorTemperature(today.customers[i]);
                double costOfLemonade = CalculateLemonadeCost(player.recipe, store);
                if( player.recipe.pricePerCup /costOfLemonade *100 >= 500)
                {
                    today.customers[i].buyProbability -= 10;
                }
                else if(player.recipe.pricePerCup / costOfLemonade *100 <= 200)
                {
                    today.customers[i].buyProbability += 10;
                }
                bool willCustomerBuy = today.customers[i].RollToSeeIfIWillBuy(rng);
                //PERFORM TRANSACTION
                if (willCustomerBuy == true && player.pitcher.cupsLeftInPitcher > 0)
                {
                    player.SellLemonade();
                    Console.WriteLine("Lemonade sold!!");
                }
                else if(willCustomerBuy == true)
                {
                    Console.WriteLine("Sorry, we're sold out.");
                }
                else if(willCustomerBuy == false)
                {
                    Console.WriteLine("No, thank you.");
                }
            }
        }
        private double CalculateLemonadeCost(Recipe recipe, Store store)
        {
            double costOfLemonade = 0;
            costOfLemonade += recipe.amountOfLemons * store.PricePerLemon;
            costOfLemonade += recipe.amountOfSugarCubes * store.PricePerIceCube;
            costOfLemonade += recipe.amountOfIceCubes * store.PricePerIceCube;
            costOfLemonade += store.PricePerCup;
            return costOfLemonade;
        }
    }
}
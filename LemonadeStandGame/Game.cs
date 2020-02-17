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
            DisplayInventory();
            DisplayWallet();
            StartDay();
            

            // Sell Lemonade


             
        }
        private void DisplayRules()
        {
            Console.WriteLine("Display Rules" + "\n" +
                              "-----------------");
        }
        private void DisplayWallet()
        {
            Console.WriteLine("You have: ${0}", player.wallet.Money);
            Console.WriteLine("----------------\n");
        }
        private void DisplayInventory()
        {
            Console.WriteLine("You have:\n" +
                              "     {0} Lemons" + "\n" +
                              "     {1} Sugar cubes" + "\n" +
                              "     {2} Ice Cubes" + "\n" +
                              "     {3} Cups", 
                              player.inventory.lemons.Count, 
                              player.inventory.sugarCubes.Count,
                              player.inventory.iceCubes.Count,
                              player.inventory.cups.Count);
        }
        private void StartDay()
        {
            //DisplayWeather();
            //Buy Supplies

            int task = ChooseTask();
            switch (task)
            {
                case 0:
                    store.PurchaseItems(player);
                    break;
                case 1:
                    
                    break;
                case 2:
                    break;
            }
        }
        private int ChooseTask()
        {
            int task = -1;
            while (task < 0 || task > 1)
            {
                Console.Write("What would you like to do? " + "\n" +
                              "  0) Go to store" + "\n" +
                              "  1) Edit Recipe" + "\n" +
                              "  2) Start Day" + "\n");
                task = Console.ReadKey().KeyChar - '0';
                Console.WriteLine();
            }
            return task;
        }
    }
}
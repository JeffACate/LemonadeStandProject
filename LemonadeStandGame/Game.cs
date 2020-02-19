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
        private int totalNumberOfSales;
        private int totalNumberOfCustomers;
        // private int numberOfDays;
        public Game()
        {
            rng = new Random();
            player = new Player(UserInterface.GetPlayerName());
            currentDay = 0;
            int numberOfDays = 7;
            days = new List<Day>();
            GenerateDays(rng, numberOfDays);
        }
        public void GenerateDays(Random rng, int numberOfDays)
        {

            for (int i = 0; i < numberOfDays; i++)
            {
                int numberOfCustomers = rng.Next(20, 100);
                days.Add(new Day(rng, numberOfCustomers));
            }
            
        }
        public void RunGame()
        {
            currentDay = 1;
            for (int i = 0; i < days.Count; i++)
            {
                StartDay();
                currentDay++;
            }
            UserInterface.DisplayEndOfGameReport(player.name,totalNumberOfSales, totalNumberOfCustomers);
        }
        
        private void StartDay()
        {
            bool isDayOver = false;
            while (isDayOver == false)
            {
                int task = UserInterface.ChooseTask(player, days, currentDay);
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
        private void SimulateDay(Day today)
        {
            double costOfLemonade = CalculateLemonadeCost(player.recipe, store);
            // SIMULATE DAY
            int cupsSoldToday = 0;
            // FOREACH CUSTOMER
            for (int i = 0; i < today.customers.Count; i++)
            {
                today.FactorWeather(today.customers[i]);
                today.FactorTemperature(today.customers[i]);
                FactorPrice(today.customers[i], costOfLemonade);
                bool willCustomerBuy = today.customers[i].RollToSeeIfIWillBuy(rng);
                //PERFORM TRANSACTION
                if (willCustomerBuy == true && player.pitcher.cupsLeftInPitcher > 0)
                {
                    player.SellLemonade();
                    cupsSoldToday++;
                    totalNumberOfSales++;
                }
            }
            UserInterface.DisplayEndOfDayReport(cupsSoldToday, today.customers.Count);
            totalNumberOfCustomers += today.customers.Count;
        }
        private double CalculateLemonadeCost(Recipe recipe, Store store)
        {
            double costOfLemonade = 0;
            costOfLemonade += recipe.amountOfLemons * store.PricePerLemon;
            costOfLemonade += recipe.amountOfSugarCubes * store.PricePerSugarCube;
            costOfLemonade += recipe.amountOfIceCubes * store.PricePerIceCube;
            costOfLemonade += store.PricePerCup;
            return costOfLemonade;
        }
        private void FactorPrice(Customer customer, double costOfLemonade)
        {
            if (player.recipe.pricePerCup / costOfLemonade * 100 >= 500)
            {
                customer.buyProbability -= 10;
            }
            else if (player.recipe.pricePerCup / costOfLemonade * 100 <= 200)
            {
                customer.buyProbability += 10;
            }
        }
    }
}
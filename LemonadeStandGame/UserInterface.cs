using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    static class UserInterface
    {
        public static int GetNumberOfItems(string itemsToGet)
        {
            bool userInputIsAnInteger = false;
            int quantityOfItem = -1;

            while (!userInputIsAnInteger || quantityOfItem < 0)
            {
                Console.WriteLine("How many " + itemsToGet + " would you like to buy?");
                Console.Write("Please enter a positive integer (or 0 to cancel):");
                Console.WriteLine();

                userInputIsAnInteger = Int32.TryParse(Console.ReadLine(), out quantityOfItem);
            }

            return quantityOfItem;
        }
        public static int GetNumberOfItemsInRecipe(string itemToUse)
        {
            bool isInvalidInput = false;
            int numberOfItems = -1;

            while (!isInvalidInput || numberOfItems < 0)
            {
                Console.WriteLine("How many " + itemToUse + " would you like to use?");
                Console.Write("Please enter a positive integer: ");
                Console.WriteLine();

                isInvalidInput = Int32.TryParse(Console.ReadLine(), out numberOfItems);
            }
            return numberOfItems;
        }
        public static string GetPlayerName()
        {
            Console.Write("What is your name? ");
            return Console.ReadLine();
        }
        public static void DisplayRules(Player player)
        {
            Console.WriteLine("Welcome, {0}, to the lemonade stand game." + "\n" +
                              "Your task is to sell lemonade. You" + "\n" +
                              "will start with ${1} and no supplies" + "\n" +
                              "the weather and price  will affect the" + "\n" +
                              "customer's willingness to buy." + "\n" +
                              "--------------------------------------", player.name, player.wallet.Money);
        }
        public static int ChooseTask(Player player, List<Day> days, int currentDay)
        {
            int task = -1;
            while (task < 0 || task > 4)
            {
                DisplayRules(player);
                DisplayWeather(currentDay, days[currentDay - 1].weather);
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
        public static void DisplayEndOfDayReport(int cupsSoldToday, int potentialCustomers)
        {
            Console.WriteLine("You sold {0} cups of lemonade to {1} potential customers",cupsSoldToday,potentialCustomers);
        }
        public static void DisplayWallet(Wallet wallet)
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("You have: ${0}", wallet.Money);
            Console.WriteLine("--------------------------------------");
        }
        public static void DisplayInventory(Inventory inventory, Pitcher pitcher)
        {
            Console.WriteLine("You have:\n" +
                              "  {0} Lemons" + "\n" +
                              "  {1} Sugar cubes" + "\n" +
                              "  {2} Ice Cubes" + "\n" +
                              "  {3} Cups" + "\n" +
                              "  {4} Cups in your pitcher",
                              inventory.lemons.Count,
                              inventory.sugarCubes.Count,
                              inventory.iceCubes.Count,
                              inventory.cups.Count,
                              pitcher.cupsLeftInPitcher);
        }
        public static void DisplayRecipe(Recipe recipe)
        {
            Console.WriteLine("Your Recipe:" + "\n" +
                              "  {0} Lemons" + "\n" +
                              "  {1} Sugar cubes" + "\n" +
                              "  {2} Ice cubes" + "\n" +
                              "in each cup for: " + "\n" +
                              "  ${3} Price per cup" + "\n",
                              recipe.amountOfLemons,
                              recipe.amountOfSugarCubes,
                              recipe.amountOfIceCubes,
                              recipe.pricePerCup);
        }
        public static int PickItemToChange()
        {
            int itemToChange = -1;
            while (itemToChange < 0 || itemToChange > 4)
            {
                Console.Write("What would you like to change? \n");
                Console.WriteLine("    0) Lemons" + "\n" +
                                  "    1) Sugar cubes" + "\n" +
                                  "    2) Ice Cubes" + "\n" +
                                  "    3) Price per up" + "\n" +
                                  "    4) Exit");
                itemToChange = Console.ReadKey().KeyChar - '0';
                Console.WriteLine();
            }
            return itemToChange;
        }
        public static void DisplayNumberOfCupsYouCanMake(int maxNumberOfCups)
        {
            Console.WriteLine("Number of cups you can make: " + maxNumberOfCups);
        }
        public static double ChangePricePerCup()
        {
            try
            {
                Console.Write("How much would you like to charge per cup(in dollars $.$$)? ");
                double pricePerCup = Double.Parse(Console.ReadLine());
                return pricePerCup;
            }
            catch
            {
                return ChangePricePerCup();
            }
        }
        public static void DisplayWeather(int day, Weather weather)
        {
            Console.WriteLine("Today, day " + day + ", will be: " + weather.temperature + "° and " + weather.condition);
        }
        public static void RejectTransaction()
        {
            Console.WriteLine("You do not have enough money!");
        }
        public static int ChooseItemToBuy()
        {
            int task = -1;
            Console.Write("What would you like to buy? ");
            task = Console.ReadKey().KeyChar - '0';
            Console.WriteLine();
            while (task < 0 || task > 4)
            {
                Console.WriteLine("Ivalid item!! Please try again.");
                Console.Write("What would you like to buy? ");
                task = Console.ReadKey().KeyChar - '0';
                Console.WriteLine();
            }
            return task;
        }
        public static void DisplayStore(double pricePerLemon, double pricePerSugarCube, double pricePerIceCube, double pricePerCup)
        {
            Console.WriteLine("Store Prices: " + "\n" +
                          "  0) Lemons cost      : $ {0}" + "\n" +
                          "  1) Sugar cubes cost : $ {1}" + "\n" +
                          "  2) Ice cubes cost   : $ {2}" + "\n" +
                          "  3) Cups cost        : $ {3}" + "\n" +
                          "  4) EXIT",
                          pricePerLemon,
                          pricePerSugarCube,
                          pricePerIceCube,
                          pricePerCup);
        }
        public static void DisplayEndOfGameReport(string name, int totalNumberOfSales, int totalNumberOfCustomers)
        {
            Console.WriteLine("{0} sold {1}, cups of lemonade to {2} potential customers.",name, totalNumberOfSales,totalNumberOfCustomers);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Player
    {
        // member variables (HAS A)
        public string name;
        public Inventory inventory;
        public Wallet wallet;
        public Recipe recipe;
        public Pitcher pitcher;


        // constructor (SPAWNER)
        public Player(string name)
        {
            this.name = name;
            inventory = new Inventory();
            wallet = new Wallet();
            recipe = new Recipe();
            pitcher = new Pitcher();
        }
        // member methods (CAN DO)
        public void GetReady()
        {
            DisplayWallet();
            DisplayInventory();
        }
        private void DisplayWallet()
        {
            Console.WriteLine("You have: ${0}", wallet.Money);
            Console.WriteLine("----------------\n");
        }
        private void DisplayInventory()
        {
            Console.WriteLine("You have:\n" +
                              "     {0} Lemons" + "\n" +
                              "     {1} Sugar cubes" + "\n" +
                              "     {2} Ice Cubes" + "\n" +
                              "     {3} Cups",
                              inventory.lemons.Count,
                              inventory.sugarCubes.Count,
                              inventory.iceCubes.Count,
                              inventory.cups.Count);
        }

        public void EditRecipe()
        {
            int itemToChange = -1;
            while (itemToChange != 4 &&
                 (itemToChange < 0 || itemToChange > 3))
            {
                DisplayRecipe();
                itemToChange = PickItemToChange();
                ChangeHowMuchToUse(itemToChange);
            }
        }
        private void DisplayRecipe()
        {
            Console.WriteLine("You have:\n" +
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
        private int PickItemToChange()
        {
            try
            {
                int itemToChange = -1;
                while (itemToChange < 0 || itemToChange > 3)
                {
                    Console.Write("What would you like to change? ");
                    Console.WriteLine("    0) Lemons" + "\n" +
                                      "    1) Sugar cubes" + "\n" +
                                      "    2) Ice Cubes" + "\n" +
                                      "    3) Price per up" + "\n" +
                                      "    4) Exit");
                    itemToChange = Console.ReadKey().KeyChar - '0';
                    Console.WriteLine();
                    if (itemToChange < 0 || itemToChange > 3)
                    {
                        throw new IndexOutOfRangeException("Invalid input.");
                    }
                    Console.WriteLine();
                }
                return itemToChange;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\nPlease try again. ");
                return PickItemToChange();
            }
        }
        private void ChangeHowMuchToUse(int itemToChange)
        {
            bool validNumberOfItems = false;
            while ((itemToChange != 3 || itemToChange != 4) && // the user does not want to quit or change the price
                   (itemToChange < 0 || itemToChange > 4) &&// the users input is between 0 and 5
                   validNumberOfItems == false) // user has that number of items in their inventory
            {
                switch (itemToChange)
                {
                    case 0:
                        recipe.amountOfLemons = UserInterface.GetNumberOfItemsInRecipe("lemons");
                        validNumberOfItems = CheckInventory(inventory.lemons[1].name);
                        break;
                    case 1:
                        recipe.amountOfSugarCubes = UserInterface.GetNumberOfItemsInRecipe("sugar cubes");
                        validNumberOfItems = CheckInventory(inventory.sugarCubes[1].name);
                        break;
                    case 2:
                        recipe.amountOfIceCubes = UserInterface.GetNumberOfItemsInRecipe("ice cubes");
                        validNumberOfItems = CheckInventory(inventory.iceCubes[1].name);
                        break;
                }

            }
            if(itemToChange == 3)
            {
                ChangePricePerCup();
            }
            
        }
        private bool CheckInventory(string itemToCheck)
        {
            if(itemToCheck == "lemons" && recipe.amountOfLemons > inventory.lemons.Count)
            {
                return true;
            }
            else if (itemToCheck == "sugar cubes" && recipe.amountOfSugarCubes > inventory.sugarCubes.Count)
            {
                return true;
            }
            else if (itemToCheck == "ice cubes" && recipe.amountOfIceCubes > inventory.iceCubes.Count)
            {
                return true;
            }
            return false;
        }
        private void ChangePricePerCup()
        {
            Console.Write("How much would you like to charge per cup? ");
            recipe.pricePerCup = Int32.Parse(Console.ReadLine());
        }
    }
}

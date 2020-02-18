using System;

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

        // SOLID PRINCIPLE ~~ single responsibility ~~
        private void DisplayWallet()
        {
            Console.WriteLine("You have: ${0}", wallet.Money);
            Console.WriteLine("--------------------------------------");
        }
        private void DisplayInventory()
        {
            Console.WriteLine("You have:\n" +
                              "  {0} Lemons" + "\n" +
                              "  {1} Sugar cubes" + "\n" +
                              "  {2} Ice Cubes" + "\n" +
                              "  {3} Cups",
                              inventory.lemons.Count,
                              inventory.sugarCubes.Count,
                              inventory.iceCubes.Count,
                              inventory.cups.Count);
        }
        public void EditRecipe()
        {
            bool continueEditingRecipe = true;
            while (continueEditingRecipe == true)
            {
                DisplayRecipe();
                int itemToChange = PickItemToChange();
                if (itemToChange != 4)
                {
                    ChangeHowMuchToUse(itemToChange);
                }
                else
                {
                    continueEditingRecipe = false;
                }
            }
        }
        private void DisplayRecipe()
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
        private int PickItemToChange()
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
        private void ChangeHowMuchToUse(int itemToChange)
        {
            bool validNumberOfItems = false;
            while (validNumberOfItems == false) // user has that number of items in their inventory
            {
                switch (itemToChange)
                {
                    case 0:
                        recipe.amountOfLemons = UserInterface.GetNumberOfItemsInRecipe("lemons");
                        validNumberOfItems = CheckInventory("lemons");
                        break;
                    case 1:
                        recipe.amountOfSugarCubes = UserInterface.GetNumberOfItemsInRecipe("sugar cube");
                        validNumberOfItems = CheckInventory("sugar cube");
                        break;
                    case 2:
                        recipe.amountOfIceCubes = UserInterface.GetNumberOfItemsInRecipe("ice cube");
                        validNumberOfItems = CheckInventory("ice cube");
                        break;
                    case 3:
                        ChangePricePerCup();
                        validNumberOfItems = true;
                        break;
                }
            }

        }
        private bool CheckInventory(string itemToCheck)
        {
            if (itemToCheck == "lemons" && recipe.amountOfLemons <= inventory.lemons.Count)
            {
                return true;
            }
            else if (itemToCheck == "sugar cube" && recipe.amountOfSugarCubes <= inventory.sugarCubes.Count)
            {
                return true;
            }
            else if (itemToCheck == "ice cube" && recipe.amountOfIceCubes <= inventory.iceCubes.Count)
            {
                return true;
            }
            return false;
       }
        //  SOLID PRINCIPLE ~~ single responsibility ~~
        private void ChangePricePerCup()
        {
            Console.Write("How much would you like to charge per cup(in dollars $.$$)? ");
            recipe.pricePerCup = Double.Parse(Console.ReadLine());
        }
        public void MakeLemonade()
        {
            // how many to subtract from that item from inventory = number of cups made * number of items in recipe
            int amountToSubtractFromInventory;
            int maxNumberOfCups = HowMuchLemonadeCanIMake();
            amountToSubtractFromInventory = recipe.amountOfLemons * maxNumberOfCups;
        }

        private int HowMuchLemonadeCanIMake()
        {
            int maxNumberOfCups = inventory.cups.Count;
            int remainderOfLemons = inventory.lemons.Count % recipe.amountOfLemons;
            //lemons
            maxNumberOfCups = Math.Min(((inventory.lemons.Count / recipe.amountOfLemons) - remainderOfLemons), maxNumberOfCups);
            // ice cubes
            int remainderOfIceCubes = inventory.iceCubes.Count % recipe.amountOfIceCubes;
            maxNumberOfCups = Math.Min(((inventory.iceCubes.Count / recipe.amountOfIceCubes) - remainderOfIceCubes), maxNumberOfCups);

            // sugar cubes
            int remainderOfSugarCubes = inventory.sugarCubes.Count % recipe.amountOfSugarCubes;
            maxNumberOfCups = Math.Min(((inventory.sugarCubes.Count / recipe.amountOfSugarCubes) - remainderOfSugarCubes), maxNumberOfCups);

            Console.WriteLine(maxNumberOfCups);
            return maxNumberOfCups;
        }
    }
}

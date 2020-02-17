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
            DisplayRecipe();
            PickItemToChange();
        }
        private void DisplayRecipe()
        {
            Console.WriteLine("You have:\n" +
                              "     {0} Lemons" + "\n" +
                              "     {1} Sugar cubes" + "\n" +
                              "     {2} Ice cubes" + "\n" + 
                              "     {3) Price per cup" + "\n",
                              recipe.amountOfLemons,
                              recipe.amountOfSugarCubes,
                              recipe.amountOfIceCubes,
                              recipe.pricePerCup);

        }
        private void PickItemToChange()
        {
            try
            {
                int itemToChange = -1;
                while (itemToChange < 0 || itemToChange > 3)
                {
                    Console.Write("What would you like to change? ");
                    itemToChange = Console.ReadKey().KeyChar - '0';
                    Console.WriteLine();
                        if (itemToChange < 0 || itemToChange > 4)
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
}
}

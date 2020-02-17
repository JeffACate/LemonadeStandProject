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
        //private void checkItemToEdit(Item item)
        //{
        //    try
        //    {
        //        int task = -1;
        //        while (task < 0 || task > 4)
        //        {
        //            Console.Write("What would you like to buy (Press 4 to leave store)? ");
        //            task = Console.ReadKey().KeyChar - '0';
        //            Console.WriteLine();
        //            if (task < 0 || task > 4)
        //            {
        //                throw new IndexOutOfRangeException("Invalid input.");
        //            }
        //            Console.WriteLine();
        //        }
        //        return task;
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message + "\nPlease try again. ");
        //        return ChoseItemToBuy();
        //    }
        }
    }
}

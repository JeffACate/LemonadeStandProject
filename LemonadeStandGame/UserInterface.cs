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
    }
}

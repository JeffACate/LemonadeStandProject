using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand_3DayStarter
{
    class Store
    {
        // member variables (HAS A)
        private double pricePerLemon;
        private double pricePerSugarCube;
        private double pricePerIceCube;
        private double pricePerCup;

        // constructor (SPAWNER)
        public Store()
        {
            pricePerLemon = .5;
            pricePerSugarCube = .1;
            pricePerIceCube = .01;
            pricePerCup = .25;
        }

        // member methods (CAN DO)
        public void SellLemons(Player player)
        {
            int lemonsToPurchase = UserInterface.GetNumberOfItems("lemons");
            double transactionAmount = CalculateTransactionAmount(lemonsToPurchase, pricePerLemon);
            if(player.wallet.Money >= transactionAmount)
            {
                PerformTransaction(player.wallet, transactionAmount);
                player.inventory.AddLemonsToInventory(lemonsToPurchase);
            }
            else
            {
                Console.WriteLine("You do not have enough money!");
            }
        }

        public void SellSugarCubes(Player player)
        {
            int sugarToPurchase = UserInterface.GetNumberOfItems("sugar cubes");
            double transactionAmount = CalculateTransactionAmount(sugarToPurchase, pricePerSugarCube);
            if(player.wallet.Money >= transactionAmount)
            {
                PerformTransaction(player.wallet, transactionAmount);
                player.inventory.AddSugarCubesToInventory(sugarToPurchase);
            }
            else
            {
                Console.WriteLine("You do not have enough money!");
            }
        }

        public void SellIceCubes(Player player)
        {
            int iceCubesToPurchase = UserInterface.GetNumberOfItems("ice cubes");
            double transactionAmount = CalculateTransactionAmount(iceCubesToPurchase, pricePerIceCube);
            if(player.wallet.Money >= transactionAmount)
            {
                PerformTransaction(player.wallet, transactionAmount);
                player.inventory.AddIceCubesToInventory(iceCubesToPurchase);
            }
            else
            {
                Console.WriteLine("You do not have enough money!");
            }
        }

        public void SellCups(Player player)
        {
            int cupsToPurchase = UserInterface.GetNumberOfItems("cups");
            double transactionAmount = CalculateTransactionAmount(cupsToPurchase, pricePerCup);
            if(player.wallet.Money >= transactionAmount)
            {
                PerformTransaction(player.wallet, transactionAmount);
                player.inventory.AddCupsToInventory(cupsToPurchase);
            }
            else
            {
                Console.WriteLine("You do not have enough money!");
            }
        }

        private double CalculateTransactionAmount(int itemCount, double itemPricePerUnit)
        {
            double transactionAmount = itemCount * itemPricePerUnit;
            return transactionAmount;
        }

        private void PerformTransaction(Wallet wallet, double transactionAmount)
        {
            wallet.PayMoneyForItems(transactionAmount);
        }

        private void DisplayStore()
        {
            Console.WriteLine("Store Prices: " + "\n" +
                              "  0) Lemons cost      : $ {0}" + "\n" +
                              "  1) Sugar cubes cost : $ {1}" + "\n" +
                              "  2) Ice cubes cost   : $ {2}" + "\n" +
                              "  3) Cups cost        : $ {3}",
                              pricePerLemon,
                              pricePerSugarCube,
                              pricePerIceCube,
                              pricePerCup);
        }
        public void PurchaseItems(Player player)
        {
            bool stillPurchasingItems = true;
            while (stillPurchasingItems == true)
            {
                DisplayStore();
                int itemToPurchase = ChooseItemToBuy();
                switch (itemToPurchase)
                {
                    case 0:
                        SellLemons(player);
                        break;
                    case 1:
                        SellSugarCubes(player);
                        break;
                    case 2:
                        SellIceCubes(player);
                        break;
                    case 3:
                        SellCups(player);
                        break;
                    case 4:
                        stillPurchasingItems = false;
                        break;
                }
            }
        }
        private int ChooseItemToBuy()
        {
            try
            {
                int task = -1;
                while (task < 0 || task > 4)
                {
                    Console.Write("What would you like to buy (Press 4 to leave store)? ");
                    task = Console.ReadKey().KeyChar - '0';
                    Console.WriteLine();
                    if ( task < 0 || task > 4)
                    {
                        throw new IndexOutOfRangeException ("Invalid input.");
                    }
                    Console.WriteLine();
                }
                return task;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\nPlease try again. ");
                return ChooseItemToBuy();
            }
        }
    }
}

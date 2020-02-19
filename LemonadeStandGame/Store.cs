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

        public double PricePerLemon
        {
            get => pricePerLemon;
        }
        public double PricePerSugarCube
        {
            get => pricePerSugarCube;
        }
        public double PricePerIceCube
        {
            get => pricePerIceCube;
        }
        public double PricePerCup
        {
            get => pricePerLemon;
        }
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
                UserInterface.RejectTransaction();
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
                UserInterface.RejectTransaction();
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
                UserInterface.RejectTransaction();
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
                UserInterface.RejectTransaction();
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

        
        public void PurchaseItems(Player player)
        {
            bool stillPurchasingItems = true;
            while (stillPurchasingItems == true)
            {
                UserInterface.DisplayStore(pricePerLemon, pricePerSugarCube, pricePerIceCube, pricePerCup);
                int itemToPurchase = UserInterface.ChooseItemToBuy();
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
        
    }
}

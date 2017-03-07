using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeKioskSystem
{
    /* Checkout class creates an itemized receipt out of the scanned items
     * and applies discounts that are applicable to the cart of items
     * It displays this reciept to the console output
     */

    public class Checkout
    {
        Dictionary<String, int> checkoutReciept = new Dictionary<string, int>();
        String[] groceriesToScan;


        public Checkout(String[] groceries)
        {
            Catalog.updateInventory();
            Catalog.updatePromotions();
            groceriesToScan = groceries;
        }

        // Converts the unsorted list into a dictionary to speed up
        // look up processes of items quantities
        public void computeItemizedReceipt()
        {
            foreach (String g in groceriesToScan)
            {
                if (checkoutReciept.ContainsKey(g))
                {
                    checkoutReciept[g]++;
                }
                else if (Catalog.CheckInInventory(g))
                {
                    checkoutReciept.Add(g, 1);
                }
            }

            displayCost();
        }

        private void displayCost()
        {
            String productName;
            int amount;
            double price;
            double total = 0;
            Promotion applicablePromotion;

            foreach (var g in checkoutReciept)
            {
                productName = g.Key;
                amount = g.Value;
                price = Catalog.getPrice(productName);
                applicablePromotion = Catalog.getPromotion(productName);
                

                for(int i = 0; i < amount; i++)
                {
                    Console.WriteLine(productName + " + $" + price);
                    total += price;
                }

                if (applicablePromotion != null && applicablePromotion.meetsRequirements(amount))
                {
                    total -= applicablePromotion.getDiscount(amount);
                }
            }

            Console.WriteLine("Your Total Price: $" + total);
        }
    }
}

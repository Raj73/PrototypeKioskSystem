using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeKioskSystem
{
    /* GroupPromotion applies a discount to the total cost of a cart
     * each time a specified amount of specified product is reached
     * Currently, this promotion can be applied multiple times.
     * "Buy 3 Apples for $2.00"
     */
    public class GroupPromotion : Promotion
    {
        private String productName;
        private int quantityNeeded;
        private double discountPerPromo;
        Boolean isValid;

        public GroupPromotion(String[] promotionArgs)
        {
            productName = promotionArgs[1];
            quantityNeeded = Convert.ToInt32(promotionArgs[3]);
            discountPerPromo = (Catalog.getPrice(productName) * quantityNeeded) - Convert.ToSingle(promotionArgs[2]);
            discountPerPromo = Math.Round(discountPerPromo, 2, MidpointRounding.AwayFromZero);

            isValid = (discountPerPromo > 0);
        }

        public double getDiscount(int amount)
        {
            double totalDiscountAmount = 0.0f;
            int numberOfDiscounts = amount / quantityNeeded;    // This turns into the number of times the quantity needed was reached
                                                                // (4/3) = 1, (7/3) = 2, etc.
            for (int i = 1; i <= numberOfDiscounts; i++)
            {
                Console.WriteLine("Group of " + quantityNeeded + " " + productName + ": - $" + discountPerPromo);
                totalDiscountAmount += discountPerPromo;
            }
            return totalDiscountAmount;
        }

        public Boolean meetsRequirements(int currentAmount)
        {
            if (currentAmount >= quantityNeeded && isValid)
                return true;
            else
                return false;
        }
    }
}

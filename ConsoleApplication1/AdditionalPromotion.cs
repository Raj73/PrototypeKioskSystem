using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeKioskSystem
{
    /* AdditionalPromotion applies a discount to the total cost of a cart
     * each time a specified amount of specified product is reached
     * and an additional instance of that product exists in the cart
     * Currently, this promotion can be applied multiple times.
     * "Buy one, get one 50% off"
     */
    public class AdditionalPromotion : Promotion
    {
        private String productName;
        private int quantityNeeded;
        private double discountPerPromo;
        Boolean isValid;

        public AdditionalPromotion(String[] promotionArgs)
        {
            productName = promotionArgs[1];
            discountPerPromo = Catalog.getPrice(productName) * (0.01f * Convert.ToSingle(promotionArgs[2]));
            discountPerPromo = Math.Round(discountPerPromo, 2, MidpointRounding.AwayFromZero);
            quantityNeeded = Convert.ToInt32(promotionArgs[3]);

            isValid = (discountPerPromo > 0);
        }

        public double getDiscount(int amount)
        {
            double totalDiscountAmount = 0.0f;

            for (int i = 1; i <= amount; i++)
            {
                if (i % quantityNeeded == 0 && i < amount)
                {
                    Console.WriteLine("Buy " + quantityNeeded + " " + productName + ", get one for less: - $" + discountPerPromo);
                    totalDiscountAmount += discountPerPromo;
                    amount--;
                }
            }
            return totalDiscountAmount;
        }

        public Boolean meetsRequirements(int currentAmount)
        {
            if (currentAmount > quantityNeeded && isValid)
                return true;
            else
                return false;
        }
    }
}

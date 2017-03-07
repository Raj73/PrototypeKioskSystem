using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeKioskSystem
{
    /* SalesPromotion applies a discount to the total cost of a cart 
     * for every instance of a specified product
     * "Apples on sale. New Price: $0.50"
     */
    public class SalePromotion : Promotion
    {
        String productName;
        private double discountPerItem;
        Boolean isValid = true;

        public SalePromotion(String[] promotionArgs)
        {
            productName = promotionArgs[1];
            discountPerItem = Catalog.getPrice(productName) - Convert.ToSingle(promotionArgs[2]);
            discountPerItem = Math.Round(discountPerItem, 2, MidpointRounding.AwayFromZero);

            isValid = (discountPerItem > 0);
        }

        public double getDiscount(int amount)
        {
            double totalDiscountAmount = 0.0f;

            for (int i = 1; i <= amount; i++)
            {
                Console.WriteLine("Sale on " + productName + ": - $" + discountPerItem);
                totalDiscountAmount += discountPerItem;
            }
            return totalDiscountAmount;
        }

        public Boolean meetsRequirements(int currentAmount)
        {
            if (currentAmount > 0 && isValid == true)
                return true;
            else
                return false;
        }
    }
}

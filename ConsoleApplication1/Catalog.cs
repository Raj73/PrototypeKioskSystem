using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeKioskSystem
{
    /* Catalog class to serve as a means of access to the "database"
     * This class utilizes two text files in the "data" folder to simulate
     * an Inventory and Promotional database.
     */
    public static class Catalog
    {
        const String defaultInventoryFile = "Data/inventory.txt";
        const String defaultPromotionFile = "Data/promotions.txt";
        private static Dictionary<String, double> inventory;
        private static Dictionary<String, Promotion> promotions;

        //default inventory update method
        static public void updateInventory()
        {
            updateInventory(defaultInventoryFile);
        }

        //unit test cases use this function directly to speed up the process
        static public void updateInventory(String filePath)
        {
            String[] currentInventoryItemsFile = System.IO.File.ReadAllLines(filePath).ToArray();
            Dictionary<String, double> newInventory = new Dictionary<String, double>();

            String[] splitItem;
            String productName;
            double productPrice;

            foreach (var item in currentInventoryItemsFile)
            {
                splitItem = item.Split(',');
                productName = splitItem[0];
                productPrice = Convert.ToSingle(splitItem[1]);

                if(!newInventory.ContainsKey(productName))
                    newInventory.Add(productName, productPrice);
            }

            inventory = newInventory;
        }

        //default promotion update method
        static public void updatePromotions()
        {
            updatePromotions(defaultPromotionFile);
        }

        //unit test cases use this function directly to speed up the process
        static public void updatePromotions(String filePath)
        {
            String[] currentPromotionalItemsFile = System.IO.File.ReadAllLines(filePath).ToArray();
            Dictionary<String, Promotion> newPromotionalItems = new Dictionary<String, Promotion>();
            PromotionFactory promoGenerator = new PromotionFactory();

            String[] splitPromotionalInfo;
            Promotion newPromotion;

            foreach (var promotion in currentPromotionalItemsFile)
            {
                splitPromotionalInfo = promotion.Split(',');
                String productName = splitPromotionalInfo[1];
                if (inventory.ContainsKey(productName) && !newPromotionalItems.ContainsKey(productName))
                {
                    newPromotion = promoGenerator.createPromotion(splitPromotionalInfo);
                    newPromotionalItems.Add(productName, newPromotion);
                }
                promotions = newPromotionalItems;
            }
        }

        // These following functions serve as simple database "look ups"

        static public Boolean CheckInInventory(String productName)
        {
            return inventory.ContainsKey(productName);
        }

        static public double getPrice(String productName)
        {
            if (inventory.ContainsKey(productName))
                return inventory[productName];
            throw new System.IndexOutOfRangeException("Item not in the inventory");
        }

        static public Promotion getPromotion(String productName)
        {
            if (promotions.ContainsKey(productName))
                return promotions[productName];
            return null;
        }
    }
}

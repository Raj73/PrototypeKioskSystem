using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrototypeKioskSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeKioskSystem.Tests
{
    [TestClass()]
    public class DatabaseTests
    {
        [TestMethod()]
        public void ChangeInventoryTest()
        {
            Catalog.updateInventory();
            double priceBefore = Catalog.getPrice("Apple");

            Catalog.updateInventory("Data/UpdatedDatabases/inventory2.txt");
            double priceAfter = Catalog.getPrice("Apple");

            Assert.IsTrue( (priceBefore.Equals(0.75f) && priceAfter.Equals(1.00f)) );
        }

        [TestMethod()]
        public void ChangePromotionTest()
        {
            Catalog.updatePromotions();
            String typeBefore = Catalog.getPromotion("Apple").GetType().Name;

            Catalog.updatePromotions("Data/UpdatedDatabases/promotions2.txt");
            String typeAfter = Catalog.getPromotion("Apple").GetType().Name;

            Assert.IsTrue((typeBefore.Equals("SalePromotion") && typeAfter.Equals("GroupPromotion")));
        }

        [TestMethod()]
        public void InvalidProductInPromotion()
        {
            Catalog.updateInventory();
            Catalog.updatePromotions("Data/InvalidProductInPromotion/promotionsInvalidProduct.txt");

            Promotion promoTest = Catalog.getPromotion("Cheeseburger");

            Assert.IsNull(promoTest);
        }

        [TestMethod()]
        public void DuplicatedProductInInventory()
        {
            Catalog.updateInventory("Data/DuplicatedDatabaseEntries/inventoryWithDuplicates.txt");
            double priceTest = Catalog.getPrice("Apple");

            Assert.AreEqual(priceTest, 0.75f);
        }

        [TestMethod()]
        public void DuplicatedProductInPromotions()
        {
            Catalog.updatePromotions("Data/DuplicatedDatabaseEntries/promotionsWithDuplicates.txt");
            String promoTypeTest = Catalog.getPromotion("Apple").GetType().Name;

            Assert.AreEqual(promoTypeTest, "SalePromotion");
        }
    }
}
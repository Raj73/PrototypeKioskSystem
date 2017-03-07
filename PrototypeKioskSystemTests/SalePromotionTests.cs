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
    public class PromotionTests
    {
        [TestMethod()]
        public void SalePromotionTest()
        {
            String[] promoArgs = {"Sale", "Apple", "0.30"};
            Catalog.updateInventory();
            PromotionFactory promoFactory = new PromotionFactory();
            Promotion promoTest = promoFactory.createPromotion(promoArgs);

            double discount1000 = promoTest.getDiscount(10000);

            Assert.AreEqual(discount1000, 4500, 0.001);
        }

        [TestMethod()]
        public void GroupPromotionTest()
        {
            String[] promoArgs = { "Group", "Apple", "2.00", "3" };
            Catalog.updateInventory();
            PromotionFactory promoFactory = new PromotionFactory();
            Promotion promoTest = promoFactory.createPromotion(promoArgs);

            double discount10000 = promoTest.getDiscount(10000);

            Assert.AreEqual(discount10000, 833.25);
        }

        [TestMethod()]
        public void GroupPromotionTest2()
        {
            String[] promoArgs = { "Group", "Apple", "2.27", "4" };
            Catalog.updateInventory();
            PromotionFactory promoFactory = new PromotionFactory();
            Promotion promoTest = promoFactory.createPromotion(promoArgs);

            double discount10000 = promoTest.getDiscount(10000);

            Assert.AreEqual(discount10000, 1825, 0.001);
        }

        [TestMethod()]
        public void AdditionalPromotionTest()
        {
            String[] promoArgs = { "Additional", "Apple", "50", "2" };
            Catalog.updateInventory();
            PromotionFactory promoFactory = new PromotionFactory();
            Promotion promoTest = promoFactory.createPromotion(promoArgs);

            double discount10000 = promoTest.getDiscount(10000);

            Assert.AreEqual(discount10000, 1233.21, 0.001);
        }

        [TestMethod()]
        public void AdditionalPromotionTest2()
        {
            String[] promoArgs = { "Additional", "Apple", "66", "3" };
            Catalog.updateInventory();
            PromotionFactory promoFactory = new PromotionFactory();
            Promotion promoTest = promoFactory.createPromotion(promoArgs);

            double discount10000 = promoTest.getDiscount(10000);

            Assert.AreEqual(discount10000, 1225, 0.001);
        }
    }
}
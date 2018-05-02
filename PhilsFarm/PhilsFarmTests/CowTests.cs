using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhilsFarm;

namespace PhilsFarmTests
{
    [TestClass]
    public class CowTests
    {
        [TestMethod]
        public void CanNameCow()
        {
            var cow = new Cow("Jeffery");

            Assert.IsNotNull(cow);
            Assert.AreEqual(cow.Name, "Jeffery");
        }

        [TestMethod]
        public void CanFeedCow()
        {
            var cow = new Cow("Jeffery");
            var roster = new FarmRoster();

            roster.FoodAmount[Product.Food.Hay] = 1000;
            cow.Feed(roster, cow.PoundsOfFoodPerMonth);

            Assert.AreEqual(cow.AgeMonths, 1);
            Assert.AreEqual(cow.Growth, 1);
            Assert.AreEqual(cow.MonthsWithFood, 1);
            Assert.AreEqual(cow.MonthsWithoutFood, 0);
            Assert.AreEqual(roster.FoodAmount[Product.Food.Hay], 1000 - cow.PoundsOfFoodPerMonth);
        }
    }
}

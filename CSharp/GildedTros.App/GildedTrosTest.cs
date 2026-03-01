using System.Collections.Generic;
using Xunit;

namespace GildedTros.App
{
    public class GildedTrosTests
    {
        private static Item CreateItem(string name, int sellIn, int quality)
            => new()
            { Name = name, SellIn = sellIn, Quality = quality };

        private static void UpdateOneDay(Item item)
        {
            var app = new GildedTros(new List<Item> { item });
            app.UpdateQuality();
        }

        // ================================
        // NORMAL ITEMS
        // ================================

        [Fact]
        public void NormalItem_DecreasesSellInBy1()
        {
            var item = CreateItem("Normal Item", 10, 20);
            UpdateOneDay(item);
            Assert.Equal(9, item.SellIn);
        }

        [Fact]
        public void NormalItem_DecreasesQualityBy1()
        {
            var item = CreateItem("Normal Item", 10, 20);
            UpdateOneDay(item);
            Assert.Equal(19, item.Quality);
        }

        [Fact]
        public void NormalItem_DegradesTwiceAsFastAfterExpiration()
        {
            var item = CreateItem("Normal Item", 0, 20);
            UpdateOneDay(item);
            Assert.Equal(18, item.Quality);
        }

        [Fact]
        public void NormalItem_QualityNeverNegative()
        {
            var item = CreateItem("Normal Item", 5, 0);
            UpdateOneDay(item);
            Assert.Equal(0, item.Quality);
        }

        // ================================
        // GOOD WINE
        // ================================

        [Fact]
        public void GoodWine_IncreasesQuality()
        {
            var item = CreateItem("Good Wine", 10, 20);
            UpdateOneDay(item);
            Assert.Equal(21, item.Quality);
        }

        [Fact]
        public void GoodWine_IncreasesTwiceAsFastAfterExpiration()
        {
            var item = CreateItem("Good Wine", 0, 20);
            UpdateOneDay(item);
            Assert.Equal(22, item.Quality);
        }

        [Fact]
        public void GoodWine_QualityNeverMoreThan50()
        {
            var item = CreateItem("Good Wine", 5, 50);
            UpdateOneDay(item);
            Assert.Equal(50, item.Quality);
        }

        // ================================
        // LEGENDARY ITEM
        // ================================

        [Fact]
        public void LegendaryItem_DoesNotDecreaseSellIn()
        {
            var item = CreateItem("B-DAWG Keychain", 10, 80);
            UpdateOneDay(item);
            Assert.Equal(10, item.SellIn);
        }

        [Fact]
        public void LegendaryItem_DoesNotChangeQuality()
        {
            var item = CreateItem("B-DAWG Keychain", 10, 80);
            UpdateOneDay(item);
            Assert.Equal(80, item.Quality);
        }

        // ================================
        // BACKSTAGE PASSES
        // ================================

        [Theory]
        [InlineData("Backstage passes for Re:factor")]
        [InlineData("Backstage passes for HAXX")]
        public void BackstagePass_IncreasesBy1_WhenMoreThan10Days(string name)
        {
            var item = CreateItem(name, 15, 20);
            UpdateOneDay(item);
            Assert.Equal(21, item.Quality);
        }

        [Theory]
        [InlineData("Backstage passes for Re:factor")]
        [InlineData("Backstage passes for HAXX")]
        public void BackstagePass_IncreasesBy2_When10DaysOrLess(string name)
        {
            var item = CreateItem(name, 10, 20);
            UpdateOneDay(item);
            Assert.Equal(22, item.Quality);
        }

        [Theory]
        [InlineData("Backstage passes for Re:factor")]
        [InlineData("Backstage passes for HAXX")]
        public void BackstagePass_IncreasesBy3_When5DaysOrLess(string name)
        {
            var item = CreateItem(name, 5, 20);
            UpdateOneDay(item);
            Assert.Equal(23, item.Quality);
        }

        [Theory]
        [InlineData("Backstage passes for Re:factor")]
        [InlineData("Backstage passes for HAXX")]
        public void BackstagePass_DropsToZeroAfterConcert(string name)
        {
            var item = CreateItem(name, 0, 20);
            UpdateOneDay(item);
            Assert.Equal(0, item.Quality);
        }

        [Theory]
        [InlineData("Backstage passes for Re:factor")]
        [InlineData("Backstage passes for HAXX")]
        public void BackstagePass_QualityNeverMoreThan50(string name)
        {
            var item = CreateItem(name, 5, 50);
            UpdateOneDay(item);
            Assert.Equal(50, item.Quality);
        }

        // ================================
        // GLOBAL RULES
        // ================================

        [Fact]
        public void Quality_NeverNegative()
        {
            var item = CreateItem("Normal Item", -1, 0);
            UpdateOneDay(item);
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void Quality_NeverExceeds50()
        {
            var item = CreateItem("Good Wine", -1, 50);
            UpdateOneDay(item);
            Assert.Equal(50, item.Quality);
        }
    }
}
using System;

namespace GildedTros.App.ItemUpdater
{
    public class BackstagePassUpdater : IItemUpdater
    {
        public void Update(Item item)
        {
            item.SellIn--;

            if (item.SellIn < 0)
            {
                item.Quality = 0;
                return;
            }

            if (item.SellIn < 5)
                IncreaseQuality(item, 3);
            else if (item.SellIn < 10)
                IncreaseQuality(item, 2);
            else
                IncreaseQuality(item, 1);
        }

        private void IncreaseQuality(Item item, int amount)
        {
            item.Quality = Math.Min(50, item.Quality + amount);
        }
    }
}

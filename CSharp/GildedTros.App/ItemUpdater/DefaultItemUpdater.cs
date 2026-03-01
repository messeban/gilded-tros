using System;

namespace GildedTros.App.ItemUpdater
{
    public class DefaultItemUpdater : IItemUpdater
    {
        public void Update(Item item)
        {
            item.SellIn--;

            DecreaseQuality(item, 1);

            if (item.SellIn < 0)
                DecreaseQuality(item, 1);
        }

        private void DecreaseQuality(Item item, int amount)
        {
            item.Quality = Math.Max(0, item.Quality - amount);
        }
    }
}

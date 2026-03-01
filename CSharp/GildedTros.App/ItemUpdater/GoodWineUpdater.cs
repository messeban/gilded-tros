using System;

namespace GildedTros.App.ItemUpdater
{
    public class GoodWineUpdater : IItemUpdater
    {
        public void Update(Item item)
        {
            item.SellIn--;

            IncreaseQuality(item, 1);

            if (item.SellIn < 0)
                IncreaseQuality(item, 1);
        }

        private void IncreaseQuality(Item item, int amount)
        {
            item.Quality = Math.Min(50, item.Quality + amount);
        }
    }
}

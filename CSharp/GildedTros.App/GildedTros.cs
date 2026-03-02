using GildedTros.App.ItemUpdater;
using System.Collections.Generic;

namespace GildedTros.App
{
    public class GildedTros
    {
        public IList<Item> Items { get; private set; }
        public GildedTros(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                var updater = ItemUpdaterFactory.Create(item);
                updater.Update(item);
            }
        }
    }
}

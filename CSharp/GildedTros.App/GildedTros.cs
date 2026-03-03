using GildedTros.App.ItemUpdater;
using System;
using System.Collections.Generic;

namespace GildedTros.App
{
    public class GildedTros
    {
        public IList<Item> Items { get; private set; }
        private GildedTros(IList<Item> items)
        {
            this.Items = items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                var updater = ItemUpdaterFactory.Create(item);
                updater.Update(item);
            }
        }

        public static GildedTros Create(IList<Item> items)
        {
            if (items is null)
                throw new ArgumentNullException(nameof(items));

            if (items.Count == 0)
                throw new ArgumentException("Items collection cannot be empty.", nameof(items));

            return new GildedTros(items);
        }
    }
}

using System;

namespace GildedTros.App.ItemUpdater
{
    public static class ItemUpdaterFactory
    {
        public static IItemUpdater Create(Item item)
        {
            if (item.Name == "Good Wine")
                return new GoodWineUpdater();

            if (item.Name == "B-DAWG Keychain")
                return new LegendaryItemUpdater();

            if (IsBackstagePass(item.Name))
                return new BackstagePassUpdater();

            return new DefaultItemUpdater();
        }

        private static bool IsBackstagePass(string name)
        {
            return name.StartsWith("Backstage passes", StringComparison.OrdinalIgnoreCase);
        }
    }
}

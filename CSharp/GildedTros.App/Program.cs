using System;

namespace GildedTros.App
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            var items = InventorySeed.Create();
            var app = new GildedTros(items);

            var simulation = new SimulationPrinter(app);
            simulation.Run(31);
        }
    }
}

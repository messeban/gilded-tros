using System;

namespace GildedTros.App
{
    public class SimulationPrinter
    {
        private readonly GildedTros _app;

        public SimulationPrinter(GildedTros app)
        {
            _app = app;
        }

        /// <summary>
        /// Run the simulation for the given number of days, printing the state of the inventory at the end of each day.
        /// </summary>
        /// <param name="numberOfDays"></param>
        public void Run(int numberOfDays)
        {
            for (var day = 0; day < numberOfDays ; day++)
            {
                PrintDay(day);
                _app.UpdateQuality();
            }
        }

        private void PrintDay(int day)
        {
            Console.WriteLine($"-------- day {day} --------");
            Console.WriteLine("name, sellIn, quality");

            foreach (var item in _app.Items)
            {
                Console.WriteLine($"{item.Name}, {item.SellIn}, {item.Quality}");
            }

            Console.WriteLine();
        }
    }
}

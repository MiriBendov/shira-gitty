﻿namespace AsyncBreakfast
{

    internal class pancake { }
    internal class Coffee { }
    internal class Egg { }
    internal class Juice { }
    internal class Toast { }
    class Program
    {
        static void Main(string[] args)
        {
                Coffee cup = PourCoffee();
                Console.WriteLine("coffee is ready");
                Egg eggs = FryEggs(2);
                Console.WriteLine("eggs are ready");
                pancake pancake = Frypancake(3);
                Console.WriteLine("pancake is ready");
                Toast toast = ToastBread(2);
                ApplyButter(toast);
                ApplyJam(toast);
                Console.WriteLine("toast is ready");
                Juice oj = PourOJ();
                Console.WriteLine("oj is ready");
                Console.WriteLine("Breakfast is ready!");
        }
        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }
        private static void ApplyJam(Toast toast) =>
        Console.WriteLine("Putting jam on the toast");
        private static void ApplyButter(Toast toast) =>
        Console.WriteLine("Putting butter on the toast");
        private static Toast ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Remove toast from toaster");
            return new Toast();
        }
        private static pancake Frypancake(int slices)
        {
            Console.WriteLine($"putting {slices} slices of pancake in the pan");
            Console.WriteLine("cooking first side of pancake...");
            Task.Delay(3000).Wait();
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of pancake");
            }
            Console.WriteLine("cooking the second side of pancake...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put pancake on plate");
            return new pancake();
        }
        private static Egg FryEggs(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            Task.Delay(3000).Wait();
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put eggs on plate");
            return new Egg();
        }
        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }
    }
}

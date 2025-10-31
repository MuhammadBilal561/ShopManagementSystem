using System;

namespace ShopManagementSystem
{
    internal static class ConsoleHelper
    {
        public static void WriteTitle(string text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(text);
            Console.WriteLine("-----------------------");
            Console.ResetColor();
        }

        public static void WriteSubmenu(string text)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(text);
            Console.WriteLine("--------------------");
            Console.ResetColor();
        }

        public static void WritePrompt(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(text);
            Console.ResetColor();
        }

        public static void WriteSuccess(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void WriteError(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void WriteInfo(string text)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void Wait()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Press Enter to continue...");
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}

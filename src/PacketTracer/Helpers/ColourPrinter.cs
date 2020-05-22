using System;

namespace PacketTracer.Helpers
{
    /// <summary>
    /// Class for outputting colored text to the console.
    /// </summary>
    class ColourPrinter
    {
        public static void Print(string text, ConsoleColor foregroundColor, 
            ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            // Change console color from parameters.
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;

            Console.WriteLine(text);

            // Reset the console color to the default settings.
            Console.ResetColor();
        }
    }
}

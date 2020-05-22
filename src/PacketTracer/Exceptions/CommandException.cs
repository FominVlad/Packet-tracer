using PacketTracer.Helpers;
using System;

namespace PacketTracer.Exceptions
{
    /// <summary>
    /// The error handling class of the command.
    /// </summary>
    class CommandException : Exception
    {
        public CommandException(string message) 
            : base(message)
        {
            // Write an error message on the screen.
            ColourPrinter.Print($"Error! {message}", 
                ConsoleColor.White, ConsoleColor.Red);
        }
    }
}

using PacketTracer.Exceptions;
using PacketTracer.Interfaces;
using System;

namespace PacketTracer.Packets
{
    /// <summary>
    /// Text output command.
    /// </summary>
    class TextCommand : ICommand
    {
        public string commandName { get; set; }
        public string commandChar { get; set; }

        /// <summary>
        /// Text for display on the console.
        /// </summary>
        private string text { get; set; }

        public TextCommand(string text)
        {
            this.commandName = "Text";
            this.commandChar = "T";

            if (string.IsNullOrEmpty(text))
                throw new CommandException("Command text can`t be null or empty.");

            this.text = text;
        }

        public void Action()
        {
            Console.WriteLine($"\nCommand text: {text}");
        }
    }
}

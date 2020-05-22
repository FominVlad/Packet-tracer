using PacketTracer.Exceptions;
using PacketTracer.Helpers;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace PacketTracer
{
    class Program
    {
        static void Main(string[] args)
        {
            ColourPrinter.Print("<==== Create Simplified Driver ====>", ConsoleColor.Green);
            ColourPrinter.Print("-- Enter the package in the format: P[COMMAND_CHARACTER][:][PARAMETERS][:]E", ConsoleColor.Green);

            // Buffer for entered characters in the console.
            StringBuilder stringBuilder = new StringBuilder();
            Packet packet;
            CommandValidator commandValidator = new CommandValidator(new Regex(@"^P[A-Za-z]+:.+:E$"));
            ConsoleEventHandler consoleEventHandler = new ConsoleEventHandler(commandValidator);

            while (true)
            {
                try
                {
                    ConsoleKeyInfo keyPress = Console.ReadKey(true);
                    char input = keyPress.KeyChar;

                    // We allow you to enter only characters from the table ASCII (32 - 127).
                    if ((int)input >= 32 && (int)input <= 127)
                    {
                        Console.Write(input);

                        stringBuilder.Append(input);
                    }
                    // When you press "Enter" - clear the buffer and throw the code "NACK".
                    if ((int)input == 13)
                    {
                        stringBuilder.Clear();
                        ColourPrinter.Print("\nNACK", ConsoleColor.Red);
                    }

                    // Check the validity of the entered package and process it.
                    if (commandValidator.IsValid(stringBuilder.ToString()))
                    {
                        packet = commandValidator.GetPacketFromStr(stringBuilder.ToString());

                        consoleEventHandler.HandlePacket(packet);

                        // We clear the buffer after processing the packet.
                        stringBuilder.Clear();
                    }
                }
                catch (CommandException cmdEx)
                {
                    // In the future - some kind of action.
                }
                catch (Exception ex)
                {
                    // In case of an error, we throw the code "NACK".
                    ColourPrinter.Print("\nNACK", ConsoleColor.Red);
                    // We clear the console buffer.
                    stringBuilder.Clear();
                    // Display error message.
                    ColourPrinter.Print(ex.Message, ConsoleColor.White, ConsoleColor.Red);
                }
            }
        }
    }
}

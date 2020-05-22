using PacketTracer.Packets;
using System;
using System.Collections.Generic;

namespace PacketTracer.Helpers
{
    /// <summary>
    /// Console event handling class.
    /// </summary>
    class ConsoleEventHandler
    {
        private CommandValidator commandValidator { get; set; }

        public ConsoleEventHandler(CommandValidator commandValidator)
        {
            if (commandValidator == null)
                throw new Exception("Command validator can`t be null.");

            this.commandValidator = commandValidator;
        }

        /// <summary>
        /// Valid packet processing.
        /// </summary>
        /// <param name="packet">Packet for validation.</param>
        public void HandlePacket(Packet packet)
        {
            if (packet == null)
                throw new Exception("packet can`t be null");

            // The choice of actions depending on the type of command.
            switch (packet.commandCharacter)
            {
                case "T":
                    {
                        TextCommand textCommand = new TextCommand(packet.parameters);
                        
                        ColourPrinter.Print("\nACK", ConsoleColor.Green);
                        textCommand.Action();
                        
                        break;
                    };
                case "S":
                    {
                        List<int> paramList = new List<int>();

                        // Convert the parameters to a list of integers.
                        foreach (string str in commandValidator.GetParamsList(packet.parameters))
                        {
                            if (int.TryParse(str.Trim(), out int result))
                            {
                                paramList.Add(result);
                            }
                            else
                                throw new Exception("Parameter can`t be parsed.");
                        }

                        // In this type of command, two required parameters are required - frequency and duration.
                        if (paramList.Count != 2)
                            throw new Exception("Parameter list have wrong number of items.");

                        // The zero parameter is frequency. The first is duration.
                        SoundCommand soundCommand = new SoundCommand(paramList[0], paramList[1]);

                        ColourPrinter.Print("\nACK", ConsoleColor.Green);
                        soundCommand.Action();
                        
                        break;
                    };
                default:
                    {
                        throw new Exception("Undefined packet command character.");
                    };
            }
        }
    }
}

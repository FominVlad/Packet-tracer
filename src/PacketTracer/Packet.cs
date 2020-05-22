using PacketTracer.Interfaces;
using System;

namespace PacketTracer
{
    /// <summary>
    /// Package model class.
    /// </summary>
    class Packet : IPacket
    {
        public string commandCharacter { get; set; }
        public string parameters { get; set; }

        public Packet(string commandCharacter, string parameters)
        {
            if (string.IsNullOrEmpty(commandCharacter.Trim()))
                throw new Exception("Command character can`t be null or empty.");

            if (string.IsNullOrEmpty(parameters.Trim()))
                throw new Exception("Parameters can`t be null or empty.");

            this.commandCharacter = commandCharacter;
            this.parameters = parameters;
        }
    }
}

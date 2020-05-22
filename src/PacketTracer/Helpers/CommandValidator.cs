using PacketTracer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PacketTracer.Helpers
{
    /// <summary>
    /// Class for command validation.
    /// </summary>
    class CommandValidator : ICommandValidator
    {
        public Regex regularExpression { get; private set; }

        public CommandValidator(Regex regularExpression)
        {
            if (regularExpression == null)
                throw new Exception("Regular expression can`t be null.");

            this.regularExpression = regularExpression;
        }

        public Packet GetPacketFromStr(string packet)
        {
            // Cut the first character "P".
            string commandCharacter = packet.Substring(1, packet.IndexOf(":") - 1);

            // Cut off the first and last parts of the package.
            string parameters = packet.Remove(packet.LastIndexOf(":"), 2)
                                      .Remove(0, packet.IndexOf(":") + 1);

            return new Packet(commandCharacter, parameters);
        }

        public List<string> GetParamsList(string parameters)
        {
            // Separate the parameters using the separator ",".
            return parameters.Split(",").ToList();
        }

        public bool IsValid(string packet)
        {
            // Check the validity of the package using a regular expression.
            if (!regularExpression.IsMatch(packet))
                return false;

            return true;
        }
    }
}

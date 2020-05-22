using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PacketTracer.Interfaces
{
    /// <summary>
    /// Command validator interface.
    /// </summary>
    interface ICommandValidator
    {
        /// <summary>
        /// Package validation regular expression.
        /// </summary>
        Regex regularExpression { get; }

        /// <summary>
        /// Package validation.
        /// </summary>
        /// <param name="packet">Package for validation.</param>
        /// <returns>Validation result.</returns>
        public bool IsValid(string packet);

        /// <summary>
        /// Getting the package model.
        /// </summary>
        /// <param name="packet">Package for getting model.</param>
        /// <returns>Package model.</returns>
        public Packet GetPacketFromStr(string packet);

        /// <summary>
        /// Getting parameters list.
        /// </summary>
        /// <param name="parameters">Parameters string.</param>
        /// <returns>Parameters list.</returns>
        public List<string> GetParamsList(string parameters);
    }
}

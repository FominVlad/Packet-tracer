namespace PacketTracer.Interfaces
{
    /// <summary>
    /// Packet interface.
    /// </summary>
    interface IPacket
    {
        /// <summary>
        /// Command character.
        /// </summary>
        public string commandCharacter { get; set; }

        /// <summary>
        /// Command parameters.
        /// </summary>
        public string parameters { get; set; }
    }
}

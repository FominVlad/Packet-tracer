namespace PacketTracer.Interfaces
{
    /// <summary>
    /// Command interface.
    /// </summary>
    interface ICommand
    {
        /// <summary>
        /// Full command name.
        /// </summary>
        public string commandName { get; set; }

        /// <summary>
        /// Command charecter.
        /// </summary>
        public string commandChar { get; set; }

        /// <summary>
        /// Action that the command performs.
        /// </summary>
        public void Action();
    }
}

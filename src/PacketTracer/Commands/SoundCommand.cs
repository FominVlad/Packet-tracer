using PacketTracer.Exceptions;
using PacketTracer.Interfaces;
using System;

namespace PacketTracer.Packets
{
    /// <summary>
    /// Sound playback command.
    /// </summary>
    class SoundCommand : ICommand
    {
        public string commandName { get; set; }
        public string commandChar { get; set; }

        /// <summary>
        /// Sound frequency.
        /// </summary>
        private int freq { get; set; }

        /// <summary>
        /// Sound duration.
        /// </summary>
        private int duration { get; set; }

        public SoundCommand(int freq, int duration)
        {
            if (freq < 0)
                throw new CommandException("Frequency can`t be < 0.");

            if (duration < 0)
                throw new CommandException("Duration can`t be < 0.");
            

            this.commandName = "Sound";
            this.commandChar = "S";

            this.freq = freq;
            this.duration = duration;
        }

        public void Action()
        {
            Console.Beep(freq, duration);
        }
    }
}

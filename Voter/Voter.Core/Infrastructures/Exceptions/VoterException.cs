using System;

namespace Voter.Core.Infrastructures.Exceptions
{
    /// <summary>
    /// Vyjimka systemu
    /// </summary>
    public class VoterException : Exception
    {
        public VoterException(string message)
            : base(message)
        { }

        public VoterException(string message, Exception ex)
            : base(message, ex)
        { }
    }
}

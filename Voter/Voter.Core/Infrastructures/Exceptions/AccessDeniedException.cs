using System;

namespace Voter.Core.Infrastructures.Exceptions
{
    /// <summary>
    /// Vyjimka systemu IS Precontrol - zamítnutí přístupu
    /// </summary>
    public class AccessDeniedException : Exception
    {
        public AccessDeniedException()
            : this("Nemáte oprávnění k akci")
        { }

        public AccessDeniedException(Exception ex)
            : base("Nemáte oprávnění k akci", ex)
        { }

        public AccessDeniedException(string message)
            : base(message)
        { }

        public AccessDeniedException(string message, Exception ex)
            : base(message, ex)
        { }
    }
}

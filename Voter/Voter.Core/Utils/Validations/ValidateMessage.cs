namespace Voter.Core.Utils.Validations
{
    /// <summary>
    /// Validační hláška
    /// </summary>
    public class ValidateMessage
    {
        /// <summary>
        /// Vlastnost, ke které se validace vztahuje (DisplayName apod.)
        /// </summary>
        public string Property { get; set; }

        /// <summary>
        /// Validační hláška pro uživatele
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Validační klíč pro překlad
        /// </summary>
        public string ResourceName { get; set; }

        /// <summary>
        /// Argumenty validace
        /// </summary>
        public string[] Args { get; set; }

        public override string ToString()
        {
            return DisplayName;
        }
    }
}

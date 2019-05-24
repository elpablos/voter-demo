using System;

namespace Voter.Web.Mvc.LoggedUsers
{
    /// <summary>
    /// Prihlaseny uzivatel - nacteni udaju z ClaimIdentity
    /// </summary>
    public interface ILoggedUser
    {
        /// <summary>
        /// Prihlasovaci token
        /// </summary>
        Guid ID_Login { get; set; }

        /// <summary>
        /// ID uzivatele
        /// </summary>
        int? ID_User { get; }

        /// <summary>
        /// Anonym
        /// </summary>
        bool IsAnonymous { get; }

        /// <summary>
        /// Uživatel
        /// </summary>
        string UserName { get; }

        /// <summary>
        /// Zda se ma prodlouzit platnost tokenu
        /// </summary>
        bool IsProlongTime { get; }

    }
}
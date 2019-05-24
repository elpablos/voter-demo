using System;
using System.Security.Claims;
using System.Threading;

namespace Voter.Web.Mvc.LoggedUsers
{
    /// <summary>
    /// Prihlaseny uzivatel - nacteni udaju z ClaimIdentity
    /// </summary>
    public class LoggedUser : ILoggedUser
    {
        public bool IsAnonymous { get; private set; }

        public int? ID_User { get; set; }

        public string UserName { get; private set; }

        public bool IsProlongTime { get; private set; }

        public Guid ID_Login { get; set; }

        public LoggedUser()
        {
            IsAnonymous = true;

            var identity = Thread.CurrentPrincipal.Identity;

            if (identity is ClaimsIdentity)
            {
                var claimIdentity = (ClaimsIdentity)identity;
                if (claimIdentity != null)
                {
                    IsAnonymous = false;
                }

                if (claimIdentity.HasClaim(x => x.Type == ClaimTypes.Sid))
                {
                    var sid = claimIdentity.FindFirst(ClaimTypes.Sid);
                    ID_User = !string.IsNullOrEmpty(sid.Value) ? int.Parse(sid.Value) : (int?)null;
                }

                if (claimIdentity.HasClaim(x => x.Type == ClaimTypes.PrimarySid))
                {
                    var primarySid = claimIdentity.FindFirst(ClaimTypes.PrimarySid);
                    ID_Login = !string.IsNullOrEmpty(primarySid.Value) ? Guid.Parse(primarySid.Value) : Guid.Empty;
                }

                if (claimIdentity.HasClaim(x => x.Type == ClaimTypes.Name))
                {
                    var name = claimIdentity.FindFirst(ClaimTypes.Name);
                    UserName = !string.IsNullOrEmpty(name.Value) ? name.Value : null;
                }

                if (claimIdentity.HasClaim(x => x.Type == ClaimTypes.Expiration))
                {
                    var expiration = claimIdentity.FindFirst(ClaimTypes.Expiration);
                    if (expiration.Value != null)
                    {
                        var expirationDate = DateTime.ParseExact(expiration.Value, "o", null);
                        if (expirationDate < DateTime.Now)
                        {
                            IsProlongTime = true;
                        }
                    }
                }
            }
        }
    }
}
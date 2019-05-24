using System.Collections.Generic;

namespace Voter.Web.Mvc.Activities
{
    /// <summary>
    /// Seznam funkci webovych sluzeb, ktere byly zavolane na strance
    /// </summary>
    public class Activity : List<string>
    {
        /// <summary>
        /// Stopky
        /// </summary>
        public System.Diagnostics.Stopwatch Stopwatch;

        public Activity()
        {
            Stopwatch = new System.Diagnostics.Stopwatch();
            Stopwatch.Start();
        }
    }
}
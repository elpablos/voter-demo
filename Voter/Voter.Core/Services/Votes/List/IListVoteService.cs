using System.Collections.Generic;

namespace Voter.Core.Services.Votes
{
    public partial interface IVoteService
    {
        /// <summary>
        /// Přehled všech položek - volby
        /// </summary>
        /// <param name="input">vstup</param>
        /// <returns>výstup</returns>
        ICollection<ListVoteOutputModel> List(ListVoteInputModel input);
    }
}
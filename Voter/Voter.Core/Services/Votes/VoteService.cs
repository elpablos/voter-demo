using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using Voter.Core.Models;

namespace Voter.Core.Services.Votes
{
    public partial class VoteService : IVoteService
    {
        private static readonly string COLL_KEY = "Vote_key";

        public VoteService()
        {

        }

        public ICollection<VoteModel> GetCollections()
        {
            var col = MemoryCache.Default.Get(COLL_KEY) as ICollection<VoteModel>;
            if (col == null)
            {
                col = MemoryCache.Default.Get(COLL_KEY) as ICollection<VoteModel> ?? new List<VoteModel>();
                MemoryCache.Default.Set(COLL_KEY, col, DateTimeOffset.Now.AddYears(1));
            }

            return col;
        }
    }
}

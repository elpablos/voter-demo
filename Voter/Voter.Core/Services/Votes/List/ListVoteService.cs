using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voter.Core.Services.Votes
{
    public partial class VoteService : IVoteService
    {
        /// <summary>
        /// Přehled všech položek - volby
        /// </summary>
        /// <param name="input">vstup</param>
        /// <returns>výstup</returns>
        public ICollection<ListVoteOutputModel> List(ListVoteInputModel input)
        {
            //var random = new Random(DateTime.Now.Millisecond);
            var result = new List<ListVoteOutputModel>();

            //result.Add(new ListVoteOutputModel
            //{
            //    Id = Guid.NewGuid(),
            //    DisplayName = "Yes",
            //    Count = random.Next(250),
            //});

            //result.Add(new ListVoteOutputModel
            //{
            //    Id = Guid.NewGuid(),
            //    DisplayName = "No",
            //    Count = random.Next(250),
            //});

            //result.Add(new ListVoteOutputModel
            //{
            //    Id = Guid.NewGuid(),
            //    DisplayName = "Don't know",
            //    Count = random.Next(250),
            //});

            var col = GetCollections();
            result.Add(new ListVoteOutputModel
            {
                Id = Guid.NewGuid(),
                DisplayName = "Yes",
                Count = col.Count(x => x.Result == true)
            });

            result.Add(new ListVoteOutputModel
            {
                Id = Guid.NewGuid(),
                DisplayName = "No",
                Count = col.Count(x => x.Result == false)
            });

            result.Add(new ListVoteOutputModel
            {
                Id = Guid.NewGuid(),
                DisplayName = "Don't know",
                Count = col.Count(x => x.Result == null)
            });


            return result;
        }
    }
}

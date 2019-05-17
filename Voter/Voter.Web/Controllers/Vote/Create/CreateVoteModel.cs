using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Voter.Web.Controllers.Vote.Create
{
    public class CreateVoteModel 
    {
        public Guid Uid { get; set; }

        public bool? Result { get; set; }
        
    }
}
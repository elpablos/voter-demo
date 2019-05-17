using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voter.Core.Models
{
    public class VoteModel
    {
        public Guid Uid { get; set; }

        public bool? Result { get; set; }
    }
}

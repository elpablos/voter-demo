﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Voter.Web.Controllers.Common;

namespace Voter.Web.Controllers.Vote.Votes
{
    public partial class VoteController : BaseController
    {
        public VoteController()
        {
        }

        public ActionResult Test()
        {
            return View();
        }
    }
}
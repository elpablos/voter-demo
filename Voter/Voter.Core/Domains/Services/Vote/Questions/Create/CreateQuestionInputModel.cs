using System;

namespace Voter.Core.Domains.Services.Vote.Questions
{
    /// <summary>
    /// 
    /// Vstupní model entity - Otázky
    /// </summary>
    public class CreateQuestionInputModel 
    {
        /// <summary>
        /// ID_Login
        /// </summary>
        public Guid ID_Login { get; set; }

        /// <summary>
        /// ID_Campaign
        /// </summary>
        public int? ID_Campaign { get; set; }

        /// <summary>
        /// Název
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Poznámka
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Jedinečné ID kampaně
        /// </summary>
        public int? ID { get; set; }

    }
}


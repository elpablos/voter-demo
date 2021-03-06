using System;

namespace Voter.Core.Domains.Services.Vote.Campaigns
{
    /// <summary>
    /// Přehled otázek kampaně
    /// Výstupní model entity - Kampaně
    /// </summary>
    public class ListQuestionCampaignOutputModel 
    {
        /// <summary>
        /// Jedinečné ID otázky
        /// </summary>
        public int? ID { get; set; }

        /// <summary>
        /// Campaign
        /// </summary>
        public string Campaign { get; set; }

        /// <summary>
        /// Kampaň
        /// </summary>
        public int? ID_Campaign { get; set; }

        /// <summary>
        /// Název
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Aktivní
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Poznámka
        /// </summary>
        public string Description { get; set; }


        /// <summary>
        /// Votes
        /// </summary>
        public int? Votes { get; set; }

        /// <summary>
        /// DontKnow
        /// </summary>
        public int? DontKnow { get; set; }

        /// <summary>
        /// No
        /// </summary>
        public int? No { get; set; }

        /// <summary>
        /// Yes
        /// </summary>
        public int? Yes { get; set; }

    }
}


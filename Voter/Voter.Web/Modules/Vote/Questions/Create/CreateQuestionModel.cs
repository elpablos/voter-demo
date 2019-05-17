using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Voter.Web.Modules.Vote.Questions.Create
{
    /// <summary>
    /// 
    /// Model builderu pro entitu - Otázky
    /// </summary>
    public class CreateQuestionModel 
    {
        /// <summary>
        /// ID_Campaign
        /// </summary>
        [DisplayName("ID_Campaign")]
        //[Display(Name = nameof(Resources.Dictionary.Vote_Questions_$column.Value.Name.SubString(3)), ResourceType = typeof(Resources.Dictionary))]
        public int? ID_Campaign { get; set; }

        /// <summary>
        /// Název
        /// </summary>
        [DisplayName("Název")]
        //[Display(Name = nameof(Resources.Dictionary.Vote_Questions_$column.Value.Name), ResourceType = typeof(Resources.Dictionary))]
        public string DisplayName { get; set; }

        /// <summary>
        /// Poznámka
        /// </summary>
        [DisplayName("Poznámka")]
        //[Display(Name = nameof(Resources.Dictionary.Vote_Questions_$column.Value.Name), ResourceType = typeof(Resources.Dictionary))]
        public string Description { get; set; }

        /// <summary>
        /// Jedinečné ID kampaně
        /// </summary>
        [DisplayName("Jedinečné ID kampaně")]
        //[Display(Name = nameof(Resources.Dictionary.Vote_Questions_$column.Value.Name), ResourceType = typeof(Resources.Dictionary))]
        public int? Id { get; set; }

        /// <summary>
        /// Konstruktor - 
        /// Model builderu pro entitu - Otázky
        /// </summary>
        public CreateQuestionModel()
        {
        }
    }
}


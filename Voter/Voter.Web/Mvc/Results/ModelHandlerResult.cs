using System;
using System.Collections.Generic;
using Voter.Core.Utils.Validations;

namespace Voter.Web.Mvc.Results
{
    /// <summary>
    /// Obalující model pro všechna data vracející se z handleru
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class ModelHandlerResult
    {
        /// <summary>
        /// Data
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// Zda se povedlo
        /// </summary>
        public bool IsSuccess { get { return Exception == null && (ValidationMessages == null || ValidationMessages.Count == 0); } }

        /// <summary>
        /// Výjimka
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// Zpráva
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Validace
        /// </summary>
        public ICollection<ValidateMessage> ValidationMessages { get; set; }

        public List<string> Actions { get; set; }

        /// <summary>
        /// Zda šlo o redirect a mam validace presunout do TempData
        /// </summary>
        public bool IsRedirected { get; set; }

        public ModelHandlerResult()
        {
            Actions = new List<string>();
        }
    }
}
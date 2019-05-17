using System;
using System.Collections.Generic;
using Voter.Core.Utils.Validations;

namespace Voter.Core.Utils.Results
{
    /// <summary>
    /// Obalující model pro všechna data vracející se z vrstvy Core
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class ModelCoreResult<TModel>
    {
        /// <summary>
        /// Data
        /// </summary>
        public TModel Data { get; set; }

        /// <summary>
        /// Zda se povedlo
        /// </summary>
        public bool IsSuccess { get { return Exception == null && (ValidationMessages == null || ValidationMessages.Count == 0); } }

        /// <summary>
        /// Výjimka
        /// </summary>
        public Exception Exception { get; set; }

        /// <summary>
        /// Validace
        /// </summary>
        public ICollection<ValidateMessage> ValidationMessages { get; set; }
    }
}

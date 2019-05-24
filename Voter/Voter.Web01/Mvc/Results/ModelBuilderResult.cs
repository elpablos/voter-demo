using System.Collections.Generic;

namespace Voter.Web.Mvc.Results
{
    /// <summary>
    /// Obalující model pro všechna data vracející se z builderu
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class ModelBuilderResult<TModel> : IModelBuilderResponse
    {
        /// <summary>
        /// Data
        /// </summary>
        public TModel Data { get; set; }

        /// <summary>
        /// Seznam akcí
        /// </summary>
        public List<string> Actions { get; set; }

        /// <summary>
        /// Chybová hláška
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Zpráva
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Zda se povedlo
        /// </summary>
        public bool IsSuccess { get; set; }

        public ModelBuilderResult()
        {
            Actions = new List<string>();
        }
    }
}
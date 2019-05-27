namespace Voter.Web.Mvc.Results
{
    /// <summary>
    /// Rozšíření výsledku builderu pro snazší předání dat
    /// </summary>
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// Úspěšné předání dat
        /// </summary>
        /// <typeparam name="TBuilder"></typeparam>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="builder"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static ModelBuilderResult<TModel> Success<TBuilder, TModel>(this TBuilder builder, TModel model)
            where TBuilder : IModelBuilderResponse
        {
            return new ModelBuilderResult<TModel> { Data = model, IsSuccess = true };
        }

        /// <summary>
        /// Chybový stav
        /// </summary>
        /// <typeparam name="TBuilder"></typeparam>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="builder"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static ModelBuilderResult<TModel> Fail<TBuilder, TModel>(this TBuilder builder, string errorMessage)
        {
            return new ModelBuilderResult<TModel> { Data = default(TModel), ErrorMessage = errorMessage, IsSuccess = false };
        }
    }
}
namespace Voter.Web.Mvc.Results
{
    /// <summary>
    /// Rozhraní builderu s bez vstupního objektu
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    public interface IModelBuilder<TModel> : IModelBuilderResponse
    {
        ModelBuilderResult<TModel> Build();
    }

    /// <summary>
    /// Rozhraní builderu s jedním vstupním objektem 
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    public interface IModelBuilder<TModel, in TInput> : IModelBuilderResponse
    {
        ModelBuilderResult<TModel> Build(TInput input);
    }

    /// <summary>
    /// Rozhraní builderu - obecné
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    public interface IModelBuilderResponse
    {
    }
}
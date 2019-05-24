namespace Voter.Web.Mvc.Results
{
    /// <summary>
    /// Rozhraní handleru s jedním vstupním objektem
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    public interface IModelHandler<in TInput> : IModelHandlerResponse
    {
        ModelHandlerResult Handle(TInput model);
    }

    //public interface IModelHandler<in TInput, in THandler> : IModelHandlerResponse
    //{
    //    ModelHandlerResult Handle(TInput model);
    //}

    /// <summary>
    /// Rozhraní handleru s bez vstupního objektu
    /// </summary>
    public interface IModelHandler : IModelHandlerResponse
    {
        ModelHandlerResult Handle();
    }

    /// <summary>
    /// Rozhraní handleru - obecné
    /// </summary>
    public interface IModelHandlerResponse
    {
    }
}
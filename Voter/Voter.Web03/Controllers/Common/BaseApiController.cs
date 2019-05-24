using Voter.Web.Mvc.Results;
using System.Web.Http;

namespace Voter.Web.Controllers.Common
{
    /// <summary>
    /// Výchozí Api controller
    /// </summary>
    public class BaseApiController : ApiController
    {
        /// <summary>
        /// Předávání výsledků builderu přímo do resultu
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual IHttpActionResult AsResult<TModel>(ModelBuilderResult<TModel> result)
        {
            // rovnou odeslat cely result, aby pomoci JS slo zjistit, zda se vse povedlo, pripadne err!
            return Ok(result);
        }

        /// <summary>
        /// Předávání výsledků handleru přímo do resultu
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="result"></param>
        /// <returns></returns>
        protected virtual IHttpActionResult AsResult(ModelHandlerResult result)
        {
            if (result.Exception != null)
            {
                return NotFound();
            }

            // rovnou odeslat cely result, aby pomoci JS slo zjistit, zda se vse povedlo, pripadne err!
            return Ok(result);
        }
    }
}
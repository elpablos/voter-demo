using Dapper;
using Voter.Core.Domains.Services.Common;
using Voter.Core.Utils.Results;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Voter.Core.Domains.Services.Vote.Questions
{
    /// <summary>
    /// Implementace služby pro entitu - Otázky
    /// </summary>
    public partial class QuestionService : BaseService, IQuestionService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input">vstupní objekt</param>
        /// <returns>výstupní objekt</returns>
        public ModelCoreResult<DetailQuestionOutputModel> Detail(DetailQuestionInputModel input)
        {
            // zalozim result
            var result = new ModelCoreResult<DetailQuestionOutputModel>();

            using (var conn = GetConnection())
            {
                try
                {
                    // volani stored proc
                    string proc = "VT_Question_DETAIL";
                    var param = new DynamicParameters(input);
                    LogQuery(proc, input);
                    result.Data = conn.Query<DetailQuestionOutputModel>(proc, param: param, commandType: System.Data.CommandType.StoredProcedure).FirstOrDefault();
                }
                // kontrola validaci
                catch (SqlException e)
                {
                    TryValidation(e, result);
                }
            }
            
            return result;
        }

    }
}


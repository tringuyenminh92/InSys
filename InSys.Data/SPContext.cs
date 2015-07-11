using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using InSys.Data;

namespace InSys.Data
{
    public partial class InSysEntities:ISpContext
    {
        public IEnumerable<SP_GetAnswerByQuestionId_Result> GetAnswerByQuestionId(string questionId)
        {
          return  Database.SqlQuery<SP_GetAnswerByQuestionId_Result>("SP_GetAnswerByQuestionId @questionId",
                new SqlParameter("@questionId", questionId));
        }
    }
}

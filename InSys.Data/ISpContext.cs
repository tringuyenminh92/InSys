using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InSys.Data
{
    public interface ISpContext
    {
        IEnumerable<SP_GetAnswerByQuestionId_Result> GetAnswerByQuestionId(string questionId);
    }
}

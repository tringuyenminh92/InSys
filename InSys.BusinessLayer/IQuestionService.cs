using System.Collections.Generic;
using InSys.ViewModel;

namespace InSys.BusinessLayer
{
    public interface IQuestionService
    {
        IEnumerable<QuestionViewModel> GetQuestions();
    }
}

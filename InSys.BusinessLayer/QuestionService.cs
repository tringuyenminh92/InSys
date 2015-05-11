using InSys.Repository.Pattern.Repositories;
using InSys.Data;
using InSys.Repository.Pattern.UnitOfWork;

namespace InSys.BusinessLayer
{
    public class QuestionService:IQuestionService
    {
        private readonly IRepository<T_Question> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public QuestionService(IRepository<T_Question> repository,IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void LoadDuLieuQuestions()
        {
            _repository.Delete(null);
        }

    }
}

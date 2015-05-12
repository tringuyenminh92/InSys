//***********************************************************************
//
//	Created By: Nguyen Minh Tri
//	Created Date: 11-05-2015
//	Description: Add comment header,
//
//	Modified By: Nguyen Minh Tri
//	Modified Date: 12-05-2015
//	Description: 
//
//***********************************************************************

using System.Collections.Generic;
using System.Linq;
using InSys.Repository.Pattern.Repositories;
using InSys.Data;
using InSys.Repository.Pattern.UnitOfWork;
using InSys.ViewModel;
using log4net;
using AutoMapper;

namespace InSys.BusinessLayer
{
    public class QuestionService : IQuestionService
    {
        private static readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly bool isErrorEnabled = _logger.IsErrorEnabled;

        private readonly IRepositoryAsync<T_Question> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public QuestionService(IRepositoryAsync<T_Question> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<QuestionViewModel> GetQuestions()
        {
            Mapper.CreateMap<T_Question, QuestionViewModel>();
            return  Mapper.Map<IEnumerable<T_Question>,IEnumerable<QuestionViewModel>>(_repository.Query().Select());
        }
    }
}

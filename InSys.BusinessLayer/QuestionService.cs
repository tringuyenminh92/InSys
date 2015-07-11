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
using System.Data.SqlClient;

namespace InSys.BusinessLayer
{
    public class QuestionService : IQuestionService
    {
        private static readonly ILog _logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly bool isErrorEnabled = _logger.IsErrorEnabled;

        private readonly IUnitOfWork _unitOfWork;
        private readonly ISpContext _spContext;

        public QuestionService( IUnitOfWork unitOfWork,ISpContext spContext)
        {
            _unitOfWork = unitOfWork;
            _spContext = spContext;
        }
        public IEnumerable<QuestionViewModel> GetQuestions(string questionId)
        {
            //return  Mapper.Map<IEnumerable<T_Question>,IEnumerable<QuestionViewModel>>(_repository.Query().Select());
           var rs= _spContext.GetAnswerByQuestionId(questionId).ToList();
            return null;
        }
    }
}

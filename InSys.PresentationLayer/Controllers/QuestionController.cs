/*************************************************************
 *
 *	Created By: Nguyen Minh Tri - UR81HC
 *  Created Date: 08-04-2015
 *	Description: Controller to handle any requests related to Questionaries.
 *	
 *	Modified By: Nguyen Minh Tri - UR81HC
 *	Modified Date: 08-04-2015
 *	Description:
 *	
 *  Modified By: Nguyen Minh Tri - UR81HC
 *	Modified Date: 08-04-2015
 *	Description: comment method
 *
 *************************************************************/

using System.Reflection;
using System.Web.Mvc;
using System;
using InSys.BusinessLayer;
using log4net;

namespace InSys.PresentationLayer.Controllers
{
    public class QuestionController : BaseController
    {
        private readonly IQuestionService _questionService;
        private static readonly ILog logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly bool IsErrorEnabled = logger.IsErrorEnabled;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
            
        }

        //
        // GET: /Question/
        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// Gets the questions.
        /// </summary>
        /// <returns></returns>
        public JsonResult GetQuestions()
        {
            return Json(_questionService.GetQuestions("d5327b5e-cc90-49d2-80d9-05cc881594e9"), JsonRequestBehavior.AllowGet);
        }



        /// <summary>
        /// Gets the types.
        /// </summary>
        /// <returns></returns>
        public JsonResult GetTypes()
        {
            // var enums = (Enum.GetValues(typeof(TypeEnum)).Cast<TypeEnum>().Select(enu => new TypeModel { TypeId = enu.ToString(), Name = enu.ToString() })).ToList();
            return Json(null, JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// Gets the categories.
        /// </summary>
        /// <returns></returns>
        public JsonResult GetCategories()
        {
            try
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (IsErrorEnabled)
                {
                    logger.Error("Get all Category in Controller", ex);
                }
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }


        /// <summary>
        /// Gets the levels.
        /// </summary>
        /// <returns></returns>
        public JsonResult GetLevels()
        {
            try
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                if (IsErrorEnabled)
                {
                    logger.Error("get all level for question", ex);
                }
                return Json(null, JsonRequestBehavior.AllowGet);
            }

        }
    }
}

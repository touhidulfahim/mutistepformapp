using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using MultiStepForm.Data.Context;

namespace MultiStepForm.Web.Infrastructure
{
    public class WorkFlowFilter: FilterAttribute, IActionFilter
    {
        private int _highestCompletedStage;
        public int MinRequiredStage { get; set; }
        public int CurrentStage { get; set; }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            throw new NotImplementedException();
        }

        private RedirectToRouteResult GenerateRedirectUrl(string action, string controller)
        {
            return new RedirectToRouteResult(new RouteValueDictionary(new { action = action, controller = controller }));
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var _context = DependencyResolver.Current.GetService<MultiStepFormAppDbContext>();
            var sessionId = HttpContext.Current.Session["Tracker"];
            if (sessionId != null)
            {
                Guid tracker;
//                if (Guid.TryParse(sessionId.ToString(), out tracker))
//                {
//                    if (filterContext.HttpContext.Request.RequestType == "POST" && CurrentStage >= _highestCompletedStage)
//                    {
//                        var applicant = _context.StudentEntity.FirstOrDefault(x => x.ApplicantTracker == tracker);
//                        applicant.WorkFlowStage = CurrentStage;
//                        _context.SaveChanges();
//                    }
//                }
            }
        }
    }
}
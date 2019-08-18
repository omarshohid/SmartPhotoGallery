
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BDCO.Web.App_Code
{
    public class LogActionFilter : ActionFilterAttribute
    {
        //private readonly IRepository<MenuFavorite> repository = new Repository<MenuFavorite>();
        //protected readonly ContextStack context = new ContextStack();
        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    var Controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
        //    var Action = filterContext.ActionDescriptor.ActionName;
        //    var userName = HttpContext.Current.User.Identity.Name;
        //    string sqlSyntex = string.Format("EXEC InsertFavorite '{0}','{1}', '{2}'", Controller, Action, userName);
        //    repository.SetContext(context.Default);
        //    repository.ExeccuteRawQyery(sqlSyntex);
        //}

        /// <summary>
        /// Logs the request vars.
        /// </summary>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="values">The values.</param>
        private static void LogRequestVars(string methodName, ActionExecutingContext values)
        {
            // Get the request keys
            var keys = values.RequestContext.HttpContext.Request.Headers.AllKeys;

            // Get the request key value pairs
            var requestVars = keys.Select(key => new KeyValuePair<string, string>(key, values.RequestContext.HttpContext.Request.Headers.Get(key)));

            // Write to Debug log
            Debug.WriteLine("Method: {0}", methodName);

            foreach (var keyValuePair in requestVars)
            {
                Debug.WriteLine("{0} - {1}", keyValuePair.Key, keyValuePair.Value);
            }
        }
    }
}
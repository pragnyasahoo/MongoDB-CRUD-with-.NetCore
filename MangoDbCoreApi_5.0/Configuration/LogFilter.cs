using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace MangoDbCoreApi_5._0.Configuration
{
    public class LogFilter :  ActionFilterAttribute
    {
        private readonly ILogger<LogFilter> _logger;
        private string _actionType { get; set; }
        private string _actionName { get; set; }
        //private readonly ILoggerFactory _logger;

        public LogFilter(ILogger<LogFilter> logger, string actionType, string actionName)
        {
            this._logger = logger;
            this._actionName = actionName;
            this._actionType = actionType;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            context.ActionDescriptor.Properties[context.ActionDescriptor.DisplayName] = Stopwatch.StartNew();
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
            Stopwatch stopwatch = (Stopwatch)context.ActionDescriptor.Properties[context.ActionDescriptor.DisplayName];
            Trace.WriteLine(context.ActionDescriptor.DisplayName + "Elapse Time = " + stopwatch.Elapsed);
            _logger.LogInformation(context.ActionDescriptor.DisplayName + "Elapse Time = " + stopwatch.Elapsed);
        }
         

    }
}

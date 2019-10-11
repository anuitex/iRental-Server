using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iRental.Presentation.Settings
{
    public static class ExceptionHandlerSetting
    {
        public static void Setup(ILogger logger)
        {
            TaskScheduler.UnobservedTaskException += (sender, e) =>
            {
                e.SetObserved();
                e.Exception.Handle(ex =>
                {
                    logger.LogError(ex.Message, ex);
                    return true;
                });
            };
        }
    }
}

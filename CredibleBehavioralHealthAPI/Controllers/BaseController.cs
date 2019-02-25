using CredibleBehavioralHealth.Common;
using System.Web.Http;

namespace CredibleBehavioralHealth.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BaseController : System.Web.Http.ApiController
    {
        protected readonly ILogger _logger;

        /// <summary>
        /// BaseController constructor
        /// </summary>
        /// <param name="logger">Logger for instrumentation</param>
        public BaseController(ILogger logger)
        {
            _logger = logger;
        }

    }
}

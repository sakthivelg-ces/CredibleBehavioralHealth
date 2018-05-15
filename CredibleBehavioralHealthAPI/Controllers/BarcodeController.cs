using CredibleBehavioralHealth.Barcode.Common;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CredibleBehavioralHealth.Barcode.API.Controllers
{
    /// <summary>
    /// This service is used to generate or read bardcode.
    /// </summary>
    public class BarcodeController : BaseController
    {
        /// <inheritdoc/>
        public BarcodeController(ILogger logger): base(logger)
        {

        }
        /// <summary>
        /// This resource is used to generate barcode.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GenerateBarcode()
        {
            try
            {
                _logger.LogInfo("In GenerateBarcode method");

                return Ok("I am working");
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);

                var response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, 
                    "Unable to generate barcode, please contact system adminstrator.");

                return ResponseMessage(response);
            }
        }
    }
}

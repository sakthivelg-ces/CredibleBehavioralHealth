using CredibleBehavioralHealth.Barcode.Common;
using System;
using System.Collections.Generic;
using System.Linq;
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
        /// <summary>
        /// This resource is used to generate barcode.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GenerateBarcode()
        {
            try
            {
                ErrorLogger.LogInfo("In GenerateBarcode method");

                return Ok("I am working");
            }
            catch(Exception ex)
            {
                ErrorLogger.LogError(ex.Message);

                var response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, 
                    "Unable to generate barcode, please contact system adminstrator.");

                return ResponseMessage(response);
            }
        }
    }
}

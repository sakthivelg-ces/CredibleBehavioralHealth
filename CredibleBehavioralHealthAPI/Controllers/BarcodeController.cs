﻿using CredibleBehavioralHealth.Barcode.BL.Service;
using CredibleBehavioralHealth.Barcode.Common;
using CredibleBehavioralHealth.Barcode.Model.Model;
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
        private readonly IService _service;

        /// <inheritdoc/>
        public BarcodeController(ILogger logger, IService service): base(logger)
        {
            this._service = service;
        }
        /// <summary>
        /// This resource is used to generate barcode.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult GenerateBarcode(BarcodeDetailModel barcodeModel)
        {
            try
            {
                _logger.LogInfo("In GenerateBarcode method");

                var encryptCode = _service.GenerateEncryptedCode(barcodeModel);

                return Ok(encryptCode);
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

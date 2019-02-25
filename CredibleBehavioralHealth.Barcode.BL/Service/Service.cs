using CredibleBehavioralHealth.Common;
using CredibleBehavioralHealth.Model.Model;
using CredibleBehavioralHealth.Email;
using CredibleBehavioralHealth.QRCode;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CredibleBehavioralHealth.BL.Service
{
    public class Service : IService 
    {
        private readonly IEmailService _emailService;
        private readonly IQRCodeGenerator _qRCodeService;
        private readonly ILogger _logger;

        public Service(ILogger logger, IEmailService emailService, IQRCodeGenerator qRCodeService)
        {
            _logger = logger;
            _emailService = emailService;
            _qRCodeService = qRCodeService;
        }

        public string GenerateEncryptedCode(BarcodeDetailModel barcodeModel)
        {
            _logger.LogInfo("Serializing the object");
            string serializedObject = JsonConvert.SerializeObject(ConvertToBarcodeModel(barcodeModel));

            string serializedImage; 
            if(barcodeModel.ImageType == "39")
            {
                //TODO : Naresh
                serializedImage = string.Empty;
            }
            else
            {
                serializedImage = _qRCodeService.GenerateQRCode(serializedObject);
            }

            _logger.LogInfo("Intiating the the mail");
            SendEmail(barcodeModel, serializedImage);

            _logger.LogInfo("Returning the object");

            return serializedImage;
        }


        public void SendEmail(BarcodeDetailModel barcodeModel, string serializedImage)
        {
            if(string.IsNullOrEmpty(barcodeModel.Email))
            {
                _logger.LogInfo("No email address found");
                return;
            }

            List<string> toEmail = new List<string>();

            toEmail.Add(barcodeModel.Email);

            StringBuilder emailBody = new StringBuilder();

            emailBody.Append("Hi There, Scan your below code for more details");

            _emailService.SendWithImage(toEmail, "Credible Behavioral Health - Code generation", emailBody.ToString(), Convert.FromBase64String(serializedImage));

        }

        public BarcodeModel ConvertToBarcodeModel(BarcodeDetailModel detail)
        {
            return new BarcodeModel()
            {
                EntityType = detail.EntityType,
                EntityID = detail.EntityID,
                Domain = detail.Domain
            };
        }

        public BarcodeModel DecryptQRCode(string code)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Drawing.Imaging;
using System.IO;
using ZXing;
using ZXing.Common;
using ZXing.QrCode.Internal;

namespace CredibleBehavioralHealth.QRCode
{
    public class QRCodeGenerator : IQRCodeGenerator
    {
        public string GenerateQRCode(string data, int height = 250,
                                              int width = 250, int margin = 0, string alt = "QR Code")
        {

            var barcodeWritter = new BarcodeWriter();
            barcodeWritter.Format = BarcodeFormat.QR_CODE;

            var options = new EncodingOptions()
            {
                Height = height,
                Width = width,
                Margin = margin,
            };

            options.Hints.Add(EncodeHintType.ERROR_CORRECTION, ErrorCorrectionLevel.L);

            barcodeWritter.Options = options;

            using (var barcodeWritterOutput = barcodeWritter.Write(data))
            {
                using (var barcodeMemoryStream = new MemoryStream())
                {
                    barcodeWritterOutput.Save(barcodeMemoryStream, ImageFormat.Png);
                    return Convert.ToBase64String(barcodeMemoryStream.ToArray());
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredibleBehavioralHealth.QRCode
{
    public interface IQRCodeGenerator
    {
        string GenerateQRCode(string data, int height = 250, int width = 250, int margin = 0, string alt = "QR Code");
    }
}

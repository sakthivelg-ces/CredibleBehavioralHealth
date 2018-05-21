using CredibleBehavioralHealth.Barcode.Model.Model;

namespace CredibleBehavioralHealth.Barcode.BL.Service
{
    public interface IService
    {
        string GenerateEncryptedCode(BarcodeDetailModel barcodeModel);

        BarcodeModel DecryptQRCode(string code);
    }
}

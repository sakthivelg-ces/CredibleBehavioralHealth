using CredibleBehavioralHealth.Model.Model;

namespace CredibleBehavioralHealth.BL.Service
{
    public interface IService
    {
        string GenerateEncryptedCode(BarcodeDetailModel barcodeModel);

        BarcodeModel DecryptQRCode(string code);
    }
}

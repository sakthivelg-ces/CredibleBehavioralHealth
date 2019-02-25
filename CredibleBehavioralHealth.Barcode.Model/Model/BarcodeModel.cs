using Newtonsoft.Json;

namespace CredibleBehavioralHealth.Model.Model
{
    public class BarcodeModel
    {
        public string EntityType { get; set; }
        public int EntityID { get; set; }
        public string Domain { get; set; }
    }

    public class BarcodeDetailModel : BarcodeModel
    {
        public string Email { get; set; }

        public string SMS { get; set; }

        public string ImageType { get; set; }
    }

}

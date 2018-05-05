using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CredibleBehavioralHealth.Barcode.Model.Model
{
    public class BarecodeModel 
    {
        public string EntityType { get; set; }

        public int EntityID { get; set; }

        public string Domain { get; set; }

        public string Email { get; set; }

        public string SMS { get; set; }
    }
}

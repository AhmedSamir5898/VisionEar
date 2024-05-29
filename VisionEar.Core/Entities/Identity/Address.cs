using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionEar.Core.Entities.Identity
{
    public class Address
    {
        public int id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }

        public string Country { get; set; }
        public string ApplicationUserId { get; set; }
    }
}

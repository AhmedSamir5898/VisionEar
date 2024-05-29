using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionEar.Core.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string DisPlayName { get; set; }
        public Address Address { get; set; }
    }
}

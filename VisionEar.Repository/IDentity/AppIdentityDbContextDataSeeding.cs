using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using VisionEar.Core.Entities.Identity;

namespace VisionEar.Repository.IDentity
{
    public class AppIdentityDbContextDataSeeding
    {
        public static async Task UserAddAsync(UserManager<ApplicationUser> _userManager)
        {
            if (_userManager.Users.Count() == 0)
            {
                var user = new ApplicationUser()
                {
                    DisPlayName = "Ahmed Samir",
                    Email = "Ahmed.Samir@Yahoo.Com",
                    UserName = "Ahmed.Samir",
                    PhoneNumber = "01100165898"

                };
                await _userManager.CreateAsync(user, "Pa$$w0rd");
            }

 
        }
    }
}

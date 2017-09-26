//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using Microsoft.AspNet.Identity;
//using Microsoft.Owin.Security;
//using System.Security.Claims;
//using TalentConnect.Domain.Model;

//namespace TalentConnect.Infrastructure.Authentication
//{
//    public class IdentityFactory
//    {
//        public static ClaimsIdentity GetIdentity(string userName, Role role)
//        {
//            ClaimsIdentity identity = new ClaimsIdentity(
//                    new[] {
//                            new Claim(ClaimTypes.Name, userName),
//                            new Claim(ClaimTypes.NameIdentifier, userName)
//                        },
//                        DefaultAuthenticationTypes.ApplicationCookie,
//                        ClaimTypes.Name,
//                        ClaimTypes.Role);

//            identity.AddClaim(new Claim(ClaimTypes.Role, role.ToString()));

//            return identity;
//        }
//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Core.Securities.Entities;

namespace Taller.Core.Securities.Services
{
    public interface ISecurityService
    {
        string HasPassword(string userName, string hashedPassword);
        bool VerifyHashedPassword(string userName, string hasePassword, string providerPassword);

        SecurityEntity JwtSecutiry(string jwtSecrectKey);
    }
}

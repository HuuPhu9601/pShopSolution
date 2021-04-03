using pShopSolution.ViewModels.System.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pShopSolution.AdminApp.Services
{
    public interface IUserApiclient
    {
        Task<string> Authenticate(LoginRequest request);
    }
}

using ApplicationCore.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface ILoginRepository
    {
        Task<List<UserResponse>> ValidateLoginDetails(string username, string password);
        Task<List<UserAuthRole>> IsAuthenticated(string Username, string password);
        Task<List<ClientResponse>> ValidateclientResponses(string username, string password);
    }
}

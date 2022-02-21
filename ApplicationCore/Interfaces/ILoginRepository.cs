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
        Task<UserResponse> ValidateLoginDetails(string username);
        Task<UserAuthRole> IsAuthenticated(string Username, string password);
        Task<ClientResponse> ValidateclientResponses(string username);
        Task<int> UpdateAgentDetails(UpdateUserDetailsDTO userdetails);
    }
}

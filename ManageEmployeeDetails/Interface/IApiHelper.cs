using ManageEmployeeDetails.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ManageEmployeeDetails.Interface
{
   public interface IApiHelper
    {
        void SetUpHttpClient();
        Task<UserResponse> ClientGetRequest();
        HttpResponseMessage ClientPostRequest(User emp);
        HttpResponseMessage ClientDeleteRequest(int id);
        Task<SingleUserResponse> ClientSearchbyEmpId(int id);
    }
}

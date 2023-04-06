using ManageEmployeeDetails.Interface;
using ManageEmployeeDetails.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ManageEmployeeDetails.Common;
using System.Windows.Forms;

namespace ManageEmployeeDetails
{
    public  class ApiHelper : IApiHelper
    {
        static HttpClient client = new HttpClient();
        /// <summary>
        /// Setup httpclient 
        /// </summary>
        public  void SetUpHttpClient()
        {          
            client.BaseAddress = new Uri("https://gorest.co.in/public-api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(Constant.Token);
        }
        /// <summary>
        /// Getting employee details from api
        /// </summary>
        /// <returns></returns>
        public  async Task<UserResponse> ClientGetRequest()
        {
            var data = new UserResponse();
            try
            {
                DataTable dt = new DataTable();
                var response = await client.GetAsync("users");
                string res = await response.Content.ReadAsStringAsync();
                data= JsonConvert.DeserializeObject<UserResponse>(res.ToString());              
            }

            catch (Exception ex)
            {
                MessageBox.Show("Client Get Request Exception :" + ex.Message);
            }
            return data;
        }
        /// <summary>
        /// Adding new employee to api
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        public  HttpResponseMessage ClientPostRequest(User emp)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                response = client.PostAsJsonAsync("users", emp).Result;                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Client Post Exception :" + ex.Message);
            }
            return response;
        }
        /// <summary>
        /// Remove employee from api
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public  HttpResponseMessage ClientDeleteRequest(int id)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
               response = client.DeleteAsync("users/" + id).Result;                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Client Delete Exception :" + ex.Message);
            }
            return response;
        }
    }

}

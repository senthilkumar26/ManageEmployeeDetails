using ManageEmployeeDetails.Interface;
using ManageEmployeeDetails.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ManageEmployeeDetails.Test
{
    [TestClass]
    public class UnitTest1
    {
        public IApiHelper service;
        [TestInitialize]
        public void Init()
        {
            service = new ApiHelper();
            service.SetUpHttpClient();
        }
        [TestMethod]
        public void TestGetApi()
        {
            var res = service.ClientGetRequest();
            Assert.IsNotNull(res);
            Assert.IsTrue(res.Result.Data.Count>0);

        }
        [TestMethod]
        public void TestPostApi()
        {
            var obj = new User();
            obj.ID = 123;
            obj.Name = "Vicky";
            obj.Email = "Vicky@gmail.com";
            obj.Gender = "Male";
            obj.Status = "Active";
            var res = service.ClientPostRequest(obj);
            Assert.IsNotNull(res);
            Assert.IsTrue(res.StatusCode == System.Net.HttpStatusCode.OK);
        }
        [TestMethod]
        public void TestDeleteApi()
        {
            int id = 123;
            var res = service.ClientDeleteRequest(id);
            Assert.IsNotNull(res);
            Assert.IsTrue(res.StatusCode == System.Net.HttpStatusCode.OK);
        }
    }
}

using System;
using NUnit.Framework;
using System.Net.Http;
using UserManagement.Common;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using UserManagement.Console;
using Microsoft.Owin.Hosting;

namespace UserManagement.IntegrationTests
{
    [TestFixture]
    public class UserControllerTest
    {
        private IDisposable _server;
        private HttpClient client;

        [SetUp, Order(0)]
        public void SetUp()
        {
            _server = WebApp.Start<Startup>(Common.Constants.BaseAddress);
            client = new HttpClient();
            client.BaseAddress = new Uri(Common.Constants.BaseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
        }

        [Test, Order(1)]
        public async Task Return_Empty_UserDetailsSet()
        {
            //Data should be returned as NULL when there is no file
            System.IO.File.Delete(Constants.FullFilePath);
            var response = client.GetAsync("api/User").Result;
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<User>>(jsonString);
            Assert.AreEqual(0, result.Count);

        }

        [Test, Order(2)]
        public async Task Insert_User_Data_Valid()
        {
            var user = UserMockData.GetUserDataForInsert();
            var response = await client.PostAsJsonAsync("api/User", user);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test, Order(3)]
        public async Task Insert_Bulk_User_Data_Valid()
        {
            var users = UserMockData.GetUserListForInsert();
            HttpResponseMessage response = null;
            foreach (var user in users)
            {
                response = await client.PostAsJsonAsync("api/User", user);
            }
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test, Order(4)]
        public async Task Return_UserDetails_Valid()
        {
            var response = client.GetAsync("api/User").Result;
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<User>>(jsonString);
            Assert.AreNotEqual(0, result.Count);

        }

        [Test, Order(5)]
        public async Task Return_User_DataSet_Valid()
        {
            var response = client.GetAsync("api/User/2").Result;
            var jsonString = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<User>(jsonString);
            Assert.AreEqual(2, user.UserId);

        }

        [Test, Order(6)]
        public async Task Return_Empty_User_DataSet_Valid()
        {
            var response = client.GetAsync("api/User/0").Result;
            var jsonString = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<User>(jsonString);
            Assert.IsNull(user);

        }

        [Test, Order(7)]
        public async Task Return_Success_Update_User_Data()
        {
            var user = UserMockData.GetUserDataForUpdate_ValidCase();
            var response = await client.PutAsJsonAsync("api/User", user);
            Assert.IsTrue(response.IsSuccessStatusCode);

        }

        [Test, Order(8)]
        public async Task Return_Null_Update_User_Data()
        {
            var user = UserMockData.GetUserDataForUpdate_InValidCase();
            var response = await client.PutAsJsonAsync("api/User", user);
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Response>(jsonString);
            Assert.IsNull(result);
        }

        [Test, Order(9)]
        public async Task Return_Success_Delete_User_Data()
        {
            var response = await client.PostAsync("api/User/4", null);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [Test, Order(10)]
        public async Task Return_Null_Delete_User_Data()
        {
            var response = client.PostAsync("api/User/6", null).Result;
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Response>(jsonString);
            Assert.IsNull(result);
        }

        [TearDown]
        public void TearDown()
        {
            _server.Dispose();
        }
    }
}

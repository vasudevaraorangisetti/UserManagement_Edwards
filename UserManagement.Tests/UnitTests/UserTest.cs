using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Shared;

namespace UserManagement.Tests
{
    [TestFixture]
    public class UserTest
    {
        HttpClient client = null;

        [SetUp]
        public void SetUp()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(Shared.Constants.BaseAddress);
            client.DefaultRequestHeaders.Accept.Clear();
        }

        [Test]
        public async Task Retrun_Empty_UserDetailsSet()
        {
            //Data should be returned as NULL when there is no file
            var response = client.GetAsync("api/User").Result;
            var jsonString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<User>>(jsonString);
            Assert.AreEqual(0,result.Count);

        }

        [Test]
        public async Task Insert_User_Data_True()
        {
            var user = UserMockData.GetUserDataForInsert();
           
            var response = await client.PostAsJsonAsync("api/User", user);
            
        }
    }
}

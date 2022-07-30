using Microsoft.Owin.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Shared;

namespace UserManagement.Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Start OWIN host 
            using (WebApp.Start<Startup>(Shared.Constants.BaseAddress))
            {
                //UserManagement_Call().Wait();
                System.Console.WriteLine("Web API Server running");
                System.Console.ReadLine();
            }
        }

        //private static async Task UserManagement_Call()
        //{
        //    var user = new User
        //    {
        //        UserId = Constants.MaxUserId == 1 ? Constants.MaxUserId : Constants.MaxUserId + 1,
        //        FirstName = "Vasu",
        //        LastName = "R",
        //        EmailAddress = "vasu@test.com2",
        //        Gender = Shared.Gender.Male,
        //        UserNotes = "Test Insertion",
        //        CreatedOn = DateTime.Now.ToShortDateString()
        //    };

        //    // Create HttpClient and make a request to api/values 
        //    HttpClient client = new HttpClient();
        //    client.BaseAddress = new Uri(Shared.Constants.BaseAddress);
        //    client.DefaultRequestHeaders.Accept.Clear();

        //    //var response = await client.PostAsJsonAsync("api/User", user);
        //    var response = client.GetAsync(Constants.BaseAddress + "api/User").Result;
        //    var jsonString = await response.Content.ReadAsStringAsync();
        //    var userqqq = JsonConvert.DeserializeObject<List<User>>(jsonString);
        //    string ress = null;
        //}
    }
}

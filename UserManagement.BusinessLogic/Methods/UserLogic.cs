using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Linq;
using UserManagement.Shared;



namespace UserManagement.BusinessLogic
{
    public class UserLogic : IUserLogic
    {
        public IEnumerable<User> List()
        {
            return ReadUserData();
        }
        public User Get(int id)
        {
            var userList = ReadUserData();
            return userList.SingleOrDefault(u => u.UserId == id);
        }

        public Response Insert(User user)
        {

            var userList = ReadUserData();
            var userIndex = userList.FindIndex(u => u.UserId == user.UserId);
            if (userIndex >= 0)
            {
                userList[userIndex] = user;
            }
            else
            {
                userList.Add(user);
            }


            WriteUserData(userList);
            Constants.MaxUserId += 1;

            return new Response
            {
                Status = System.Net.HttpStatusCode.OK
            };
        }

        public Response Update(User user)
        {
            var userList = ReadUserData();
            var userIndex = userList.FindIndex(u => u.UserId == user.UserId);
            userList[userIndex] = user;

            WriteUserData(userList);
            return new Response
            {
                Status = System.Net.HttpStatusCode.OK
            };
        }

        public Response Delete(int id)
        {
            var userList = ReadUserData();
            var userIndex = userList.FindIndex(u => u.UserId == id);
            userList.RemoveAt(userIndex);

            WriteUserData(userList);

            return new Response
            {
                Status = System.Net.HttpStatusCode.OK
            };
        }

        private List<User> ReadUserData()
        {
            if (System.IO.File.Exists(Constants.FullFilePath))
            {
                using (StreamReader r = new StreamReader(Constants.FullFilePath))
                {
                    string jsonResult = r.ReadToEnd();
                    return JsonConvert.DeserializeObject<List<User>>(jsonResult);
                }
            }
            else
            {
                return new List<User>();
            }
        }

        private void WriteUserData(List<User> users)
        {
            var jsonList = JsonConvert.SerializeObject(users);

            if (!System.IO.Directory.Exists(Constants.DirectoryLocation))
            {
                Directory.CreateDirectory(Constants.DirectoryLocation);
            }

            using (System.IO.FileStream fs = System.IO.File.Create(Constants.FullFilePath))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(jsonList);
                fs.Write(bytes, 0, bytes.Length);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Web.Http;
using UserManagement.Common;
using UserManagement.BusinessLogic;

namespace UserManagement.Console
{
    public class UserController : BaseAPIController
    {
        private IUserLogic _userLogic;
        public UserController()
        {
            _userLogic = UserLogic;
        }
        [HttpGet]
        public IEnumerable<User> List()
        {
            return _userLogic.List();
        }

        [HttpGet]
        // GET api/values/5 
        public User Get(int id)
        {
            return _userLogic.Get(id);
        }

        // POST api/values
        [HttpPost]
        public Response Insert([FromBody]User user)
        {
            return _userLogic.Insert(user);
        }

        // PUT api/values/5 
        [HttpPut]
        public Response Update([FromBody]User user)
        {
            return _userLogic.Update(user);
        }

        // DELETE api/values/5 
        [HttpPost]
        public Response Delete(int id)
        {
            return _userLogic.Delete(id);
        } 
    }
}

using System.Web.Http;
using UserManagement.BusinessLogic;

namespace UserManagement.Console
{
    public class BaseAPIController : ApiController
    {
        public UserLogic UserLogic
        {
            get
            {
                return new UserLogic();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Common
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public Gender Gender { get; set; }
        public string UserNotes { get; set; }
        public string CreatedOn { get; set; }
        public string LastUpdatedOn { get; set; }
    }
}

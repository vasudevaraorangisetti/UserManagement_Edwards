using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Common;

namespace UserManagement.IntegrationTests
{
    public class UserMockData
    {
        internal static User GetUserDataForInsert()
        {
            return new User
            {
                UserId = (Constants.MaxUserId + 1),
                FirstName = "First Name_" + (Constants.MaxUserId + 1),
                LastName = "Last Name_" + (Constants.MaxUserId + 1),
                Gender = Gender.Male,
                EmailAddress = "useremail_" + (Constants.MaxUserId + 1) + "@test.com",
                UserNotes = "Test User Notes_" + (Constants.MaxUserId + 1),
                CreatedOn = DateTime.Now.ToShortDateString()
            };
        }

        internal static List<User> GetUserListForInsert()
        {
            return new List<User>(){
                new User{
                    UserId = (Constants.MaxUserId + 1),
                    FirstName = "First Name_" + (Constants.MaxUserId + 1),
                    LastName = "Last Name_" + (Constants.MaxUserId + 1),
                    Gender = Gender.Male,
                    EmailAddress = "useremail_" + (Constants.MaxUserId + 1) + "@test.com",
                    UserNotes = "Test User Notes_" + (Constants.MaxUserId + 1),
                    CreatedOn = DateTime.Now.ToShortDateString()
                },
                new User{
                    UserId = (Constants.MaxUserId + 2),
                    FirstName = "First Name_" + (Constants.MaxUserId + 2),
                    LastName = "Last Name_" + (Constants.MaxUserId + 2),
                    Gender = Gender.Unknown,
                    EmailAddress = "useremail_" + (Constants.MaxUserId + 2) + "@test.com",
                    UserNotes = "Test User Notes_" + (Constants.MaxUserId + 2),
                    CreatedOn = DateTime.Now.ToShortDateString()
                },
                new User{
                    UserId = (Constants.MaxUserId + 3),
                    FirstName = "First Name_" + (Constants.MaxUserId + 3),
                    LastName = "Last Name_" + (Constants.MaxUserId + 3),
                    Gender = Gender.Male,
                    EmailAddress = "useremail_" + (Constants.MaxUserId + 3) + "@test.com",
                    UserNotes = "Test User Notes_" + (Constants.MaxUserId + 3),
                    CreatedOn = DateTime.Now.ToShortDateString()
                },
                new User{
                    UserId = (Constants.MaxUserId + 4),
                    FirstName = "First Name_" + (Constants.MaxUserId + 4),
                    LastName = "Last Name_" + (Constants.MaxUserId + 4),
                    Gender = Gender.Female,
                    EmailAddress = "useremail_" + (Constants.MaxUserId + 4) + "@test.com",
                    UserNotes = "Test User Notes_" + (Constants.MaxUserId + 4),
                    CreatedOn = DateTime.Now.ToShortDateString()
                }

            };
        }

        internal static User GetUserDataForUpdate_ValidCase()
        {
            return new User
            {
                UserId = 1,
                FirstName = "Updated First Name_1",
                LastName = "Last Name_1",
                Gender = Gender.Female,
                EmailAddress = "useremail_1@test.com",
                UserNotes = "Test User Notes Updated_1",
                LastUpdatedOn = DateTime.Now.ToShortDateString()
            };
        }

        internal static User GetUserDataForUpdate_InValidCase()
        {
            return new User
            {
                UserId = 6,
                FirstName = "Updated First Name_6",
                LastName = "Last Name_6",
                Gender = Gender.Female,
                EmailAddress = "useremail_6@test.com",
                UserNotes = "Test User Notes Updated_6",
                LastUpdatedOn = DateTime.Now.ToShortDateString()
            };
        }

        
    }
}

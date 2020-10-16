using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aztuKonfrans2.Classes
{
    public class CustomRoleProvider : System.Web.Security.RoleProvider
    {
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            Models.aztuKonfransEntities konfEntities = new Models.aztuKonfransEntities();

            var us = usernames[0];
            var role = roleNames[0];

            var _user = konfEntities.User.FirstOrDefault(x => x.email == us);

            if (roleNames[0] == "Admin")
            {
                _user.role_id = 3;
            }
            else
            {
                _user.role_id = 1;
            }

            konfEntities.SaveChanges();

        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                Models.aztuKonfransEntities konfEntities = new Models.aztuKonfransEntities();
                Models.User _user = konfEntities.User.FirstOrDefault(x => x.email == email);
                return new string[] { _user.Role.role_name };
            }

            return new string[] { };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            Models.aztuKonfransEntities konfEntities = new Models.aztuKonfransEntities();
            var us = usernames[0];
            var role = roleNames[0];

            var _user = konfEntities.User.FirstOrDefault(x => x.email == us);


            if (roleNames[0] == "User")
            {
                _user.role_id = 3;
            }
            else
            {
                _user.role_id = 1;
            }

            konfEntities.SaveChanges();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
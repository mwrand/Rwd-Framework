using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Text;

namespace Rwd.Framework
{
    public class LdapAuthentication
    {
        #region Fields

        private string _path = "";
        private string _filterAttribute = "";

        #endregion

        /// <summary>
        /// Constructor for the LdapAuthentication class
        /// </summary>
        /// <param name="path"></param>
        public LdapAuthentication(string path)
        {
            _path = path;
        }

        /// <summary>
        /// Attempts to authenticate an LDAP domain user
        /// </summary>
        /// <param name="domain">Domain used to authenticate</param>
        /// <param name="username">User Name</param>
        /// <param name="pwd">Password</param>
        /// <returns>Returns true if the user is authenticated</returns>
        public User IsAuthenticated(string domain, string username, string pwd)
        {
            User user = null;
            string domainAndUsername = domain + @"\" + username;
            var entry = new DirectoryEntry(_path, domainAndUsername, pwd);
            var obj = entry.NativeObject;

            // Bind to the native AdsObject to force authentication
            var search = new DirectorySearcher(entry) { Filter = "(SAMAccountName=" + username + ")" };

            search.PropertiesToLoad.Add("cn");
            SearchResult result = search.FindOne();

            if (result == null)
            {
                return user;
            }

            // Update the new path to the user in the directory
            _path = result.Path;
            _filterAttribute = Convert.ToString(result.Properties["cn"][0]);

            user = new User();
            user.UserName = username;
            user.FullName = _filterAttribute;
            user.EmailAddress = GetEmailAddress();
            user.MachineName = Environment.MachineName;

            var groups = GetGroups();
            if (groups != null)
            {
                user.Groups = groups;
            }         

            return user;
        }

        /// <summary>
        /// Gets a pipe delimited list of groups the user is a member of
        /// </summary>
        /// <returns>
        /// Returns a pipe delimited string of groups
        /// </returns>
        public List<string> GetGroups()
        {
            var search = new DirectorySearcher(_path) { Filter = "(cn=" + _filterAttribute + ")" };
            search.PropertiesToLoad.Add("memberOf");
            var groupNames = new StringBuilder();

            SearchResult result = search.FindOne();
            var propertyCount = result.Properties["memberOf"].Count;

            List<string> groups = new List<string>();
            string group = "";

            for (int propertyCounter = 0; propertyCounter <= propertyCount - 1; propertyCounter++)
            {
                var dn = (string)result.Properties["memberOf"][propertyCounter];

                var equalsIndex = dn.IndexOf("=", 1, StringComparison.Ordinal);
                var commaIndex = dn.IndexOf(",", 1, StringComparison.Ordinal);
                if ((equalsIndex == -1))
                {
                    return null;
                }

                //groupNames.Append(dn.Substring((equalsIndex + 1), (commaIndex - equalsIndex) - 1));
                //groupNames.Append("|");
                group = dn.Substring((equalsIndex + 1), (commaIndex - equalsIndex) - 1);
                groups.Add(group);

            }

            //return groupNames.ToString();
            return groups;
        }

        public string GetEmailAddress()
        {
            var search = new DirectorySearcher(_path) { Filter = "(cn=" + _filterAttribute + ")" };
            search.PropertiesToLoad.Add("mail");  // e-mail addressead

            SearchResult result = search.FindOne();
            if (result != null)
            {
                return result.Properties["mail"][0].ToString();
            }
            else
            {
                return "Unknown";
            }
        }
    }
}

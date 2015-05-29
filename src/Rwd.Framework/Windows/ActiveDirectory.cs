/// <Description>
/// http://weblogs.asp.net/scottgu/archive/2006/07/12/Recipe_3A00_-Enabling-Windows-Authentication-within-an-Intranet-ASP.NET-Web-application.aspx
/// http://linqtoad.codeplex.com/
/// http://www.kouti.com/tables/userattributes.htm
/// </Description>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Threading;
using System.Web;
using bo = Rwd.Framework.BusinessObjects;
using System.IO;

namespace Rwd.Framework.Windows
{
    public class ActiveDirectory
    {

        public static string CNLDAP { get; set; }
        public static string LDAP { get; set; }
        public static string GroupLDAP { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static string GetChiefOfficerByUser(string username)
        {
            var dept = GetUserDetail(username, "Department");
            var director = GetDepartmentDirector(dept);
            return GetReportingManager(director);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public static string GetDepartmentChiefOfficer(string department)
        {
            var director = GetDepartmentDirector(department);
            if (director.Length > 0)
                return GetReportingManager(director);
            else
                return string.Empty;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public static string GetDepartmentDirector(string department)
        {
            var director = string.Empty;
            foreach (var member in ActiveDirectory.GetGroupMembers(department))
            {
                if (ActiveDirectory.IsDirector(member.Value))
                {
                    director = member.Value;
                    break;
                }
            }
            return director;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cn"></param>
        /// <returns></returns>
        public static DirectoryEntry GetDirectoryEntryByCN(string cn)
        {
            var path = string.Format(ActiveDirectory.CNLDAP, cn);
            return new DirectoryEntry(path);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static string GetDisplayName(string username)
        {
            var displayName = ActiveDirectory.GetUserDetail(username, "displayName").Trim();
            if (displayName.Length == 0) displayName = username;
            return displayName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static string GetFirstName(string username)
        {
            var displayName = ActiveDirectory.GetUserDetail(username, "givenName").Trim();
            if (displayName.Length == 0) displayName = username;
            return displayName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public static SortedDictionary<string, string> GetGroupMembers1(string groupName)
        {
            //if(!(groupName.ToLower() == "it") && !groupName.StartsWith("THDA_")) groupName = "THDA_" + groupName; 
            string groupAdPath = string.Format(ActiveDirectory.GroupLDAP, groupName);

            DirectoryEntry group = new DirectoryEntry(groupAdPath);
            object members = group.Invoke("Members", null);
            var sort = new SortedDictionary<string, string>();

            foreach (object member in ((IEnumerable)members))
            {
                DirectoryEntry x = new DirectoryEntry(member);
                sort.Add(x.Properties["displayName"].Value.ToString(), @"THDA\" + x.Properties["sAMAccountName"].Value.ToString());
                foreach (PropertyValueCollection prop in x.Properties)
                {
                    var key = prop.PropertyName;
                    var value = prop.Value;
                }

            }

            return sort;
        }

        public static SortedDictionary<string, string> GetGroupMembers(string groupName)
        {

            var newGroupName = string.Empty;
            if (!(groupName.ToLower() == "it" || groupName.ToLower() == "ia" || groupName.StartsWith("THDA_")))
                newGroupName = "THDA_" + groupName;
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain);

            // find the group in question (or load it from e.g. your list) 

            GroupPrincipal group = null;

            if (newGroupName.Length > 0)
                group = GroupPrincipal.FindByIdentity(ctx, newGroupName);

            if (group == null)
                group = GroupPrincipal.FindByIdentity(ctx, groupName);

            var sort = new SortedDictionary<string, string>();
            // if found.... 
            if (group != null)
            {
                // iterate over members 
                foreach (Principal p in group.GetMembers())
                {
                    sort.Add(p.DisplayName, @"THDA\" + p.SamAccountName);
                    // do whatever you need to do to those members 
                }
            }
            return sort;
        }


        //public static List<string> GetGroups(string username)
        //{
        //    var ROOT = new DirectoryEntry("LDAP://THDA.local/DC=thda,DC=local");
        //    var users = new DirectorySource<MyUser>(ROOT, SearchScope.Subtree);

        //    var groups = new DirectorySource<Group>(ROOT, SearchScope.Subtree);
        //    var list = new List<string>();

        //    var res1 = from usr in users
        //               where usr.AccountName.Contains("nlucas")
        //               select usr;


        //    foreach(var w in res1)
        //    {
        //        //Console.WriteLine("{0} has logged on {2} times and belongs to {1} groups:", w.Name, w.Groups.Length, w.LogonCount);
        //        foreach(string group in w.Groups)
        //            list.Add(group);
        //    }
        //    return list;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static List<string> GetGroups(string username)
        {
            List<string> result = new List<string>();
            // establish domain context    
            PrincipalContext yourDomain = new PrincipalContext(ContextType.Domain);
            // find your user    
            try
            {
                UserPrincipal user = UserPrincipal.FindByIdentity(yourDomain, username);
                // if found - grab its groups   
                if (user != null)
                {
                    PrincipalSearchResult<Principal> groups = GetGroups(user, 0);
                    // iterate over all groups    
                    foreach (Principal p in groups)
                    {
                        // make sure to add only group principals  
                        if (p is GroupPrincipal)
                        {
                            result.Add(((GroupPrincipal)p).Name.ToUpper());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ActiveDirectory.ErrorMessage = ex.ToString();
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userPrincipal"></param>
        /// <param name="tries"></param>
        /// <returns></returns>
        private static PrincipalSearchResult<Principal> GetGroups(UserPrincipal userPrincipal, int tries)
        {
            try
            {
                return userPrincipal.GetGroups();
            }
            catch
            {
                if (tries > 5)
                {
                    throw;
                }
                tries += 1;
                Thread.Sleep(1000);
                return GetGroups(userPrincipal, tries);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static string GetLastName(string username)
        {
            var displayName = ActiveDirectory.GetUserDetail(username, "sn").Trim();
            if (displayName.Length == 0) displayName = username;
            return displayName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static string GetReportingManager(string username)
        {
            var manager = GetUserDetail(username, "manager");
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
            var mgr = UserPrincipal.FindByIdentity(ctx, manager);
            string mgrUsername = string.Format(@"thda\{0}", mgr.EmailAddress.ToLower().Replace("@thda.org", string.Empty));
            return mgrUsername;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public static string GetUserDetail(string username, string attribute)
        {
            var field = string.Empty;
            var attribs = new string[] { attribute };
            var props = ActiveDirectory.GetUserDetails(username, attribs);
            if (props[attribute] != null) field = props[attribute].ToString();
            return field;
        }

        /// <summary>
        /// Attributes -- Active Directory attirbutes
        /// http://www.kouti.com/tables/userattributes.htm
        /// </summary>
        /// <param name="attributes">Details you want about given user</param>
        public static Hashtable GetUserDetails(string username, string[] attributes)
        {
            //use current login as search key
            string sfilter = string.Empty;
            var ht = new Hashtable();

            if (username.Length > 0)
            {
                if (username.Contains(@"\"))
                    sfilter = String.Format("(&(objectCategory=person)(sAMAccountName={0}))",
                                        username.Split(new char[] { '\\' })[1]);
                else
                    sfilter = String.Format("(&(objectCategory=person)(sAMAccountName={0}))",
                                        username.Split(new char[] { '/' })[1]);

                using (DirectoryEntry de = new DirectoryEntry(ActiveDirectory.LDAP))
                {
                    de.AuthenticationType = AuthenticationTypes.Secure;
                    //these are the attributes that will show            
                    var ds = new DirectorySearcher(de, sfilter, attributes);

                    using (SearchResultCollection src = ds.FindAll())
                    {
                        SearchResult sr = null;
                        if (src.Count > 0) sr = src[0];

                        if (sr != null)
                        {
                            foreach (var attr in attributes)
                            {
                                try
                                {
                                    ht.Add(attr, sr.Properties[attr][0].ToString());
                                }
                                catch
                                {
                                    ht.Add(attr, string.Empty);
                                }
                            }
                        }
                    }
                }
            }
            return ht;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Users> GetUsers()
        {
            var list = new List<Users>();

            // create a domain context for your default domain 
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain);
            // define a "query-by-example" to search for 
            Principal searchExample = new UserPrincipal(ctx);
            // define the principal searcher, based on that example principal 
            PrincipalSearcher ps = new PrincipalSearcher(searchExample);
            // loop over all principals found by the searcher
            foreach (Principal p in ps.FindAll())
            {
                var c = p.StructuralObjectClass;
                if (p.UserPrincipalName != null && p.DisplayName != null && p.DistinguishedName.Contains("OU=Users"))
                {
                    if (p.UserPrincipalName.Contains("@thda.local"))
                    {
                        var username = @"THDA\" + p.UserPrincipalName.Replace("@thda.local", string.Empty);
                        string[] StringOfADCrap;
                        StringOfADCrap = GetUserDetail(username, "manager").Split(',');
                        list.Add(new Users
                        {
                            DisplayName = p.DisplayName,
                            UserName = username,
                            FirstName = GetFirstName(username),
                            LastName = GetLastName(username),
                            Manager = StringOfADCrap[0].Replace("CN=", ""),
                            Department = GetUserDetail(username, "department"),
                            Title = GetUserDetail(username, "title")
                        });
                    }
                }
            }


            return list.OrderBy(p => p.FirstName).ThenBy(p => p.LastName).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static bool IsController(string username)
        {
            var title = GetUserDetail(username, "title");

            if (title.ToLower().StartsWith("controller"))
                return true;
            else
                return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public static bool IsDirector(string username)
        {
            var title = GetUserDetail(username, "title");

            if (title.ToLower().StartsWith("director of") ||
                title.ToLower().StartsWith("controller/director of") ||
                title.ToLower().StartsWith("senior director of"))
                return true;
            else
                return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public static bool IsGroupMember(string groupName, string username)
        {
            var isMember = false;
            var userGroups = ActiveDirectory.GetGroups(username);
            foreach (var group in userGroups)
            {
                if (group.ToUpper() == groupName.ToUpper())
                {
                    isMember = true;
                    break;
                }
            }
            return isMember;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        public static bool IsGroupMember(List<string> groupList, string username)
        {
            return (from ad in ActiveDirectory.GetGroups(username)
                    join groups in groupList on ad equals groups
                    select ad).Any();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DirectoryEntry GetDirectoryEntry()
        {

            DirectoryEntry de = new DirectoryEntry();
            de.Path = "LDAP://THDA.local/DC=thda,DC=local";
            de.AuthenticationType = AuthenticationTypes.Secure;
            return de;

        }

        /// <summary>
        /// 
        /// </summary>
        public static string ErrorMessage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static string GetQueryStartWith(string s)
        {
            return s + "*";
        }

        /// <summary>
        /// 
        /// </summary>
        public class Users
        {
            public string DisplayName { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string UserName { get; set; }
            public string Manager { get; set; }
            public string Department { get; set; }
            public string Title { get; set; }
        }
    }
}

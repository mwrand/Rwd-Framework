using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Security.Principal;
using Rwd.Framework.Windows;

namespace Rwd.Framework.BusinessObjects
{
    [Serializable]
    public class ActiveDirectoryUser : Interfaces.IActiveDirectoryUser
    {

        public string Department
        {
            get { return ActiveDirectory.GetUserDetail(this.Username, "Department"); }
        }
        public string DisplayName
        {
            get { return ActiveDirectory.GetDisplayName(this.Username); }
        }
        public bool IsCFO
        {
            get { return this.UserIsCFO(); }
        }
        public bool IsChiefOfficer
        {
            get { return this.UserIsChiefOfficer(); }
        }
        public bool IsController
        {
            get { return this.UserIsController(); }
        }
        public bool IsDirector
        {
            get { return this.UserIsDirector(); }
        }
        public bool IsExecutiveDirector
        {
            get { return this.UserIsExecutiveDirector(); }
        }
        public string ReportingManager
        {
            get { return ActiveDirectory.GetReportingManager(this.Username); }
        }
        public string Title
        {
            get { return ActiveDirectory.GetUserDetail(this.Username, "Title"); }
        }
        public string Username { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public ActiveDirectoryUser(string username)
        {
            this.Username = username;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        private bool UserIsCFO()
        {
            if (this.Title.Contains("Chief Financial Officer"))
                return true;
            else
                return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool IsEmployeesDirector(string employee)
        {
            var department = new ActiveDirectoryUser(employee).Department;
            if (department == this.Department && this.Title.Contains("Director of"))
                return true;
            else
            {
                var manager = ActiveDirectory.GetReportingManager(employee);
                if (this.Username == manager && ActiveDirectory.IsDirector(manager))
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool IsEmployeesChiefOfficer(string employee)
        {
            var department = new ActiveDirectoryUser(employee).Department;
            var departmentChief = ActiveDirectory.GetDepartmentChiefOfficer(department);

            if (this.Username.ToLower() == departmentChief.ToLower())
                return true;
            else
                return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool IsEmployeesManager(string employee)
        {
            var manager = ActiveDirectory.GetReportingManager(employee);
            if (this.Username.ToLower() == manager.ToLower())
                return true;
            else
                return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        private bool UserIsDirector()
        {
            return ActiveDirectory.IsDirector(this.Username);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool UserReportsToADirector()
        {
            return ActiveDirectory.IsDirector(ActiveDirectory.GetReportingManager(this.Username));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        private bool UserIsExecutiveDirector()
        {
            if (this.Title == "Executive Director")
                return true;
            else
                return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool UserIsChiefOfficer()
        {
            if (this.Title.Contains("Chief"))
                return true;
            else
                return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool UserIsController()
        {
            if (this.Title.StartsWith("Controller"))
                return true;
            else
                return false;
        }
    }
}

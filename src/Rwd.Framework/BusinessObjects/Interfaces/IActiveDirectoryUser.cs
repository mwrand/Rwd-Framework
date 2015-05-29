using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Security.Principal;

namespace Rwd.Framework.BusinessObjects.Interfaces
{

    public interface IActiveDirectoryUser
    {

        string Username { get; set; }
        bool IsCFO { get; }
        bool IsDirector { get; }
        bool IsExecutiveDirector { get; }
        string ReportingManager { get; }
        string Title { get; }

        bool IsEmployeesDirector(string employee);

    }
}

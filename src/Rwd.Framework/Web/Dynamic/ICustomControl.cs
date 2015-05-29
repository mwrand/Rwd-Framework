using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using datasource = Rwd.Framework.Web.Dynamic.Enumerations.DataSourceTypes; 


namespace Rwd.Framework.Web.Dynamic
{
    [Serializable()]
    public abstract class ICustomControl : System.Web.UI.UserControl
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="header"></param>
        /// <param name="value"></param>
        /// <param name="htmlTag"></param>
        public abstract void LoadControl(string header, string value, string htmlTag);

        public abstract datasource? DataSourceType { get; set; }
    }

}

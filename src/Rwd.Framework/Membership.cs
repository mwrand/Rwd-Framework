using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Rwd.Framework
{
    /// <summary>
    /// Barnhart Transportation Membership Class
    /// </summary>
    public class Membership
    {
        private string errormsg = "";
        private String dbConn = "";

        /// <summary>
        /// Creates a new instance of the Membership class
        /// </summary>
        /// <param name="dbConnection">Database connection string</param>
        public Membership(string dbConnection)
        {
            dbConn = dbConnection.Trim();
        }

        /// <summary>
        /// Contains Error Message text
        /// </summary>
        public string ErrorMessage
        {
            get { return errormsg; }
            set { errormsg = value; }
        }

        /// <summary>
        /// Checks to see if the 
        /// </summary>
        /// <param name="userName">User Name</param>
        /// <returns></returns>
        public bool IsLdap(string userName)
        {
            //if (String.IsNullOrEmpty(dbConn))
            //{
            //    throw new TransportationException("Connection String is Missing");
            //}
            //string sql = "SELECT COUNT(*) FROM Users WHERE UserName = '" + userName + "' AND UserIsLDAP = 1";
            //SqlConnection sConn = new SqlConnection(dbConn);
            //SqlCommand cmd = new SqlCommand(sql, sConn);
            //sConn.Open();
            //int result = Convert.ToInt32(cmd.ExecuteScalar());
            //sConn.Close();
            //return result == 0 ? false : true;
            return true;
        }

        /// <summary>
        /// Performs user login
        /// </summary>
        /// <param name="userName">User Name</param>
        /// <param name="password">User Password</param>
        /// <param name="ipAddress">IP Address</param>
        /// <param name="recordSuccessfulLogOn">True if successful logon attempts are recorded</param>
        /// <param name="recordFailedLogOn">True if failed logon attempts are recorded</param>
        /// <returns>Returns a user id if login was successful. Check ErrorMessage property if null is returned for information about the login failure.</returns>
        public int LogOn(string userName, string password, string ipAddress, bool recordSuccessfulLogOn, bool recordFailedLogOn)
        {
            //if (dbConn.Equals(""))
            //{
            //    Exception ex = new TransportationException("Connection String is Missing");
            //    throw ex;
            //}
            //password = Crypto.Encrypt(password);
            //User user = new User(dbConn);
            //SqlConnection sConn = new SqlConnection(dbConn);
            //SqlCommand cmd = new SqlCommand("LoginUser", sConn);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Username", userName);
            //cmd.Parameters.AddWithValue("@Password", password);
            //cmd.Parameters.AddWithValue("@IPAddress", ipAddress);
            //cmd.Parameters.AddWithValue("@RecordSuccessfulLogin", recordSuccessfulLogOn);
            //cmd.Parameters.AddWithValue("@RecordFailedLogin", recordFailedLogOn);
            //SqlParameter err = cmd.Parameters.Add("@ErrorMessage", SqlDbType.VarChar, 100);
            //err.Direction = ParameterDirection.Output;
            //SqlParameter uid = cmd.Parameters.Add("@UserId", SqlDbType.Int);
            //uid.Direction = ParameterDirection.Output;

            //sConn.Open();
            //cmd.ExecuteReader();
            //sConn.Close();

            //this.errormsg = err.Value.ToString();
            //return Convert.ToInt32(uid.Value);
            return -1;
        }

        /// <summary>
        /// Performs LDAP login
        /// </summary>
        /// <param name="userName">User Name</param>
        /// <param name="ipAddress">IP Address</param>
        /// <param name="recordSuccessfulLogOn">True if successful logon attempts are recorded</param>
        /// <param name="recordFailedLogOn">True if failed logon attempts are recorded</param>
        /// <returns>Returns a user id if login was successful. Check ErrorMessage property if null is returned for information about the login failure.</returns>
        public int LogOnLdap(string userName, string ipAddress, bool recordSuccessfulLogOn, bool recordFailedLogOn)
        {
            //User user = new User(dbConn);
            //SqlConnection sConn = new SqlConnection(dbConn);
            //SqlCommand cmd = new SqlCommand("LoginLdapUser", sConn);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@Username", userName);
            //cmd.Parameters.AddWithValue("@IPAddress", ipAddress);
            //cmd.Parameters.AddWithValue("@RecordSuccessfulLogin", recordSuccessfulLogOn);
            //cmd.Parameters.AddWithValue("@RecordFailedLogin", recordFailedLogOn);
            //SqlParameter err = cmd.Parameters.Add("@ErrorMessage", SqlDbType.VarChar, 100);
            //err.Direction = ParameterDirection.Output;
            //SqlParameter uid = cmd.Parameters.Add("@UserId", SqlDbType.Int);
            //uid.Direction = ParameterDirection.Output;

            //sConn.Open();
            //cmd.ExecuteReader();
            //sConn.Close();

            //this.errormsg = err.Value.ToString();
            //return Convert.ToInt32(uid.Value);
            return -1;
        }
    }
}

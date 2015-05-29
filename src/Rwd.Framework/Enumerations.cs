using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rwd.Framework
{
    public static class Enumerations
    {

        /// <summary>
        /// 
        /// </summary>
        public enum ChangeAction
        {
            Insert,
            Update,
            Delete
        }

        /// <summary>
        /// 
        /// </summary>
        public enum LogNotes
        {
            ViewedPage
        }

        /// <summary>
        /// 
        /// </summary>
        public enum MessageType
        {
            Information = 1,
            Warning = 2,
            Error = 3,
            Success = 4

        }

        public static class FellmanNominees
        {

            /// <summary>
            /// 
            /// </summary>
            public enum ReportTypes
            {
                Null = 0,
                Weekly = 1,
                Monthly = 2,
                Quarterly = 3,
                Yearly = 4
            }
        }
    }
}

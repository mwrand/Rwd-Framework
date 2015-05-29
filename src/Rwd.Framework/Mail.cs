using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Diagnostics;
using System.Web;
using System.IO;

namespace Rwd.Framework
{
    public class Mail
    {

        /// <summary>
        /// Sends the email.
        /// </summary>
        /// <param name="fromEmail">From email.</param>
        /// <param name="toEmail">To email.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="message">The message.</param>
        /// <param name="mailServer">The mail server.</param>
        /// <param name="mailUsername">The mail username.</param>
        /// <param name="mailPassword">The mail password.</param>
        /// <param name="inDev">if set to <c>true</c> [in dev].</param>
        /// <returns></returns>
        public static bool SendEmail(string fromEmail, string toEmail, string subject, string message, string mailServer, string mailUsername, string mailPassword, out Exception smtpEx, List<string> filesToAttach = null, bool inDev = false)
        {
            var list = new List<Attachment>();
            if (filesToAttach != null && filesToAttach.Count > 0)
            {
                foreach (var fileToAttach in filesToAttach)
                {
                    if (File.Exists(fileToAttach))
                        list.Add(new Attachment(fileToAttach));
                }
            }
            return SendEmail(fromEmail, toEmail, subject, message, mailServer, mailUsername, mailPassword, out smtpEx, list, inDev);
        }

        /// <summary>
        /// Sends the email.
        /// </summary>
        /// <param name="fromEmail">From email.</param>
        /// <param name="toEmail">To email.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="message">The message.</param>
        /// <param name="mailServer">The mail server.</param>
        /// <param name="mailUsername">The mail username.</param>
        /// <param name="mailPassword">The mail password.</param>
        /// <param name="inDev">if set to <c>true</c> [in dev].</param>
        /// <returns></returns>
        public static bool SendEmail(string fromEmail, string toEmail, string subject, string message, string mailServer, string mailUsername, string mailPassword, out Exception smtpEx, List<Attachment> filesToAttach = null, bool inDev = false)
        {
            try
            {
                var mailMsg = new MailMessage();
                mailMsg.From = new MailAddress(fromEmail);
                mailMsg.To.Add(toEmail);
                mailMsg.Subject = subject;
                mailMsg.IsBodyHtml = true;
                mailMsg.Body = message;

                if (filesToAttach != null && filesToAttach.Count > 0)
                {
                    foreach (var fileToAttach in filesToAttach)
                    {
                        mailMsg.Attachments.Add(fileToAttach);
                    }
                }

                SmtpClient smtp = null;
                if (string.IsNullOrEmpty(mailUsername) || string.IsNullOrEmpty(mailPassword))
                    smtp = new SmtpClient(mailServer);
                else
                    smtp = new SmtpClient { Host = mailServer, Credentials = new NetworkCredential(mailUsername, mailPassword) };

                smtp.Send(mailMsg);
                smtpEx = null;
                mailMsg.Attachments.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                var a = ex.Message;
                smtpEx = ex;
                return false;
            }
        }

    }
}

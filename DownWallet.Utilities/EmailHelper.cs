using FluentEmail.Core;
using FluentEmail.Razor;
using FluentEmail.Smtp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DownWallet.Utilities
{
    public static class EmailHelper
    {
        public static async Task SendSingleEmail(string firstName, string emailAddress, string action)
        {

            var sender = new SmtpSender(() => new SmtpClient("smtp.gmail.com")
            {
                UseDefaultCredentials = false,
                EnableSsl = true,
                Credentials = new NetworkCredential("downwallettest@gmail.com", "dwnwlttst1234"),
                Port = 587
            });

            StringBuilder template = new();
            template.AppendLine("<h1>Dear " + firstName + ", </h1>");
            template.AppendLine("<p>New" + action + " transaction happened with your account! </p>");
            template.AppendLine("The DownWallet Team.");


            Email.DefaultSender = sender;
            //Email.DefaultRenderer = new RazorRenderer();

            var email = await Email
               .From("downwallettest@gmail.com")
               .To(emailAddress)
               .Subject("New " + action + " Transaction")
               .UsingTemplate(template.ToString(), new { })
               .SendAsync();

        }

        public static async Task SendMultipleEmail(string srcName, string srcEmail, string srcAction, string dstName, string dstEmail, string dstAction)
        {
            var sender = new SmtpSender(() => new SmtpClient("smtp.gmail.com")
            {
                EnableSsl = true,
                Credentials = new NetworkCredential("downwallettest@gmail.com", "dwnwlttst1234"),
                Port = 587
            });

            Email.DefaultSender = sender;

            StringBuilder srcTemplate = new();
            srcTemplate.AppendLine("<h1>Dear " + srcName + ", </h1>");
            srcTemplate.AppendLine("<p>New " + srcAction + " transaction happened with your account! </p>");
            srcTemplate.AppendLine("The DownWallet Team.");

            StringBuilder dstTemplate = new();
            srcTemplate.AppendLine("<h1>Dear " + dstName + ", </h1>");
            srcTemplate.AppendLine("<p>New" + dstAction + " transaction happened with your account! </p>");
            srcTemplate.AppendLine("The DownWallet Team.");


            

            var email = await Email
               .From("downwallettest@gmail.com")
               .To(srcEmail)
               .Subject("New " + srcAction + " Transaction")
               .UsingTemplate(srcTemplate.ToString(), new { })
               .SendAsync();

            var mail = await Email
               .From("downwallettest@gmail.com")
               .To(dstEmail)
               .Subject("New " + dstAction + " Transaction")
               .UsingTemplate(dstTemplate.ToString(), new { })
               .SendAsync();
        }
    }
}

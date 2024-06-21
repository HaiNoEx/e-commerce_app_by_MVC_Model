using Microsoft.AspNetCore.Identity.UI.Services;
using Newtonsoft.Json.Linq;
using SendWithBrevo;
using sib_api_v3_sdk.Api;
using sib_api_v3_sdk.Model;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Diagnostics;


namespace BulkyWeb.Utility
{
    public class EmailSender : IEmailSender
    {
        


        

        System.Threading.Tasks.Task IEmailSender.SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return System.Threading.Tasks.Task.CompletedTask;
        }
        //public static void SendEmailAsync(string email, string subject, string htmlMessage)
        //{

        //    var apiInstance = new TransactionalEmailsApi();
        //    string SenderName = "this store";
        //    string SenderEmail = "thisStore@beststore.com";
        //    SendSmtpEmailSender sender = new SendSmtpEmailSender(SenderName, SenderEmail);

        //    SendSmtpEmailTo receiver = new SendSmtpEmailTo(email, subject);
        //    List<SendSmtpEmailTo> To = new List<SendSmtpEmailTo>();
        //    To.Add(receiver);

        //    string HtmlContent = null;
        //    string TextContent = htmlMessage;

        //    try
        //    {
        //        var sendSmtpEmail = new SendSmtpEmail(sender, To, null, null, HtmlContent, TextContent, subject);
        //        CreateSmtpEmail result = apiInstance.SendTransacEmail(sendSmtpEmail);

        //        Console.WriteLine("Brevo message: " + result.ToJson());

        //    }
        //    catch (Exception e)
        //    {

        //        Console.WriteLine("Exception"+ e.Message);

        //    }

        //}
    }
}

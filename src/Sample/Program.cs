using Newtonsoft.Json;
using System;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            var commandName = "EmailPlugin";
            var pm = new PluginManager.PluginManager(commandName);

            var emailRequestModel = new EmailRequest
            {
                FromAddress = "fromemail@gmail.com",
                ToAddress = "toemail@gmail.com",
                IsHtml = true,
                Body = "Body",
                Subject = "Subject",
                MailServer = "smtp.gmail.com",
                Username = "fromemail@gmail.com",
                Password = "password"
            };

            string json = JsonConvert.SerializeObject(emailRequestModel);
            var result = pm.plugin.Execute(json); // object
        }
    }
}

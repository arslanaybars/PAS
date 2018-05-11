namespace Plugin.Sample.EmailSender
{
    public class EmailSenderRequestModel
    {
        public string MailServer { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FromAddress { get; set; }

        public string ToAddress { get; set; }

        public string CCAddress { get; set; }

        public string BCCAddress { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public bool IsHtml { get; set; }
    }
}

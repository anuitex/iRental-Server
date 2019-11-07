namespace iRental.Core.Models
{
    public class Email
    {
        public string From { get; private set; }
        public string To { get; private set; }
        public string Subject { get; private set; }
        public string Body { get; private set; }

        public Email(string from,string to,string subject,string body)
        {
            From = from;
            To = to;
            Subject = subject;
            Body = body;
        }
    }
}

namespace BE.Service.ConfigurationOptions
{
    public class SmtpOptions
    {
        public const string Section = "Smtp";

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Server { get; set; }

        public int Port { get; set; }

        public bool EnableSSL { get; set; }
    }
}

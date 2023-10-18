namespace USP.TCC.ChatIA.MVC.Models
{
    public class Settings
    {
        public Logging Logging { get; set; }
        public string AllowedHosts { get; set; }
        public Azure Azure { get; set; }
    }

    public class Logging
    {
        public Loglevel LogLevel { get; set; }
    }

    public class Loglevel
    {
        public string Default { get; set; }
        public string MicrosoftAspNetCore { get; set; }
    }

    public class Azure
    {
        public string EndPoint { get; set; }
        public string Key { get; set; }
    }


}

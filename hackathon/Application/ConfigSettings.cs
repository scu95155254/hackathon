using System.Web.Configuration;

namespace hackathon.Application
{
    public class ConfigSettings
    {
        static ConfigSettings()
        {
        }

        public static readonly string ExApiTokenDomain = WebConfigurationManager.AppSettings["ExApiTokenDomain"];
        public static readonly string ApiKey = WebConfigurationManager.AppSettings["ApiKey"];
        public static readonly string ApiSecret = WebConfigurationManager.AppSettings["ApiSecrect"];
    }
}
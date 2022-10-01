using System.Text;

namespace ecommerce.Utils
{
    public static class DataBase
    {
        public static string BuildConnectionString(IConfiguration config)
        {
            var sb = new StringBuilder();

            sb.Append($"Server={config["database:Server"]};");
            sb.Append($"Database={config["database:DatabaseName"]};");
            sb.Append($"User ID={config["database:User"]};");
            sb.Append($"Password={config["database:Password"]};");

            if (!config.GetValue<bool>("database:TrustedConnection"))
            {
                sb.Append("Trusted_Connection=False;");
            }
            if (config.GetValue<bool>("database:MultipleActiveResultSets"))
            {
                sb.Append("MultipleActiveResultSets=true");
            }

            return sb.ToString();
        }
    }
}

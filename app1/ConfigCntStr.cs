using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app1
{
    class ConfigCntStr
    {
        public static object CntStrConfig { get; internal set; }

        static string GetConnectionStringByName(string name)
        {
            // Assume failure.
            string returnValue = null;

            // Look for the name in the connectionStrings section.

            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];

            // If found, return the connection string.
            if (settings == null)
            {
                Console.WriteLine("Connectionstring is not defined");
            }
            else
            {
                foreach (var s in settings.ConnectionString)
                    returnValue = settings.ConnectionString;
                Console.WriteLine(settings.ProviderName);
                Console.WriteLine(settings.ConnectionString);

            }
            return returnValue;
        }
    }
}

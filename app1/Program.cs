using System;
using System.Collections.Specialized;
using System.Configuration;
using app1;
using CreateSocket;

namespace app1
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagerLogFile.CreateFileLog();
            Configsection.GetConfigurationUsingSection();
            ManagerLogFile.LogStatus("Status of method");

            //ConfigCntStr.CntStrConfig.GetConnectionStringByName("QueueConnStr");
            //GetConfigurationUsingSection();
            //GetConfigAppsettings("LogPath");
        }

    }

    // Retrieves a connection string by name.
    // Returns null if the name is not found.
    /*static string GetConnectionStringByName(string name)
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


    public static void GetConfigurationUsingSection()
    {
        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        /*if (applicationSettings.Count == 0)
        {
            Console.WriteLine("Application Settings are not defined");
        }
        else
        {
            returnValue = applicationSettings.ToString();

            foreach (var key in applicationSettings.AllKeys)
            {
                Console.WriteLine(returnValue);
            }
        }
        string sectionName = "appSettings";

        // Add an entry to appSettings.
        int appStgCnt = ConfigurationManager.AppSettings.Count;
        for (int i = 0; i < appStgCnt; i++)
        {
            string newKey = "NewKey" + i.ToString();

            string newValue = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString();

            config.AppSettings.Settings.Add(newKey, newValue);

            // Save the configuration file.
            config.Save(ConfigurationSaveMode.Modified);

            // Force a reload of the changed section. This 
            // makes the new values available for reading.
            ConfigurationManager.RefreshSection(sectionName);
        }
        // Get the AppSettings section.
        AppSettingsSection appSettingSection = (AppSettingsSection)config.GetSection(sectionName);

        Console.WriteLine();
        Console.WriteLine("Using GetSection(string).");
        Console.WriteLine("AppSettings section:");
        Console.WriteLine(appSettingSection.SectionInformation.GetRawXml());
    }
 public static string GetConfigAppsettings(string name)
{
    string returnValue1 = null;
    string svalue = ConfigurationManager.AppSettings.Get("LogPath");

    Console.WriteLine("The value of LogPath is" + svalue);
    returnValue1 = svalue;

    NameValueCollection sAllname;

    sAllname = ConfigurationManager.AppSettings;
    if (sAllname.Count == 0)
    {
        Console.WriteLine("AppSettings is emty");
    }
    else
    {
        foreach (var sAn in sAllname)
            Console.WriteLine("name" + sAn + "value" + sAllname.Get((string)sAn));
        Console.WriteLine();

    }
    return returnValue1;
    }

}*/

}
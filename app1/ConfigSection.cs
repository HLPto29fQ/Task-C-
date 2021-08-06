using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app1
{
    public class Configsection
    {
        public static void GetConfigurationUsingSection()
        {   
            
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            string sectionName = "appSettings";
            int appStgCnt = Int32.Parse(Console.ReadLine());
            // Add an entry to appSettings.
            appStgCnt = ConfigurationManager.AppSettings.Count;
            for (int i = 0; i < appStgCnt; i++)
            {   
                Console.WriteLine("Name of newkey:");
               
                string newKey = Console.ReadLine();

                string newVl =Console.ReadLine();

                config.AppSettings.Settings.Add(newKey, newVl);

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
    }
}

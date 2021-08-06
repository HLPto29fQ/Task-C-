using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app1 {
    class configofminio{ 

    public static void GetConfigAppsettings(string name)
    {
        string returnValue1 = null;
        string svalue = ConfigurationManager.AppSettings.Get((string)name);

        Console.WriteLine("The value of"+name+"is" + svalue);
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
       
    }

}
}




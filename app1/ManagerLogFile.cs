using System;
using System.IO;
using System.Diagnostics;


namespace app1
{
     public class ManagerLogFile
     { 
         
         public static void CreateFileLog()
        {
            string path = "C:/Temp/log.txt";
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            if (directoryInfo.Exists)
            {
                Console.WriteLine("Creation Time: " + directoryInfo.CreationTime.ToString());
                Console.WriteLine("Last Access Time: " + directoryInfo.LastAccessTime.ToString());
                Console.WriteLine("Directory contains: " + directoryInfo.GetFiles().Length.ToString() + " files");
            }
            else
            {
                FileStream fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite);
                Console.WriteLine("Creation Time: " + directoryInfo.CreationTime.ToString());
                Console.WriteLine("Last Access Time: " + directoryInfo.LastAccessTime.ToString());
                Console.WriteLine("Directory contains: " + directoryInfo.GetFiles().Length.ToString() + " files");
            }

            /*TextWriter write = File.AppendText("log.txt");
             String myFileName = "log.txt";
             StreamWriter fileWrite = new StreamWriter(myFileName, true);
            */

        }
        public static void LogStatus(string sttMess)
        {   
            TextWriter writestatus=File.AppendText("C:/Temp/log.txt");
            StackFrame stackFrame = new StackTrace(1).GetFrame(1);
            string fileName = stackFrame.GetFileName();
            string methodName = stackFrame.GetMethod().ToString();
            int lineNumber = stackFrame.GetFileLineNumber();

            writestatus.WriteLine($"{ DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString() }");
            writestatus.WriteLine("{0}({1}:{2})\n{3}", methodName, Path.GetFileName(fileName), lineNumber, sttMess);
            writestatus.Flush();
            writestatus.Close();
        }
        public void LogForDebug(string debugMess)
        {
            try
            {
                
            }
            catch
            {
                StackFrame stackFrame = new StackTrace(1).GetFrame(1);
                string methodName = stackFrame.GetMethod().ToString();
                int lineNumber = stackFrame.GetFileLineNumber();
                TextWriter writedebug = File.AppendText("C:/Temp/log.txt");
                writedebug.WriteLine($"{ DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString() }");
                writedebug.WriteLine("{0} : {1} :{2} :{3}", methodName, lineNumber, debugMess,"Error");
            }
        }
        
    }
}

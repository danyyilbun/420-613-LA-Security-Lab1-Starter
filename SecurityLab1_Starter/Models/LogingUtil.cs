using Glimpse.AspNet.Tab;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityLab1_Starter.Models {
    public class LogingUtil {


        public void LogEvent(Exception sr,EventLogEntryType type) {

            using (EventLog eventLog = new EventLog("Application")) {
                eventLog.Source = "Application";
                eventLog.WriteEntry(sr + " LOGGED ERROR " + DateTime.Now, type, 101, 1);
            }

        }
        public void logToText(ExceptionContext filterContext) 
        {
            filterContext.ExceptionHandled = true;


            //Log the error!!
            if (System.IO.File.Exists(@"C:\Temp\Log.txt")) {
                using (StreamWriter w = System.IO.File.AppendText(@"C:\Temp\Log.txt")) {
                    Log(filterContext.Exception.ToString(), w);
                    w.Close();
                }


            }
            else {
                using (FileStream fs = System.IO.File.Create(@"C:\Temp\Log.txt")) {

                    using (StreamReader r = System.IO.File.OpenText(@"C:\Temp\Log.txt")) {
                        DumpLog(r);

                        r.Close();
                    }
                    fs.Close();
                }
            }

        }
        public static void Log(string logMessage, TextWriter w) {
            w.Write("\r\nLog Entry : ");
            w.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
            w.WriteLine("  :");
            w.WriteLine($"  :{logMessage}");
            w.WriteLine("-------------------------------");
        }

        public static void DumpLog(StreamReader r) {
            string line;
            while ((line = r.ReadLine()) != null) {
                Console.WriteLine(line);
            }
        }
    }
}
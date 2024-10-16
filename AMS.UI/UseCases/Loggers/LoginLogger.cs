using System;
using System.IO;

namespace AMS.UI.UseCases.Loggers
{
    public class LoginLogger
    {
        private const string LogFilePath = "Login_History.txt";

        public static void LogLogin(string username)
        {
            string logEntry = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}, {username}";
            AppendLog(logEntry);
        }

        private static void AppendLog(string logEntry)
        {
            try
            {
                File.AppendAllText(LogFilePath, logEntry + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while writing to the log file: " + ex.Message);
            }
        }
    }
}

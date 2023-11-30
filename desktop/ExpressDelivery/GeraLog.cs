using System;
using System.IO;

namespace ExpressDelivery
{
    public class GeraLog
    {
        public static bool PrintError(string value)
        {
            DateTime currentDateTime = DateTime.Now;
            var formatedDate = currentDateTime.ToString("yyyyMMdd");
            var formatedDateTime = currentDateTime.ToString("yyyyMMddHHmmss");

            string fileName = "\\logErro" + formatedDate + ".txt";
            string directory = Directory.GetCurrentDirectory();
            string folderName = directory + "\\logs";
            string path = folderName + fileName;

            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }

            var message = "[" + formatedDateTime + "][ERROR] " + value;

            return Print(path, message);
        }

        public static bool PrintInfo(string value)
        {
            DateTime currentDateTime = DateTime.Now;
            var formatedDate = currentDateTime.ToString("yyyyMMdd");
            var formatedDateTime = currentDateTime.ToString("yyyyMMddHHmmss");

            string fileName = "\\log" + formatedDate + ".txt";
            string directory = Directory.GetCurrentDirectory();
            string folderName = directory + "\\logs";
            string path = folderName + fileName;

            if (!Directory.Exists(folderName))
            {
                Directory.CreateDirectory(folderName);
            }

            var message = "[" + formatedDateTime + "][INFO] " + value;

            return Print(path, message);
        }

        private static bool Print(string path, string value)
        {
            StreamWriter sw = null;
            try
            {
                if (!File.Exists(path))
                {
                    sw = File.CreateText(path);
                    sw.WriteLine(value);
                    return true;
                }

                using (sw = File.AppendText(path))
                {
                    sw.WriteLine(value);
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(@"The process failed: ", e);
                return false;
            }
            finally
            {
                if (sw != null)
                    sw.Close();
            }
        }
    }
}
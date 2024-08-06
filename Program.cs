using System;
using System.IO;
using System.Text;

namespace DriveLogger
{
    internal static class Program
    {
        private const string LogFolderName = "log";
        private const string DateFormat = "yyyy/MM/dd HH:mm:ss";

        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("ドライブレターを引数として指定してください。例: D F");
                return;
            }

            DateTime currentTime = DateTime.Now;
            string header = CreateHeader(args);
            string csvLine = CreateCsvLine(currentTime, args);

            string logDirectory = CreateLogDirectory();
            string csvFileName = CreateCsvFileName(args, currentTime);
            string csvFilePath = Path.Combine(logDirectory, csvFileName);

            WriteToCsvFile(csvFilePath, header, csvLine);
        }

        private static string CreateHeader(string[] driveLetters)
        {
            StringBuilder headerBuilder = new StringBuilder("日時");
            foreach (var driveLetter in driveLetters)
            {
                headerBuilder.Append($",{driveLetter}容量,{driveLetter}空き容量");
            }

            return headerBuilder.ToString();
        }

        private static string CreateCsvLine(DateTime currentTime, string[] driveLetters)
        {
            StringBuilder csvLineBuilder = new StringBuilder(currentTime.ToString(DateFormat));
            foreach (var driveLetter in driveLetters)
            {
                csvLineBuilder.Append("," + GetDriveStatInfo(driveLetter));
            }

            return csvLineBuilder.ToString();
        }

        private static string CreateLogDirectory()
        {
            string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string logDirectory = Path.Combine(exeDirectory, LogFolderName);
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }

            return logDirectory;
        }

        private static string CreateCsvFileName(string[] driveLetters, DateTime currentTime)
        {
            string drives = string.Join("_", driveLetters);
            string yearMonth = currentTime.ToString("yyyy_MM");
            return $"drive_stat_{drives}_{yearMonth}.csv";
        }

        private static void WriteToCsvFile(string csvFilePath, string header, string csvLine)
        {
            bool fileExists = File.Exists(csvFilePath);
            using (StreamWriter writer = new StreamWriter(csvFilePath, true))
            {
                if (!fileExists)
                {
                    writer.WriteLine(header);
                }

                writer.WriteLine(csvLine);
            }
        }

        private static string GetDriveStatInfo(string driveLetter)
        {
            DriveInfo drive = new DriveInfo(driveLetter);
            if (drive.IsReady && drive.DriveType == DriveType.Fixed)
            {
                float totalSizeGb = (float)drive.TotalSize / (1024 * 1024 * 1024);
                float totalFreeSpaceGb = (float)drive.TotalFreeSpace / (1024 * 1024 * 1024);
                return $"{totalSizeGb:F2},{totalFreeSpaceGb:F2}";
            }
            else
            {
                return "-1,-1";
            }
        }
    }
}
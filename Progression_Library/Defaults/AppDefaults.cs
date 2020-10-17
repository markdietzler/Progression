using System;

namespace Progression_Library.Defaults
{
    public class AppDefaults
    {
        public static string PoE_LogFile
        {
            get
            {
                return @"D:\Games\Path of Exile\logs\Client.txt";
            }
        }

        public static string POE_Logs
            
        {
            get
            {
                return @"D:\Games\Path of Exile\logs\";
            }
            
        }

        public static string ProgressionConfigs
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Progression";
            }
        }

        public static string PathOfBuilding
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Progression\PoE_builds";
            }
        }

        public static string ProgressionData
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + @"\Progression";
            }
        }
    }
}

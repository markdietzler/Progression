using Progression_Library.Defaults;
using System;
using System.IO;
using System.Threading;

namespace Progression_CL
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(AppDefaults.PoE_LogFile);
            //File.WriteAllLines("test.txt", new string[] { "XX","YY"});

            new Thread(() => ReadFromFile(AppDefaults.PoE_LogFile, AppDefaults.POE_Logs)).Start();

            //WriteToFile();
        }

        private static void ReadFromFile(string fileToWatch, string folderToWatch)
        {
            long _offset = 0;
            FileSystemWatcher _fsw = new FileSystemWatcher
            {
                Path = folderToWatch,
                Filter = fileToWatch
            };

            FileStream file = File.Open(
                fileToWatch,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Write
                );

            StreamReader reader = new StreamReader(file);
            while(true)
            {
                _fsw.WaitForChanged(WatcherChangeTypes.Changed);
                file.Seek(_offset, SeekOrigin.Begin);
                if(!reader.EndOfStream)
                {
                    do
                    {
                        Console.WriteLine(reader.ReadLine());
                    } while (!reader.EndOfStream);

                    _offset = file.Position;
                }
            }
        } //end of method

        private static void WriteToFile()
        {
            for(int i = 100; i < 100; i++)
            {
                FileStream writeFile = File.Open(
                    "test.txt",
                    FileMode.Append,
                    FileAccess.Write,
                    FileShare.Read
                    );
                using(FileStream file = writeFile)
                {
                    using(StreamWriter sw = new StreamWriter(file))
                    {
                        sw.WriteLine(i);
                        Thread.Sleep(100);
                    }
                }
            }
        } //end of method
    }
}

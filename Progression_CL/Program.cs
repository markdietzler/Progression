using System;
using System.IO;

namespace Progression_CL
{
    public class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            using (var fs = new FileStream(@"D:\Games\Path of Exile\logs\Client.txt", FileMode.Open,FileAccess.Read, FileShare.ReadWrite))
            using (var sr = new StreamReader(fs))
            {
                if(sr.BaseStream.Length > 1024)
                {
                    sr.BaseStream.Seek(-512, SeekOrigin.End);
                }

                while (true)
                {
                    string line = await sr.ReadLineAsync();

                    if(line != null)
                    {
                        if(line.Contains("You have entered"))
                        {
                            Console.WriteLine("Player changed area");
                        }
                        if (line.Contains("is now level")){
                            Console.WriteLine("Player levelled up");
                        }
                        
                    }

                    //await sr.ReadLineAsync();
                }
            }
        }
    }
}

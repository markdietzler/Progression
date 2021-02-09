using System;

namespace Progression_CL
{
    public class Program

    //async System.Threading.Tasks.Task
    {
        static void Main(string[] args)
        {
            /*using (var fs = new FileStream(@"D:\Games\Path of Exile\logs\Client.txt", FileMode.Open,FileAccess.Read, FileShare.ReadWrite))
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
            }*/

            // 0    1     2      3     4  5  6     7     8
            //helm chest gloves boots mh oh ring1 ring2 2h? 

            //bool[] test = new bool[9];

            //test[0] = true;
            //test[2] = true;
            //test[3] = true;
            //test[6] = true;
            //test[8] = true;
                        
            //GearSlot skills = new GearSlot(test);

            //OneSlot test = new OneSlot();
            //ThreeSlot test = new ThreeSlot();
            //FourSlot test = new FourSlot();
            //SixSlot test = new SixSlot();

            //Console.WriteLine(test);

            //test.SetSkill("Ichi");
            //test.SetSkill(0, "Ichi");
            //test.SetSkill(1, "Ni");
            //test.SetSkill(2, "San");
            //test.SetSkill(3, "Shi");
            //test.SetSkill(4, "Ro");
            //test.SetSkill(5, "Roku");
               

            Console.WriteLine("End of test\n");
        }
    }
}

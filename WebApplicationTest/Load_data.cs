using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BackEnd_proj
{
    internal  class Load_data
    {
        public static string Load()

        {

            StringBuilder tsvcontent = new StringBuilder();
            string[] filesArray;
            //StreamWriter outputFile = new StreamWriter("Data.txt");
            if (File.Exists("Data.tsv") != true)
            {
                for (int i = 1; i <= 10; i++)
                {
                    string[] directories = Directory.GetFiles(@"ImageData/" + i);
                    for (int j = 0; j < directories.Length; j++)
                    {
                        Console.WriteLine(i + "-----" + j);
                        if (i != 10)
                            tsvcontent.AppendLine(directories[j].Remove(0, 12) + "\t" + GetT(i));
                        else
                            tsvcontent.AppendLine(directories[j].Remove(0, 13) + "\t" + GetT(i));

                    }
                }
                File.AppendAllText("Data.tsv", tsvcontent.ToString());
                Console.WriteLine("Data.tsv is created");
                //Console.WriteLine(tsvcontent.ToString());
            }
            else
                Console.WriteLine("Data.tsv file is already there");
            return tsvcontent.ToString();
        }
        public static string GetT(int num)
        {
            if (num == 1)
                return "palm";
            else if (num == 2)
                return "i";
            else if (num == 3)
                return "fist";
            else if (num == 4)
                return "fist_moved";
            else if (num == 5)
                return "thumb";
            else if (num == 6)
                return "index";
            else if (num == 7)
                return "ok";
            else if (num == 8)
                return "palm_moved";
            else if (num == 9)
                return "c";
            else 
                return "down";


        }
    }
}

    
    
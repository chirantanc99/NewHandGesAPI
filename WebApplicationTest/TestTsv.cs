using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd_proj
{
    internal class TestTsv
    {
        public void Load()
        {
            StringBuilder tsvcontent = new StringBuilder();

            //StreamWriter outputFile = new StreamWriter("Data.txt");
            if (File.Exists("TestData.tsv") != true)
            {

                string[] directories = Directory.GetFiles(@"Test_data/");
                for (int j = 0; j < directories.Length; j++)
                {



                    tsvcontent.AppendLine(directories[j].Remove(0, 10));

                }

                File.AppendAllText("TestData.tsv", tsvcontent.ToString());
                Console.WriteLine("TestData.tsv is created");
                //Console.WriteLine(tsvcontent.ToString());
            }
            else
                Console.WriteLine("TestData.tsv file is already there");
        }

    }
}


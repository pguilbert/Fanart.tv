using Fanart;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    class Program
    {
        private static string FanartApiKey = string.Empty;
        static void Main(string[] args)
        {
            try
            {
                FanartApiKey = File.ReadAllText("ApiKey.txt");
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur lors de la récupération de la clé");
                Console.WriteLine(e.Message);
                Environment.Exit(1);
            }

            string midTest = "084308bd-1654-436f-ba03-df6697104e19"; // Green Day musicbrain id

            Artist a1 = Artist.LoadArtist(midTest, FanartApiKey);


            Console.Read();
            
        }


    }
}

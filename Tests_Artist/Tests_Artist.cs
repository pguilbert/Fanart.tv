using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Fanart.tv;

namespace Tests
{
    [TestClass]
    public class Tests_Artist
    {
        private static string FanartApiKey = string.Empty;

        [ClassInitialize()]
        public static void LoadApiKey(TestContext a)
        {
            try
            {
                FanartApiKey = File.ReadAllText("ApiKey.txt");
            }
            catch (Exception e)
            {
                Assert.Fail("Erreur lors de la récupération de la clé");
            }
        }

        [TestMethod]
        public void Test_LoadArtist()
        {
            string midTest = "084308bd-1654-436f-ba03-df6697104e19"; // Green Day musicbrain id

            Artist a1 = Artist.LoadArtist(midTest, FanartApiKey);

            Assert.IsNotNull(a1);
            Assert.AreEqual<string>(a1.artistname, "Green Day");
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Fanart.tv
{
    public class Artist
    {
        /// <summary>
        /// Charge les informations depuis le site Fanart.tv
        /// </summary>
        /// <param name="musicbrainz_mbid">mbid de l'artiste</param>
        /// <param name="fanart_api_key">Fanart.tv Api Key</param>
        /// <returns></returns>
        public static Artist LoadArtist(string musicbrainz_mbid, string fanart_api_key)
        {
            string ApiUrl = "http://api.fanart.tv/webservice/artist/" + fanart_api_key + "/" + musicbrainz_mbid + "/";

            try
            {
                WebClient client = new WebClient();
                string data = client.DownloadString(ApiUrl);

                Dictionary<string, Artist> artists = JsonConvert.DeserializeObject<Dictionary<string, Artist>>(data);

                foreach (KeyValuePair<string, Artist> kvp in artists)
                {
                    kvp.Value.artistname = kvp.Key;
                    return kvp.Value;
                }

                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            
        }

        public string artistname { get; set; }
        public Guid mb_id { get; set; }
        public List<Image> artistthumb { get; set; }
        public List<Image> artistbackground { get; set; }
    }

}

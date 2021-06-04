using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Cecs475.BoardGames.WpfApp
{


    //public class allGames
    //{
    //    public Game[] dlGamesList { get; set; }
    //}

    public class Game
    {
        public string Name { get; set; }
        public File[] Files { get; set; }
    }

    public class File
    {
        public string FileName { get; set; }
        public string Url { get; set; }
        public string PublicKey { get; set; }
        public string Version { get; set; }
    }

    public class WebClient
    {
        public async Task ProcessGames()
        {
            //Connects to the rest client and retrieves the json file
            var client = new RestClient("https://cecs475-boardamges.herokuapp.com/api/games");
            var request = new RestRequest("", Method.GET);
            var response = client.Execute(request);
            Console.WriteLine("Outputted JSON" + response.Content);
            List<Game> responses = JsonConvert.DeserializeObject<List<Game>>(response.Content);
            foreach (var i in responses)
            {
                Console.Write(i + "Here");
            }
            //Iterates through games to find URL
            string path = "../Debug/games/";
            using (System.Net.WebClient wc = new System.Net.WebClient())
            {
                foreach (Game game in responses){
                    Console.Write("Game Name:" + game.Name);

                    foreach (File file in game.Files)
                    {
                        //load the URLs
                        await wc.DownloadFileTaskAsync(new System.Uri(file.Url), path + file.FileName);
                    }
                }
            }
        }
    }

}

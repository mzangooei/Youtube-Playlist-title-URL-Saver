using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.YouTube.v3;
using Google.Apis.Services;


namespace utube_cmd
{
    class Program
    {
        static void Main(string[] args)
        {

            YouTubeService yt = new YouTubeService(new BaseClientService.Initializer() { ApiKey = "AIzaSyALpzdXBuC6_QdDCnUOZVfVUfm6TZ7I-qY" });
            var searchListRequest = yt.PlaylistItems.List("snippet");
            Console.Write("Enter your Playlist id:");
            searchListRequest.PlaylistId = Console.ReadLine();
            searchListRequest.MaxResults = 50;
          //  searchListRequest.ChannelId = "UCrMN-prCdKoOCk3VBmInyKA";
            var searchListResult = searchListRequest.Execute();
            var nextPageToken = "";
            while (nextPageToken != null)
            {
                searchListRequest.PageToken = nextPageToken;
                searchListResult = searchListRequest.Execute();

                foreach (var item in searchListResult.Items)
                {

                    //  Console.WriteLine("ID:" + item.Snippet.Title);
                    Console.WriteLine("");
                    Console.WriteLine("snippet:" + item.Snippet.Title);
                    Console.WriteLine("https://www.youtube.com/watch?v=" + item.Snippet.ResourceId.VideoId);
                 
                }

                nextPageToken = searchListResult.NextPageToken;

            }

            Console.WriteLine("\nOK");
            Console.ReadLine();
        }
    }
}

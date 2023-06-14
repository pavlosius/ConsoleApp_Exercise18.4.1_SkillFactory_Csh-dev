using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;

namespace YoutubeVideoDownloader
{
    class GetVideoInfoCommand : Command
    {
        YoutubeClient _youtubeClient;
        string _videoUrl;
        public GetVideoInfoCommand(YoutubeClient youtubeClient, string videoUrl)
        {
            _youtubeClient = youtubeClient;
            _videoUrl= videoUrl;
        }

        public override void Execute()
        {
            GetVideoInfo();
        }

        private void GetVideoInfo()
        {
            try
            {
                var video = _youtubeClient.Videos.GetAsync(_videoUrl);

                Console.WriteLine("\nИнформация о видео:");
                Console.WriteLine($"\nUrl: {video.Result.Url}");
                Console.WriteLine($"\nНазвание: {video.Result.Title}");
                Console.WriteLine($"\nАвтор: {video.Result.Author}");
                Console.WriteLine($"\nОписание: {video.Result.Description}");
                Console.WriteLine($"\nПродолжительность: {video.Result.Duration}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

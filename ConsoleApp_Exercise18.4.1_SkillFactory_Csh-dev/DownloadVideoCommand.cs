using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Videos.Streams;

namespace YoutubeVideoDownloader
{
    class DownloadVideoCommand : Command
    {
        YoutubeClient _youtubeClient;

        string _videoUrl;

        public DownloadVideoCommand(YoutubeClient youtubeClient, string videoUrl)
        {
            _youtubeClient = youtubeClient;
            _videoUrl = videoUrl;
        }

        public override void Execute()
        {
            DownloadVideo();
        }

        private async Task DownloadVideo()
        {
            try
            {
                var streamManifest = await _youtubeClient.Videos.Streams.GetManifestAsync(_videoUrl);

                var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();

                Console.WriteLine("\nНачалась загрузка видео...");

                await _youtubeClient.Videos.Streams.DownloadAsync(streamInfo, $"video.{streamInfo.Container}");

                Console.WriteLine("\nЗагрузка видео окончена.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

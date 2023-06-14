using YoutubeExplode;
using YoutubeVideoDownloader;

if (args.Length > 0)
{
    string videosUrl = args[0];

    var sender = new Sender();

    YoutubeClient youtubeClient = new YoutubeClient();

    var getVideoInfoCommand = new GetVideoInfoCommand(youtubeClient, videosUrl);

    sender.SetCommand(getVideoInfoCommand);

    sender.Execute();

    var downloadVideoCommand = new DownloadVideoCommand(youtubeClient, videosUrl);

    sender.SetCommand(downloadVideoCommand);

    sender.Execute();

    Console.WriteLine("\nДождитесь загрузки видео. Для выхода из программы нажмите любую клавишу...");
}
else
{
    Console.WriteLine("\nОтсуствует аргумент программы (адрес видео)");
}
Console.ReadKey();
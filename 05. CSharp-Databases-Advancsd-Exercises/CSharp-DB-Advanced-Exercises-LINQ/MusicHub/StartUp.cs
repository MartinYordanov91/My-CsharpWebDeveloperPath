namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Text;
    using Data;
    using Initializer;
    using MusicHub.Data.Models;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here

            var test = ExportSongsAboveDuration(context, 4);
            Console.WriteLine(test);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var sb = new StringBuilder();

            var albumsInfo = context.Albums
                 .Where(a => a.ProducerId.HasValue && a.ProducerId.Value == producerId)
                 .Select(a => new
                 {

                     albumName = a.Name,
                     ReleaseDate = a.ReleaseDate
                         .ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
                     ProducerName = a.Producer!.Name,
                     songs = a.Songs
                         .Select(s => new
                         {
                             songName = s.Name,
                             songPrice = s.Price,
                             writerName = s.Writer.Name,

                         }).ToList(),
                     albumPrice = a.Songs.Sum(s => s.Price),


                 })
                 .ToList();


            foreach (var a in albumsInfo.OrderByDescending(a => a.albumPrice))
            {

                sb.AppendLine($"-AlbumName: {a.albumName}");
                sb.AppendLine($"-ReleaseDate: {a.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {a.ProducerName}");
                sb.AppendLine($"-Songs:");

                var counter = 1;

                foreach (var s in a.songs
                         .OrderByDescending(s => s.songName)
                         .ThenBy(s => s.writerName))
                {
                    sb.AppendLine($"---#{counter}");
                    sb.AppendLine($"---SongName: {s.songName}");
                    sb.AppendLine($"---Price: {s.songPrice:f2}");
                    sb.AppendLine($"---Writer: {s.writerName}");
                    counter++;
                }

                sb.AppendLine($"-AlbumPrice: {a.albumPrice:f2}");


            }

            return sb.ToString().Trim();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var sb = new StringBuilder();

            var songsColection = context.Songs
                .ToList()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    SongName = s.Name,
                    PeerformerNames = s.SongPerformers
                        .Select(p => new { performerName = $"{p.Performer.FirstName} {p.Performer.LastName}" })
                        .OrderBy(p => p.performerName)
                        .ToList(),
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album!.Producer!.Name,
                    Duration = s.Duration.ToString("c"),
                })
                .OrderBy(s => s.SongName)
                .ThenBy(s => s.WriterName)
                .ToList();

            var songCounter = 1;

            foreach (var s in songsColection)
            {
                sb.AppendLine($"-Song #{songCounter}");
                sb.AppendLine($"---SongName: {s.SongName}");
                sb.AppendLine($"---Writer: {s.WriterName}");


                foreach (var p in s.PeerformerNames)
                {
                    sb.AppendLine($"---Performer: {p.performerName}");
                }


                sb.AppendLine($"---AlbumProducer: {s.AlbumProducer}");
                sb.AppendLine($"---Duration: {s.Duration}");

                songCounter++;
            }

            return sb.ToString().Trim();
        }
    }
}

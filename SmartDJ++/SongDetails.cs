using System;
using System.Linq;
using System.IO;
namespace SmartDJ__{
    class SongDetails{
        public SongDetails(String songPath){
            if (!File.Exists(songPath)) throw new Exception("File does not exists");
            else
            {
                TagLib.File f = TagLib.File.Create(songPath);
                MusicBrainzTrackId = f.Tag.MusicBrainzTrackId;
                Title = f.Tag.Title;
                Duration = f.Properties.Duration;
                Year = (Int32)f.Tag.Year;
                Album = f.Tag.Album;
                Composers = f.Tag.Composers;
                InitialKey = f.Tag.InitialKey;
                Language = customField(f, "TLAN");
                MusicBrainzReleaseCountry = f.Tag.MusicBrainzReleaseCountry;
                BeatsPerMinute = (Int32)f.Tag.BeatsPerMinute;
                RecordLabel = f.Tag.Publisher;
                Genres = f.Tag.Genres;
                Performers = f.Tag.Performers;
                AlbumArtists = f.Tag.AlbumArtists;
            }
        }
        public String MusicBrainzTrackId { get; set; }
        public string Title { get;  set; }
        public TimeSpan Duration { get;  set; }
        public String InitialKey { get;  set; }
        public String[] Composers { get;  set; }
        public String Album { get;  set; }
        public Int32 Year { get;  set; }
        public String Language { get; set; }
        public Int32 BeatsPerMinute { get;  set; }
        public string[] Performers { get;  set; }
        public string[] Genres { get;  set; }
        public string[] AlbumArtists { get;  set; }
        public string MusicBrainzReleaseCountry { get;  set; }
        public string RecordLabel { get;  set; }
        public string JoinedPerformers {get { return String.Join(",", Performers); } }
        public string JoinedComposers {get { return String.Join(",", Composers); } }
        public string JoinedGenres {get { return String.Join(",", Genres); } }
        public string JoinedAlbumArtists { get { return String.Join(",", AlbumArtists); } }
        private String customField(TagLib.File f, String field){
            TagLib.Id3v2.Tag t = (TagLib.Id3v2.Tag)f.GetTag(TagLib.TagTypes.Id3v2);
            var list = t.GetFrames().ToArray().GroupBy(x => x.FrameId).Select(x => x.First()).ToDictionary(itm => itm.FrameId, itm => itm.ToString());
            if (list.ContainsKey(field)) return list[field]; else return "";
        }
    }
}
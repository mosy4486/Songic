using System;
using System.Collections.Generic;
using System.Text;

namespace Songic
{
    public struct SongRequestData
    {
        public string title;
        public string artist;

        public static bool ValidData(SongRequestData s)
        {
            bool b1 = !string.IsNullOrEmpty(s.title) && !string.IsNullOrWhiteSpace(s.title);
            bool b2 = !string.IsNullOrEmpty(s.artist) && !string.IsNullOrWhiteSpace(s.artist);
            return b1 || b2;
        }
    }
    public struct Lyric
    {
        public double time;
        public string content;
    }
    public class Song
    {
        public int id { get; set; }

        public string trackName { get; set; }

        public string artistName { get; set; }

        public string albumName { get; set; }

        public double duration { get; set; }

        public bool instrumental { get; set; }

        public bool hasWordSync { get; set; }

        public string plainLyrics { get; set; }

        public string syncedLyrics { get; set; }

        public string lyricsfile { get; set; }
    }
}

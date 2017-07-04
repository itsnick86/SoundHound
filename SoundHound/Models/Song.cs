using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Model for the AddSong view. It represents the song data that is to be collecected

namespace SoundHound.Models
{
    public class Song
    {
        public string SongTitle { get; set; }

        public string Artist { get; set; }

        public string Key { get; set; }

        public int BPM { get; set; }
    }
}
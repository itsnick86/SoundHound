using SoundHound.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SoundHound.Repositories
{
    //Class to help store, edit, and delete items from the Song list
    public class SongRepository : DbContext
    {

        public DbSet<Song> Songs { get; set; }

        public SongRepository() : base("SongRepository")
        {
            Debug.Write(Database.Connection.ConnectionString);
        }

        public void AddSong(Song song)
        {
            Songs.Add(song);
            this.SaveChanges();
        }

        public Song GetSong(int id)
        {
            return (from Song in Songs
                    where Song.ID == id
                    select Song).First();
        }

        public void EditSong(Song song)
        {
            this.Entry(song).State = EntityState.Modified;
            this.SaveChanges();
        }

        public void DeleteSong(Song song)
        {
            this.Entry(song).State = EntityState.Deleted;
            this.SaveChanges();
        }
    }
}
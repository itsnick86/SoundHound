using SoundHound.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;

namespace SoundHound.Controllers
{
    public class HomeController : Controller
    {
        static SongRepository _songRepository = new SongRepository();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CreateSong()
        {
            return View("AddSong");
        }

        public ActionResult AddSong(Song song)
        {
            _songRepository.AddSong(song);
            return View("SingleSong", song);
        }

        public ActionResult YourSongs()
        {
            return View("SongList", _songRepository.Songs);
        }

        //Class to help store Song list
        public class SongRepository
        {

            public void AddSong(Song song)
            {
                using (var connection = CreateConnection())
                {
                    connection.Execute("INSERT INTO SONGS (SONGTITLE, ARTIST, SONGKEY, BPM) VALUES (@songtitle, @artist, @songkey, @BPM)", new { songtitle = song.SongTitle, artist = song.Artist, songkey = song.SongKey, BPM = song.BPM });
                }
            }

            public List<Song> Songs
            {
                get
                {
                    using (var connection = CreateConnection())
                    {
                        return connection.Query<Song>("SELECT * FROM SONGS").ToList();
                    }
                }
            }

            private IDbConnection CreateConnection()
            {
                return new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=SoundHound;Trusted_Connection=True");
            }
        }
    }
}
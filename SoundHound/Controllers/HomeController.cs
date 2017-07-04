using SoundHound.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult ViewSongs()
        {
            return View("SongList", _songRepository._songs);
        }

        //Class to help store Song list
        public class SongRepository
        {
            public List<Song> _songs = new List<Song>();

            public void AddSong(Song song)
            {
                _songs.Add(song);
            }
        }
    }
}
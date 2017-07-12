using SoundHound.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using SoundHound.Repositories;

namespace SoundHound.Controllers
{
    public class HomeController : Controller
    {
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
            using (var repo = new SongRepository())
            {
                repo.AddSong(song);
                return View("SingleSong", song);
            }
        }

        public ActionResult YourSongs()
        {
            using (var repo = new SongRepository())
            {
                return View("SongList", repo.Songs.ToList());
            }
        }

        public ActionResult EditSong(int id)
        {
            using (var repo = new SongRepository())
            {
                return View("EditSong", repo.GetSong(id));
            }
        }

        public ActionResult ChangeSong(Song song)
        {
            using (var repo = new SongRepository())
            {
                repo.EditSong(song);
                return View("SongList", repo.Songs.ToList());
            }
        }

        public ActionResult DeleteSong(Song song)
        {
            using (var repo = new SongRepository())
            {
                repo.DeleteSong(song);
                return View("SongList", repo.Songs.ToList());
            }
        }
    }
}
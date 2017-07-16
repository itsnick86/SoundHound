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

        public ActionResult CreateSong()
        {
            return View("AddSong");
        }

        // After the user enters information into the AddSong view and selects the Add Song button the information will be added to the SongRepository
        public ActionResult AddSong(Song song)
        {
            using (var repo = new SongRepository())
            {
                repo.AddSong(song);
                return View("SingleSong", song);
            }
        }

        // Returns the SongList view and shows the list of songs saved in the SongRepository
        public ActionResult YourSongs()
        {
            using (var repo = new SongRepository())
            {
                return View("SongList", repo.Songs.ToList());
            }
        }

        // Changes current view to the EditSong view when the user selects the Edit Button
        public ActionResult EditSong(int id)
        {
            using (var repo = new SongRepository())
            {
                return View("EditSong", repo.GetSong(id));
            }
        }

        // After the user selects the Update Song button in the EditSong view it will update the SongRepository with the changes
        public ActionResult ChangeSong(Song song)
        {
            using (var repo = new SongRepository())
            {
                repo.EditSong(song);
                return View("SongList", repo.Songs.ToList());
            }
        }

        // Removes songs from the SongList when the user selects the Delete Button
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
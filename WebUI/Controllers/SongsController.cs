using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;

namespace WebUI.Controllers
{
    public class SongsController : Controller
    {
        // GET: Songs
        public ActionResult Index()
        {
            var songs = DAL.SongRepository.GetAll();
            return View(songs);
        }

        // GET: Songs/Details/5
        public ActionResult Details(int id)
        {
            var song = DAL.SongRepository.GetById(id);
            return View(song);
        }

        // GET: Songs/Create
        public ActionResult Create(int? albumId = null)
        {
            ViewData["AlbumId"] = albumId;
            return View();
        }

        // POST: Songs/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                string albumId = collection["AlbumId"];
                string name = collection["Name"];
                string artist = collection["Artist"];
                Genre genre = (Genre)int.Parse(collection["Genre"]);

                var song = new Common.Song(0, name, artist, genre);
                if(!string.IsNullOrWhiteSpace(albumId))
                {
                    song.AlbumId = int.Parse(albumId);
                }

                DAL.SongRepository.Create(song);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Songs/Edit/5
        public ActionResult Edit(int id)
        {
            var song = DAL.SongRepository.GetById(id);

            return View(song);
        }

        // POST: Songs/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var song = DAL.SongRepository.GetById(id);
                var name = collection["Name"];
                var artist = collection["Artist"];
                var genre = int.Parse(collection["Genre"]);
                song.Name = name;
                song.Artist = artist;
                song.Genre = (Common.Genre)genre;
                DAL.SongRepository.Update(song);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Songs/Delete/5
        public ActionResult Delete(int id)
        {
            var song = DAL.SongRepository.GetById(id);
 
            return View(song);
        }

        // POST: Songs/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                DAL.SongRepository.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

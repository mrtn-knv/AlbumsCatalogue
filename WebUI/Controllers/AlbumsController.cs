using Common;
using System;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class AlbumsController : Controller
    {
        // GET: Albums
        public ActionResult Index()
        {
            var albums = DAL.AlbumRepository.GetAllAlbums();
            return View(albums);
        }

        // GET: Albums/Details/5
        public ActionResult Details(int id)
        {
            var album = DAL.AlbumRepository.GetById(id);
            var songs = DAL.AlbumRepository.GetSongsFromAlbum(id);

            album.Songs = songs;
            return View(album);
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Albums/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var name = collection["Name"];
                var releaseDate = DateTime.Parse(collection["ReleaseDate"]);
                var album = new Album(0, name, releaseDate);

                DAL.AlbumRepository.Create(album);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Albums/Edit/5
        public ActionResult Edit(int id)
        {
            var current = DAL.AlbumRepository.GetById(id);
            return View(current);
        }

        // POST: Albums/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var current = DAL.AlbumRepository.GetById(id);
                var name = collection["Name"];
                var releaseDate = DateTime.Parse(collection["ReleaseDate"]);
                current.Name = name;
                current.ReleaseDate = releaseDate;

                DAL.AlbumRepository.Update(current);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Albums/Delete/5
        public ActionResult Delete(int id)
        {
            var current = DAL.AlbumRepository.GetById(id);
            return View(current);
        }

        // POST: Albums/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                DAL.AlbumRepository.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class AlbumRepository
    {
        public static List<Common.Album> GetAllAlbums()
        {
            using (var entities = new AlbumsCatalogueEntities())
            {
               return entities.Albums
                    .ToList()
                    .Select(x=> x.ToCommon())
                    .ToList();
            }
        }

        public static Common.Album GetById(int id)
        {
            using(var entities = new AlbumsCatalogueEntities())
            {
                return entities.Albums
                    .Find(id)
                    //.FirstOrDefault(x => x.Id == id)
                    .ToCommon();
            }
        }

        public static List<Common.Album> GetByIds(List<int> ids)
        {
            using (var entities = new AlbumsCatalogueEntities())
            {
                var query = entities.Albums.Where(x => ids.Contains(x.Id));
                var dbResult = query.ToList();
                var enumerableOfCommon = dbResult.Select(x => x.ToCommon());
                var listResult = enumerableOfCommon.ToList();
                return listResult;
            }
        }

        public static void Delete(int id)
        {
            using (var entities = new AlbumsCatalogueEntities())
            {
                var entity = entities.Albums.FirstOrDefault(x => x.Id == id);
                if (entity != null)
                {
                    entities.Albums.Remove(entity);
                }

                entities.SaveChanges();
            }
        }

        public static Common.Album Create(Common.Album album)
        {
            using (var entities = new AlbumsCatalogueEntities())
            {
                var dbAlbum = album.ToDb();
                var inserted = entities.Albums.Add(dbAlbum);
                entities.SaveChanges();

                return inserted.ToCommon();
            }
        }

        public static Common.Album Update(Common.Album album)
        {
            using (var entities = new AlbumsCatalogueEntities())
            {
                var existing = entities.Albums.FirstOrDefault(x => x.Id == album.Id);
                existing.Name = album.Name;
                existing.ReleaseDate = album.ReleaseDate;

                entities.SaveChanges();
                return existing.ToCommon();
            }
        }

        public static List<Common.Song> GetSongsFromAlbum(int albumId)
        {
            using (var entities = new AlbumsCatalogueEntities())
            {
                return entities.Songs.Where(x => x.AlbumId == albumId).ToList().Select(x => x.ToCommon()).ToList();
                
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class SongRepository
    {
        public static Common.Song GetById(int id)
        {
            using (var entities = new AlbumsCatalogueEntities())
            {
               return entities
                    .Songs
                    .FirstOrDefault(x => x.Id == id)
                    .ToCommon();
            }
        }

        public static List<Common.Song> GetByIds(List<int> ids)
        {
            using (var entities = new AlbumsCatalogueEntities())
            {
                return entities.Songs.Where(x => ids.Contains(x.Id)).ToList().Select(x => x.ToCommon()).ToList();
            }
        }

        public static List<Common.Song> GetAll()
        {
            using (var entities = new AlbumsCatalogueEntities())
            {
                return entities.Songs.ToList().Select(x=> x.ToCommon()).ToList();
            }
        }

        public static Common.Song Create(Common.Song song)
        {
            using (var entities = new AlbumsCatalogueEntities())
            {
                var songToDb = song.SongToDb();
                var newSong = entities.Songs.Add(songToDb);
                var songToCommon = newSong.ToCommon();
                entities.SaveChanges();
                return songToCommon;
            }
        }

        public static Common.Song Update(Common.Song song)
        {
            using (var entities = new AlbumsCatalogueEntities())
            {
                var existing = entities.Songs.FirstOrDefault(x => x.Id == song.Id);
                if (existing == null) return null;

                existing.Name = song.Name;
                existing.Genre = (int)song.Genre;
                existing.Artist = song.Artist;

                entities.SaveChanges();
                return existing.ToCommon();
            }
        }

        public static void Delete(int id)
        {
            using (var entities = new AlbumsCatalogueEntities())
            {
                var entity = entities.Songs.FirstOrDefault(x => x.Id == id);
                if (entity != null)
                {
                    entities.Songs.Remove(entity);
                }

                entities.SaveChanges(); 
            }
        }

        
    }
}

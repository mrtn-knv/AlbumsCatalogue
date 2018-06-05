using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class SongTransformations
    {
        public static Song SongToDb(this Common.Song song)
        {
            return new Song()
            {
                Id = song.Id,
                Artist = song.Artist,
                Name = song.Name,
                Genre = (int)song.Genre,
                AlbumId = song.AlbumId
            };

        }

        public static Common.Song ToCommon(this Song song)
        {
            return new Common.Song(song.Id, song.Name, song.Artist, (Common.Genre)song.Genre)
            {
                AlbumId = song.AlbumId
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class AlbumTransformation
    {
        public static Common.Album ToCommon(this Album album)
        {
            return new Common.Album(album.Id, album.Name, album.ReleaseDate);
            
        }

        public static Album ToDb(this Common.Album album)
        {
            return new Album()
            {
                Id = album.Id,
                Name = album.Name,
                ReleaseDate = album.ReleaseDate
            };

        }
    }
}

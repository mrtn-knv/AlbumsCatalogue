using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public Genre Genre { get; set; }
        public int? AlbumId { get; set; }

        public Song()
        {

        }

        public Song(int id, string name, string artist, Genre genre)
        {
            if (string.IsNullOrWhiteSpace(name)) { throw new ArgumentNullException(nameof(name)); }
            if (string.IsNullOrWhiteSpace(artist)) { throw new ArgumentNullException(nameof(artist)); }

            Id = id;
            Name = name;
            Artist = artist;
            Genre = genre;
        }
    }
}

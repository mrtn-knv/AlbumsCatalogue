using System;
using System.Collections.Generic;

namespace Common
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set;}
        public DateTime ReleaseDate { get; set; }
        public List<Song> Songs { get; set; }

        public Album()
        {

        }

        public Album(int id, string name, DateTime releaseDate)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

            Id = id;
            Name = name;
            ReleaseDate = releaseDate;
        }
    }
}

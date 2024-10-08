﻿namespace Tunify_Platform.Models
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }

        public int AlbumId { get; set; }
        public Album Album { get; set; }

        public TimeSpan Duration { get; set; }
        public string Genre { get; set; }

        public ICollection<PlaylistSongs> playlistSongs { get; set; }

    }
}

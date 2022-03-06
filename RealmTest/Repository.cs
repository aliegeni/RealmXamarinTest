using Newtonsoft.Json;
using System.Collections.Generic;

namespace RealmTest
{
    public class Repository
    {
        public List<Artist> GetData()
        {
            var artists = new List<Artist>
            {
                new Artist { Id = 1, Name = "David Bowie" },
                new Artist { Id = 2, Name = "The Cure" },
                new Artist { Id = 3, Name = "Tears For Fears" },
            };

            var albums = new List<Album>
            {
                new Album { Title = "First album" },
                new Album { Title = "Second album" },
                new Album { Title = "Best album" },
            };

            var tracks = new List<Tarck>
            {
                new Tarck { Title = "Track 1" },
                new Tarck { Title = "Track 2" },
                new Tarck { Title = "Track 3" },
            };

            albums.ForEach(album => tracks.ForEach(track => album.Tracks.Add(track)));
            artists.ForEach(artist => albums.ForEach(album => artist.Albums.Add(album)));

            return JsonConvert.DeserializeObject<List<Artist>>(JsonConvert.SerializeObject(artists));
        }
    }
}
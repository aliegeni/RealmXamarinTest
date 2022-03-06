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

        /// <summary>
        /// Data mockup from REST API
        /// </summary>
        /// <returns></returns>
        public List<Artist> RequestData()
        {
            var jsonData = "[{\"Id\":1,\"Name\":\"David Bowie\",\"Albums\":[{\"Title\":\"First album\",\"Tracks\":[{\"Title\":\"Track 1\",\"Parent\":null},{\"Title\":\"Track 2\",\"Parent\":null},{\"Title\":\"Track 3\",\"Parent\":null}],\"Parent\":null},{\"Title\":\"Best album\",\"Tracks\":[{\"Title\":\"Track 1\",\"Parent\":null},{\"Title\":\"Track 2\",\"Parent\":null},{\"Title\":\"Track 3\",\"Parent\":null}],\"Parent\":null}]},{\"Id\":2,\"Name\":\"The Cure\",\"Albums\":[{\"Title\":\"First album\",\"Tracks\":[{\"Title\":\"Track 1\",\"Parent\":null},{\"Title\":\"Track 2\",\"Parent\":null},{\"Title\":\"Track 3\",\"Parent\":null}],\"Parent\":null},{\"Title\":\"Best album\",\"Tracks\":[{\"Title\":\"Track 1\",\"Parent\":null},{\"Title\":\"Track 2\",\"Parent\":null},{\"Title\":\"Track 3\",\"Parent\":null}],\"Parent\":null}]},{\"Id\":3,\"Name\":\"Tears For Fears\",\"Albums\":[{\"Title\":\"First album\",\"Tracks\":[{\"Title\":\"Track 1\",\"Parent\":null},{\"Title\":\"Track 2\",\"Parent\":null},{\"Title\":\"Track 3\",\"Parent\":null}],\"Parent\":null},{\"Title\":\"Best album\",\"Tracks\":[{\"Title\":\"Track 1\",\"Parent\":null},{\"Title\":\"Track 2\",\"Parent\":null},{\"Title\":\"Track 3\",\"Parent\":null}],\"Parent\":null}]}]";
            var result = JsonConvert.DeserializeObject<List<Artist>>(jsonData);
            return result;
        }
    }
}
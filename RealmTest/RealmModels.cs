using Realms;
using System.Collections.Generic;

namespace RealmTest
{
    public class Artist : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Album> Albums { get; }
    }

    public class Album : EmbeddedObject
    {
        public string Title { get; set; }
        public IList<Tarck> Tracks { get; }
    }

    public class Tarck : EmbeddedObject
    {
        public string Title { get; set; }
    }
}

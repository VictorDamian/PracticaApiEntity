using System.ComponentModel.DataAnnotations;

namespace victorDamian.Models
{
    public class Song
    {
        [Key]
        public int Ismn { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public int AlbumYear { get; set; }
        public double duration { get; set; }
        public string Url { get; set; }
    }
}

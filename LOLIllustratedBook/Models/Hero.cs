namespace LOLIllustratedBook.Models
{
    public class Hero
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Blurb { get; set; }
        public List<string> Tags { get; set; }
        public HeroInfo Info { get; set; }
        public ImageInfo Image { get; set; }
        public string ImageUrl { get; set; }
        public string SpriteUrl { get; set; }
        public string Group { get; set; }
        public List<string> AdditionalImageUrls { get; set; }
    }

    public class HeroInfo
    {
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Magic { get; set; }
        public int Difficulty { get; set; }
    }

    public class ImageInfo
    {
        public string Full { get; set; }
        public string Sprite { get; set; }
    }

    public class HeroResponse
    {
        public Dictionary<string, Hero> Data { get; set; }
    }
}

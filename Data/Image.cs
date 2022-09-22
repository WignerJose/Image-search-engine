namespace ImageFinder.Data
{
    public class Image
    {
        public string Id { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int MyProperty { get; set; }
        public Urls Urls  { get; set; }
    }

    public class Urls
    {
        public string Regular { get; set; } = string.Empty ;
    }

    public class ImageSearch
    {
        public List<Image> Results { get; set; }
    }
}

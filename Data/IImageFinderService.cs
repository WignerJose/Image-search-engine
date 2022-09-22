namespace ImageFinder.Data
{
    public interface IImageFinderService
    {
        Task<List<Image>> GetListPhotosAsync();
        Task<ImageSearch> SearchPhotosAsync(string textSearch);
    }
}

using ImageFinder.Data.ConfigService;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace ImageFinder.Data
{
    public class ImageFinderService : IImageFinderService
    {
        private HttpClient _httpClient;

        public ImageFinderService(HttpClient client,IOptions<ConfigurationService> configService)
        {
            client.BaseAddress = new Uri(configService.Value.Url);
            client.DefaultRequestHeaders.Add("Authorization", configService.Value.ClientId);
            _httpClient = client;
        }

        public async Task<List<Image>> GetListPhotosAsync()
        {
            var response = await _httpClient.GetAsync("/photos?page=1&per_page=20");
            var responseString =  await response.Content.ReadAsStringAsync();
            var result= JsonConvert.SerializeObject(responseString);
            var successContent = JsonConvert.DeserializeObject<List<Image>>(responseString);
            return successContent!;
        }

        public async Task<ImageSearch> SearchPhotosAsync(string textSearch)
        {
            var response = await _httpClient.GetAsync($"/search/photos?page=1&per_page=20&query={textSearch}");
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.SerializeObject(responseString);
            var successContent = JsonConvert.DeserializeObject<ImageSearch>(responseString);
            return successContent!;
        }
    }
}

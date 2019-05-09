using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;

namespace HackerNews.Api
{
    public class HackerNewsApi
    {
        private IEnumerable<int> GetTopIds()
        {
            using (var client = new HttpClient())
            {
                var json = client.GetStringAsync("https://hacker-news.firebaseio.com/v0/topstories.json?print=pretty")
                    .Result;
                return JsonConvert.DeserializeObject<IEnumerable<int>>(json);
            }
        }

        public IEnumerable<Story> GetTopStories()
        {
            var ids = GetTopIds().Take(20);
            return ids.Select(i =>
            {
                using (var client = new HttpClient())
                {
                    var json = client
                        .GetStringAsync($"https://hacker-news.firebaseio.com/v0/item/{i}.json?print=pretty").Result;
                    return JsonConvert.DeserializeObject<Story>(json);
                }
            });
        }
    }
}
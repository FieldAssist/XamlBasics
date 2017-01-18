using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XamlBasicsV3.Models;

namespace XamlBasicsV3.Helper
{
    public class RESTHelper<T>
    {
        private HttpClient client;

        public RESTHelper(string url)
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(url);
        }
        public async Task<T> getResponse()
        {
            try
            {
                var response = await client.GetAsync(client.BaseAddress);
                response.EnsureSuccessStatusCode();
                var JsonResult = response.Content.ReadAsStringAsync().Result;
                var resultClass = JsonConvert.DeserializeObject<T>(JsonResult);
                return resultClass;
            }
            catch (Exception)
            {
                return default(T);
            }

        }
    }
}

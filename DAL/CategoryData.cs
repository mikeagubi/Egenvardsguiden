using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Test3.DAL
{
    public class CategoryData
    {
        public static async Task<List<Models.Category>> GetCategories()
        {
            List<Models.Category> categories = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://vardguidenapi.azurewebsites.net/"); 

                HttpResponseMessage response = await client.GetAsync("api/category"); 
                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    categories = JsonSerializer.Deserialize<List<Models.Category>>(responseString);
                }
            }

            return categories;
        }
    }
}

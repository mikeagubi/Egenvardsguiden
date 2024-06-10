
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Test3.DAL
{
    public class CategoryManagerAPI
    {
        private static Uri BaseAddress = new Uri("https://vardguidenapi.azurewebsites.net/"); 

        public static async Task<List<Models.Category>> GetAllCategories()
        {
            List<Models.Category> categories = new List<Models.Category>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseAddress;

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

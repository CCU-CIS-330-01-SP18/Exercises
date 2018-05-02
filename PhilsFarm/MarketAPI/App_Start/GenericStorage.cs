using ProductList.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProductList
{
    public class GenericStorage
    {
        private string FilePath;

        public GenericStorage()
        {
            var webAppsHome = Environment.GetEnvironmentVariable("HOME")?.ToString();
            if (String.IsNullOrEmpty(webAppsHome))
            {
                FilePath = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath) + "\\";
            }
            else
            {
                FilePath = webAppsHome + "\\site\\wwwroot\\";
            }
        }

        public async Task Save(IEnumerable<Product> target, string filename)
        {
            var json = JsonConvert.SerializeObject(target);
            File.WriteAllText(FilePath + filename, json);
        }

        public async Task<T> Get<T>(string filename)
        {
            var productsText = String.Empty;
            if (File.Exists(FilePath + filename))
            {
                productsText = File.ReadAllText(FilePath + filename);
            }

            var products = JsonConvert.DeserializeObject<T>(productsText);
            return products;
        }

        public async Task Delete(string filename)
        {
            File.Delete(FilePath + filename);
        }
    }
}

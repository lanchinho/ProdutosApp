using Newtonsoft.Json;
using ProdutosApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Services
{
    /// <summary>
    /// CLasse de serviço de integração para Produto
    /// </summary>
    public class ProductService : IProductsService
    {
        private static readonly string API_URL = "http://apiprodutosmaui-001-site1.etempurl.com/api/produtos";
        public async Task<ObservableCollection<ProductModel>> GetProducts()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(API_URL);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<ObservableCollection<ProductModel>>(content);
                }

                return null;
            }
        }
    }
}

using ProdutosApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Models
{
    /// <summary>
    /// Classe para fornecer os dados dos produtos para um componente (ContentPage)
    /// </summary>
    public class ProductViewModel
    {
        public ObservableCollection<ProductModel> Products { get; set; } = new ObservableCollection<ProductModel>();

        private readonly IProductsService _productsService = new ProductService();

        public ProductViewModel() => LoadProducts();

        public async void LoadProducts()
        {
            var products = await _productsService.GetProducts();
            foreach (var product in products)
            {
                Products.Add(product);
            }
        }

    }
}

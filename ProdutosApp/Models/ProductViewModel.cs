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

        public static async Task<ProductViewModel> InicializaProdutosAsync()
        {
            var productViewModel = new ProductViewModel();
            
            await productViewModel.LoadProducts();

            return productViewModel;
        }

        private ProductViewModel() { }

        public async Task LoadProducts()
        {
            var products = await _productsService.GetProducts();
            foreach (var product in products)
            {
                Products.Add(product);
            }
        }

    }
}

using ProdutosApp.Models;
using ProdutosApp.Services;
using System.Collections.ObjectModel;

namespace ProdutosApp.ViewModels
{
    /// <summary>
    /// Classe para fornecer os dados dos produtos para um componente (ContentPage)
    /// </summary>
    public class ProductsListViewModel
    {
        public ObservableCollection<ProductModel> Products { get; set; } = new ObservableCollection<ProductModel>();
        private readonly IProductsService _productsService = new ProductService();

        public static async Task<ProductsListViewModel> InicializaProdutosAsync()
        {
            var productViewModel = new ProductsListViewModel();
            
            await productViewModel.LoadProducts();

            return productViewModel;
        }

        private ProductsListViewModel() { }

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

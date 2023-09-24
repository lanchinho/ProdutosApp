using ProdutosApp.Models;
using System.Collections.ObjectModel;

namespace ProdutosApp.Services
{
    /// <summary>
    /// Interface para serviço de produtos
    /// </summary>
    public interface IProductsService
    {
        /// <summary>
        /// Método para consulta de produtos
        /// </summary>
        /// <returns>Coleção de Produtos</returns>
        Task<ObservableCollection<ProductModel>> GetProducts();
    }
}

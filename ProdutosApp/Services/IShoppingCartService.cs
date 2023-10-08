using ProdutosApp.Models;

namespace ProdutosApp.Services
{
    /// <summary>
    /// Interface para serviços do carrinho de comprass
    /// </summary>
    public interface IShoppingCartService
    {
        /// <summary>
        /// Adicionar um item no carrinho
        /// </summary>        
        Task AddItem(ShoppingCartItemModel model);

        /// <summary>
        /// Remove um item do carrinho de compras
        /// </summary>        
        Task RemoveItem(Guid id);

        /// <summary>
        /// Retornando todos os dados do carrinho de compras
        /// </summary>        
        Task<ShoppingCartModel> GetShoppingCart();

        /// <summary>
        /// Remove todos os itens do carrinho
        /// </summary>        
        void RemoveAll();
    }
}

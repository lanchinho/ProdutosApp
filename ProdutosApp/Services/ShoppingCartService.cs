using Newtonsoft.Json;
using ProdutosApp.Models;

namespace ProdutosApp.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private const string _key = "shopping-cart";

        public async Task AddItem(ShoppingCartItemModel model)
        {
            ShoppingCartModel shoppingCart = null;

            //verificar se já existe um carrinho de compras criado
            var data = await SecureStorage.Default.GetAsync(_key);

            if (string.IsNullOrEmpty(data))
            {
                //criando um carrinho de compras na local storage
                shoppingCart = new ShoppingCartModel
                {
                    Itens = new List<ShoppingCartItemModel>()
                };
            }
            else
                //capturando os dados do carrinho de compras já existente
                shoppingCart = JsonConvert.DeserializeObject<ShoppingCartModel>(data);

            //buscando 1 item no carrinho de compras com o mesmo id do item adicionado
            var itemObtido = shoppingCart.Itens.FirstOrDefault(i => i.Product.Id == model.Product.Id);

            //verificando se o item já foi adicionado no carrinho de compras
            if (itemObtido != null)
                //incrementar a quantidade do item
                itemObtido.Quantity++;
            else
                //adicionar o item no carrinho de compras
                shoppingCart.Itens.Add(model);

            //gravando os dados na local storage
            await SecureStorage.Default.SetAsync(_key, JsonConvert.SerializeObject(shoppingCart));
        }

        public async Task RemoveItem(Guid id)
        {
            //ler o conteúdo do carrinho de compras
            var shoppingCart = JsonConvert.DeserializeObject<ShoppingCartModel>(await SecureStorage.Default.GetAsync(_key));

            //removendo o item do carrinho
            shoppingCart.Itens.RemoveAll(i => i.Product.Id == id);

            if (shoppingCart.Quantity == 0)
                SecureStorage.Default.Remove(_key);
            else
                //gravando os dados na local storage
                await SecureStorage.Default.SetAsync(_key, JsonConvert.SerializeObject(shoppingCart));
        }

        public async Task<ShoppingCartModel> GetShoppingCart()
        {
            var data = await SecureStorage.Default.GetAsync(_key);
            if (data != null)
                return JsonConvert.DeserializeObject<ShoppingCartModel>(data);

            return null;
        }
    }
}

using ProdutosApp.Models;
using ProdutosApp.Services;
using System.ComponentModel;

namespace ProdutosApp.ViewModels
{
    public class ShoppingCartViewModel : INotifyPropertyChanged
    {
        private ShoppingCartModel _shoppingCart;
        public ShoppingCartModel ShoppingCart
        {
            get => _shoppingCart;
            set
            {
                _shoppingCart = value;
                OnPropertyChanged(nameof(ShoppingCart));
            }
        }

        private readonly ShoppingCartService _shoppingCartService = new ShoppingCartService();
        
        public ShoppingCartViewModel() => LoadShoppingCart();
        
        public async void LoadShoppingCart()
        {
            ShoppingCart = await _shoppingCartService.GetShoppingCart();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}

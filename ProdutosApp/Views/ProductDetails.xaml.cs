using ProdutosApp.Models;
using ProdutosApp.Services;
using System.ComponentModel;

namespace ProdutosApp.Views;

[QueryProperty("product", "product")]
public partial class ProductDetails : ContentPage, IQueryAttributable, INotifyPropertyChanged
{
    public ProductModel ProductModel { get; private set; }

    public ProductDetails()
    {
        InitializeComponent();
        BindingContext = this;
    }

    //fazendo o resgate dos parametros enviados
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        ProductModel = query["product"] as ProductModel;
        OnPropertyChanged(nameof(ProductModel));
    }

    //evento executado no "tapped" para o btn voltar
    private async void BtnVoltar_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new ProductsList());
    }

    //evento executdo para adicionar um produto no carrinho de compras
    private async void BtnComprar_Tapped(object sender, TappedEventArgs e)
    {
        IShoppingCartService shoppingCartService = new ShoppingCartService();

        var item = new ShoppingCartItemModel
        {
            Product = ProductModel
        };

        await shoppingCartService.AddItem(item);        
        await Navigation.PushAsync(new ShoppingCart());
    }
}

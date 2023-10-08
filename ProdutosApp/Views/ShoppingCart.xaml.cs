using ProdutosApp.Services;
using ProdutosApp.ViewModels;

namespace ProdutosApp.Views;

public partial class ShoppingCart : ContentPage
{
    public ShoppingCart()
    {
        /*
		 * Executando o carragamento dos itens do carrinho de compras
		 */

        InitializeComponent();
        BindingContext = new ShoppingCartViewModel();       
    }

    private async void BtnRemoveCart_Tapped(object sender, TappedEventArgs e)
    {
        if (await DisplayAlert("Limpar carrinho de compras",
            "Deseja realmente apagar todos os itens do seu carrinho de compras?",
            "Sim", "Não"))
        {

            var shoppingCartService = new ShoppingCartService();
            shoppingCartService.RemoveAll();

            //recarrega tela
            BindingContext = new ShoppingCartViewModel();
        }
    }

    private async void BtnBackToHome_Tapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new ProductsList());
    }
}
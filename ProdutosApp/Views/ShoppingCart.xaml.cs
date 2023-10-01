using ProdutosApp.ViewModels;

namespace ProdutosApp.Views;

public partial class ShoppingCart : ContentPage
{
	public ShoppingCart()
	{
		InitializeComponent();

		/*
		 * Executando o carragamento dos itens do carrinho de compras
		 */

		BindingContext = new ShoppingCartViewModel();		
	}
	//TODO: fazer igual na product list
}
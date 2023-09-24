using ProdutosApp.Models;

namespace ProdutosApp.Views;

public partial class ProductsList : ContentPage
{
    public ProductsList()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();       

        /*
         * Executando a consulta de produtos,
         * através da classe View Model		 
         */

        BindingContext = await ProductViewModel.InicializaProdutosAsync();
    }

    /// <summary>
    /// Evento executado ao selecionar um item
    /// </summary>	
    async void OnProductSelection(Object sender, SelectionChangedEventArgs e)
    {
        //Verificando se algum item foi selecionado
        if (e.CurrentSelection.Any())
        {
            //capturando o item selecionado
            var product = e.CurrentSelection.FirstOrDefault() as ProductModel;

            //enviar os dados do produto para a página de detalhes
            var navigationParams = new Dictionary<string, object>
            {
                {nameof(product) ,product }
            };

            //fazendo a navegação
            await Shell.Current.GoToAsync("//ProductDetails", navigationParams);

            //desmarcar o item selecionado
            productsList.SelectedItem = null;
        }
    }
}
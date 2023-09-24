using ProdutosApp.Models;
using System.ComponentModel;

namespace ProdutosApp.Views;

[QueryProperty("product", "product")]
public partial class ProductDetails : ContentPage, IQueryAttributable, INotifyPropertyChanged
{
    public ProductDetails()
    {
        InitializeComponent();
        BindingContext = this;
    }

    //fazendo o resgate dos parametros enviados
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        var product = query["product"] as ProductModel;
        Console.WriteLine(product);
    }
}

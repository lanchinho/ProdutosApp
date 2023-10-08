using System.Globalization;

namespace ProdutosApp.Models
{
    public class ShoppingCartModel
    {
        public List<ShoppingCartItemModel> Itens { get; set; }
        public int Quantity
        {
            get
            {
                if (Itens != null && Itens.Any())
                    return Itens.Sum(x => x.Quantity);

                return 0;
            }
        }

        public decimal Total
        {
            get
            {
                if (Itens != null && Itens.Any())
                    return Itens.Sum(x => x.Total);

                return 0m;
            }
        }

        public string CurrencyTotal => Total.ToString("c", CultureInfo.GetCultureInfo("pt-BR"));

        public bool IsVisible => Quantity > 0;
    }
}

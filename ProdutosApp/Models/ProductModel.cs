using System.Globalization;

namespace ProdutosApp.Models
{
    /// <summary>
    /// Modelo de dados para consulta de produtos.
    /// </summary>
    public class ProductModel
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string PhotoUrl { get; set; }
        public string Category { get; set; }
        public string CurrencyPrice => Price.ToString("c", CultureInfo.GetCultureInfo("pt-BR"));
    }
}

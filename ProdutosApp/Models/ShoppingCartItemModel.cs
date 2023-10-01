namespace ProdutosApp.Models
{
    public class ShoppingCartItemModel
    {
        public ProductModel Product { get; set; }
        public int Quantity { get; set; }

        public decimal Total
        {
            get
            {
                if (Product is not null)
                    return Quantity * Product.Price;

                    return 0m;
            }
        }
    }
}

namespace CatalogDomain
{
    public class ProductStock
    {
        public  int ProductStockId { get; set; }
        public int ProductId { get; set; }
        public int Stock { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}

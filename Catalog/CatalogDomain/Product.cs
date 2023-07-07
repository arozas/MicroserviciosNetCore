﻿namespace CatalogDomain
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ProductStock Stock { get; set; }
        public DateTime RegistryDate { get; set; }
        public bool Active { get; set; }
    }
}
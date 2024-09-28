using Microsoft.Extensions.Caching.Memory;
using ProductsManager.Models;

namespace ProductsManager.Services
{
    public class ProductService : IProductService
    {
        private readonly IMemoryCache _cache;
        public ProductService(IMemoryCache cache)
        {
            _cache = cache;
        }
        public async Task<Product> GetProduct(int id)
        {
            string cacheKey = $"product_{id}";
            if (!_cache.TryGetValue(cacheKey, out Product product))
            {
                product = await GetProductFromDatabase(id);

                var cacheOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                };

                _cache.Set(cacheKey, product, cacheOptions);
            }

            return product;
        }

        private async Task<Product> GetProductFromDatabase(int id)
        {
            var product= new Product { Id = id, Name = "Salt" };
            return await Task.FromResult(product);
        }
    }
}

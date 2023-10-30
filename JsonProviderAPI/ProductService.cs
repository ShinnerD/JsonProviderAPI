namespace JsonProviderAPI
{
  public class ProductService
  {
    public async Task<List<Product>?> GetAllProducts()
    {
      using var client = new HttpClient();
      const string url = "https://dummyjson.com/products";
      var response = await client.GetAsync(url);

      if (!response.IsSuccessStatusCode) return null;

      var content = await response.Content.ReadFromJsonAsync<ProductResponse>();

      return content?.Products;
    }

    public async Task<Product?> GetProduct(int id)
    {
      using var client = new HttpClient();
      const string url = "https://dummyjson.com/products/";
      var response = await client.GetAsync(url + id);

      if (!response.IsSuccessStatusCode) return null;

      var content = await response.Content.ReadFromJsonAsync<Product>();

      return content;
    }
  }
}

public class Product
{
  public int Id { get; set; }
  public string? Title { get; set; }
  public string? Description { get; set; }
  public double Price { get; set; }
  public double DiscountPercentage { get; set; }
  public double Rating { get; set; }
  public int Stock { get; set; }
  public string? Category { get; set; }
  public string? Thumbnail { get; set; }
  public string? Brand { get; set; }
  public List<string>? Images { get; set; }
}

public class ProductResponse
{
  public int Total { get; set; }
  public int Skip { get; set; }
  public int Limit { get; set; }
  public List<Product>? Products { get; set; }
}

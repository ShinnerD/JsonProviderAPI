namespace JsonProviderAPI
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);

      builder.Services.AddAuthorization();
      builder.Services.AddScoped<ProductService>();
      builder.Services.AddScoped<TodoService>();

      builder.Services.AddEndpointsApiExplorer();
      builder.Services.AddSwaggerGen();

      var app = builder.Build();

      app.UseSwagger();
      app.UseSwaggerUI();

      app.UseHttpsRedirection();

      app.UseAuthorization();

      app.MapGet("/Products", GetProducts)
      .WithOpenApi();

      app.MapGet("/Products/{id:int}", GetProduct)
        .WithOpenApi();

      app.MapGet("/Todos", GetTodos)
        .WithOpenApi();

      app.MapGet("/Todos/{id:int}", GetTodo)
        .WithOpenApi();

      app.Run();
    }

    static async Task<object> GetProducts(IServiceProvider services)
    {
      var productService = services.GetService<ProductService>();

      if (productService is null)
      {
        return "Could not get product service.";
      }

      var result = await productService?.GetAllProducts();

      if (result is null)
      {
        return "No Products Found";
      }

      return result;
    }

    static async Task<object> GetProduct(IServiceProvider services, int id)
    {
      var productService = services.GetService<ProductService>();

      if (productService is null)
      {
        return "Could not get product service.";
      }

      var result = await productService?.GetProduct(id);

      if (result is null)
      {
        return "No Product Found";
      }

      return result;
    }

    static async Task<object> GetTodos(IServiceProvider services)
    {
      var todoService = services.GetService<TodoService>();

      if (todoService is null)
      {
        return "Could not get Todo service.";
      }

      var result = await todoService.GetAllTodos();

      if (result is null)
      {
        return "No Todos Found";
      }

      return result;
    }

    static async Task<object> GetTodo(IServiceProvider services, int id)
    {
      var todoService = services.GetService<TodoService>();

      if (todoService is null)
      {
        return "Could not get Todo service.";
      }

      var result = await todoService.GetTodo(id);

      if (result is null)
      {
        return "No Todo Found";
      }

      return result;
    }
  }
}
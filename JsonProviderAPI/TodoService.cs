namespace JsonProviderAPI
{
  public class TodoService
  {
    public async Task<List<Todo>?> GetAllTodos()
    {
      using var client = new HttpClient();
      const string url = "https://jsonplaceholder.typicode.com/todos";
      var response = await client.GetAsync(url);

      if (!response.IsSuccessStatusCode) return null;

      var content = await response.Content.ReadFromJsonAsync<List<Todo>>();

      return content;
    }

    public async Task<Todo?> GetTodo(int id)
    {
      using var client = new HttpClient();
      const string url = "https://jsonplaceholder.typicode.com/todos/";
      var response = await client.GetAsync(url + id);

      if (!response.IsSuccessStatusCode) return null;

      var content = await response.Content.ReadFromJsonAsync<Todo>();

      return content;
    }
  }

  public class Todo
  {
    public int UserId { get; set; }
    public int Id { get; set; }
    public string? Title { get; set; }
    public bool Completed { get; set; }
  }
}

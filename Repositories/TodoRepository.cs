using FirstProject.Models;

namespace FirstProject.Repositories;

public class TodoRepository : ITodoRepository
{
    private readonly List<Todo> _todos = new();
    private int _nextId = 1;

    public Task<IEnumerable<Todo>> GetAllAsync()
        => Task.FromResult<IEnumerable<Todo>>(_todos);

    public Task<Todo?> GetByIdAsync(int id)
        => Task.FromResult(_todos.FirstOrDefault(t => t.Id == id));

    public Task<Todo> CreateAsync(Todo todo)
    {
        todo.Id = _nextId++;
        todo.DataCriacao = DateTime.UtcNow;
        _todos.Add(todo);
        return Task.FromResult(todo);
    }

    public Task<Todo?> UpdateAsync(int id, Todo updated)
    {
        var todo = _todos.FirstOrDefault(t => t.Id == id);
        if (todo is null)
            return Task.FromResult<Todo?>(null);

        todo.Titulo = updated.Titulo;
        todo.Descricao = updated.Descricao;
        todo.Concluido = updated.Concluido;
        return Task.FromResult<Todo?>(todo);
    }

    public Task<bool> DeleteAsync(int id)
    {
        var todo = _todos.FirstOrDefault(t => t.Id == id);
        if (todo is null)
            return Task.FromResult(false);

        _todos.Remove(todo);
        return Task.FromResult(true);
    }
}

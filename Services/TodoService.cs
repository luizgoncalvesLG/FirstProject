using FirstProject.Models;
using FirstProject.Repositories;

namespace FirstProject.Services;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _repository;

    public TodoService(ITodoRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Todo>> GetAllAsync() => _repository.GetAllAsync();

    public Task<Todo?> GetByIdAsync(int id) => _repository.GetByIdAsync(id);

    public Task<Todo> CreateAsync(Todo todo) => _repository.CreateAsync(todo);

    public Task<Todo?> UpdateAsync(int id, Todo todo) => _repository.UpdateAsync(id, todo);

    public Task<bool> DeleteAsync(int id) => _repository.DeleteAsync(id);
}

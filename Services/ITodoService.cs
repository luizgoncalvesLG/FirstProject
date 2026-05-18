using FirstProject.Models;

namespace FirstProject.Services;

public interface ITodoService
{
    Task<IEnumerable<Todo>> GetAllAsync();
    Task<Todo?> GetByIdAsync(int id);
    Task<Todo> CreateAsync(Todo todo);
    Task<Todo?> UpdateAsync(int id, Todo todo);
    Task<bool> DeleteAsync(int id);
}

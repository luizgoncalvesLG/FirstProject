using Microsoft.AspNetCore.Mvc;
using FirstProject.Models;
using FirstProject.Services;

namespace FirstProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodosController : ControllerBase
{
    private readonly ITodoService _service;

    public TodosController(ITodoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Todo>>> GetAll()
        => Ok(await _service.GetAllAsync());

    [HttpGet("{id}")]
    public async Task<ActionResult<Todo>> GetById(int id)
    {
        var todo = await _service.GetByIdAsync(id);
        return todo is null ? NotFound() : Ok(todo);
    }

    [HttpPost]
    public async Task<ActionResult<Todo>> Create(Todo todo)
    {
        var created = await _service.CreateAsync(todo);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Todo>> Update(int id, Todo todo)
    {
        var updated = await _service.UpdateAsync(id, todo);
        return updated is null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }
}

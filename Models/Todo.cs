namespace FirstProject.Models;

public class Todo
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public bool Concluido { get; set; }
    public DateTime DataCriacao { get; set; }
}

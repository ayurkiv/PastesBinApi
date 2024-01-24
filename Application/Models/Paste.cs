
namespace Application.Models;

public class Paste
{
    public Guid Id { get; set; }
    public string Title { get; set; } = "";
    public string Content { get; set; } = "";
    public int Views { get; set; }
}
using Application.Models;
using MediatR;

namespace Application.Commands;

public class UpdatePaste : IRequest<Paste>
{
    public Guid Id { get; set; }
    public string Content { get; set; } = "";
    public string Title { get; set; } = "";
}
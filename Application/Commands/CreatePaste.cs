using Application.Models;
using MediatR;

namespace Application.Commands;

public class CreatePaste : IRequest<Paste>
{
    public string Title { get; set; } = "";
    public string Content { get; set; } = "";
}
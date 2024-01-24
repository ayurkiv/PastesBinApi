using Application.Models;
using MediatR;

namespace Application.Commands;

public class DeletePaste : IRequest<bool>
{
    public Guid Id { get; set; }
}
using Application.Models;
using MediatR;

namespace Application.Commands;

public class DeletePaste : IRequest
{
    public Guid Id { get; set; }
}
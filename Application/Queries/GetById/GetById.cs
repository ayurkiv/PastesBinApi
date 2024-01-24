using Application.Models;
using MediatR;

namespace Application.Queries.GetById;

public class GetById : IRequest<Paste>
{
    public Guid Id {get; set;}
}
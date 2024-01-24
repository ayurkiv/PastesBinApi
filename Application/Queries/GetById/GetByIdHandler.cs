using Application.Abstractions;
using Application.Models;
using MediatR;

namespace Application.Queries.GetById;

public class GetByIdHandler(IPasteRepository repository) : IRequestHandler<GetById, Paste?>
{
    public async Task<Paste?> Handle(GetById request, CancellationToken cancellationToken)
    {
        return await repository.GetByIdAsync(request.Id);
    }
}
using Application.Abstractions;
using Application.Exceptions;
using MediatR;

namespace Application.Commands;

public class DeletePasteHandler(IPasteRepository repository) : IRequestHandler<DeletePaste>
{
    public async Task Handle(DeletePaste request, CancellationToken cancellationToken)
    {
        var deleteStatus = await repository.DeleteAsync(request.Id);
        if (deleteStatus == false)
        {
            throw new NotFoundException("Notfound paste: " + request.Id);
        }
    }

}
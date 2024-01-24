using Application.Abstractions;
using MediatR;

namespace Application.Commands;

public class DeletePasteHandler(IPasteRepository repository) : IRequestHandler<DeletePaste, bool>
{
    public async Task<bool> Handle(DeletePaste request, CancellationToken cancellationToken)
    {
        var deleteStatus = await repository.DeleteAsync(request.Id);
        if (deleteStatus == true)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
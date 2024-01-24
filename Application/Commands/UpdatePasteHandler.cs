using Application.Abstractions;
using Application.Models;
using MediatR;

namespace Application.Commands;

public class UpdatePasteHandler(IPasteRepository repository) : IRequestHandler<UpdatePaste, Paste?>
{
    public async Task<Paste?> Handle(UpdatePaste request, CancellationToken cancellationToken)
    {
        var update = new Paste()
        {
            Id = request.Id,
            Title =request.Title,
            Content = request.Content
        };
        var paste = await repository.UpdateAsync(request.Id, update);
        return paste;
    }
}
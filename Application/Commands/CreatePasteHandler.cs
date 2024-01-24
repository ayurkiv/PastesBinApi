using Application.Abstractions;
using Application.Models;
using MediatR;

namespace Application.Commands;

public class CreatePasteHandler(IPasteRepository repository) : IRequestHandler<CreatePaste, Paste>
{
    
    public async Task<Paste> Handle(CreatePaste request, CancellationToken cancellationToken)
    {
        var paste = new Paste()
        {
            Title = request.Title,
            Content = request.Content
        };
        await repository.AddAsync(paste);
        return paste;
    }
}
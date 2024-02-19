using Frontend.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Frontend.Pages;

public partial class PasteView
{
    [Inject]
    private IPasteServices _pasteServices { set; get; }

    protected override Task OnInitializedAsync()
    {
        var paste = _pasteServices.GetById(new Guid());
        return Task.CompletedTask;
    }
}
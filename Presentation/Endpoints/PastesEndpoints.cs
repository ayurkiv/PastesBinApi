using Application.Commands;
using Application.Models;
using Application.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation.Abstractions;

namespace Presentation.Endpoints;

public class PastesEndpoints : IEndpointsRegistration
{
    public void Register(WebApplication app)
    {
        var mainRoute = app.MapGroup("/api");
        
        mainRoute.MapGet("/{id:guid}", GetById)
            .WithName("GetById")
            .WithDescription("Get a paste by ID.");
        
        mainRoute.MapPost("/", Create)
            .WithName("Create")
            .WithDescription("Create new paste");
        
        mainRoute.MapPut("/{id:guid}", Update)
            .WithName("UpdatePaste")
            .WithDescription("Update an existing paste");
        
        mainRoute.MapDelete("/{id:guid}", Delete)
            .WithName("DeletePaste")
            .WithDescription("Create new paste");
    }

    private async Task<IResult> GetById(IMediator mediator, Guid id)
    {
        var getPaste = new GetById { Id = id };
        var paste = await mediator.Send(getPaste);
        if (paste != null) return TypedResults.Ok(paste);
        return TypedResults.NotFound("NotFoundId");
    }
    private async Task<IResult> Create(IMediator mediator, [FromBody] Paste paste)
    {
        var createPaste = new CreatePaste
        {
            Content = paste.Content,
            Title = paste.Title
        };
        var createdPaste = await mediator.Send(createPaste);
        return Results.CreatedAtRoute("GetById", new { createdPaste.Id }, createdPaste);
    }
    private async Task<IResult> Update(IMediator mediator, Paste post, Guid id)
    {
        var updatePastes = new UpdatePaste()
        {
            Id = id,
            Content = post.Content,
            Title = post.Title
        };
        var updatedPastes = await mediator.Send(updatePastes);
        if (updatedPastes != null) return TypedResults.Ok(updatedPastes);
        return TypedResults.NotFound("NotFoundId");
    }
    private async Task<IResult> Delete(IMediator mediator, Guid id)
    {
        var paste = new DeletePaste(){ Id = id };
        await mediator.Send(paste);
        return TypedResults.NoContent();
    }
}
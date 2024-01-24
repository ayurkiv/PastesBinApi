using Application.Commands;
using Application.Models;
using Application.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Presentation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.RegisterServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/api/{id:guid}", async (IMediator mediator, Guid id) =>
    {
        var getPaste = new GetById { Id = id };
        var paste = await mediator.Send(getPaste);
        if (paste != null) return Results.Ok(paste);
        return Results.NotFound("NotFoundId");
    })
    .WithName("GetById")
    .WithDescription("Get a paste by ID.");

app.MapPost("/api/", async (IMediator mediator, [FromBody] Paste paste) =>
    {
        var createPaste = new CreatePaste
        {
            Content = paste.Content,
            Title = paste.Title
        };
        var createdPaste = await mediator.Send(createPaste);
        return Results.CreatedAtRoute("GetById", new { createdPaste.Id }, createdPaste);
    })
    .WithName("Create")
    .WithDescription("Create new paste");

app.MapPut("/api/{id:guid}", async (IMediator mediator, Paste post, Guid id) =>
    {
        var updatePastes = new UpdatePaste()
        {
            Id = id,
            Content = post.Content,
            Title = post.Title
        };
        var updatedPastes = await mediator.Send(updatePastes);
        if (updatedPastes != null) return Results.Ok(updatedPastes);
        return Results.NotFound("NotFoundId");
    })
    .WithName("UpdatePaste")
    .WithDescription("Update an existing paste");


app.MapDelete("/api/{id:guid}", async (IMediator mediator, Guid id) =>
{
    var paste = new DeletePaste(){ Id = id };
    var statusDelete = await mediator.Send(paste);
    if (statusDelete) return Results.NoContent();
    return Results.NotFound("NotFoundId");
})
    .WithName("DeletePaste")
    .WithDescription("Create new paste");





app.Run();

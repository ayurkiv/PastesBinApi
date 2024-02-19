using System.Net.Http.Json;
using System.Text.Json;
using Application.Abstractions;
using Application.Models;
using Frontend.Services.Interfaces;

namespace Frontend.Services;

public class PasteService : IPasteServices
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _serializer;

    public PasteService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _serializer = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
    }
    public async Task<Paste?> GetById(Guid id)
    {
        try
        {
            var paste = await _httpClient.GetFromJsonAsync<Paste>($"api/{id}");
            return paste;
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
}
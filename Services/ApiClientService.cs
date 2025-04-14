using Microsoft.AspNetCore.Components;
using System.Net;

public class ApiClientService
{
    private readonly HttpClient _client;
    private readonly NavigationManager _nav;

    public ApiClientService(HttpClient client, NavigationManager nav)
    {
        _client = client;
        _nav = nav;
    }

    public async Task<HttpResponseMessage> GetAsync(string url)
    {
        var response = await _client.GetAsync(url);
        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            _nav.NavigateTo("/login", forceLoad: true);
        }
        return response;
    }
}
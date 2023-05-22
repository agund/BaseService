using Microsoft.AspNetCore.Mvc;

namespace BaseService.Controllers;

[ApiController]
[Route("[controller]")]
public class BaseController : ControllerBase
{
    private HttpClient Client { get; set; }

    public BaseController(HttpClient client)
    {
        Client = client;
    }

    [HttpGet]
    public async Task<string> GetBaseAsync(string baseUrl)
    {
        var url = Convert.FromBase64String(baseUrl);
        var msg = Client.GetAsync(System.Text.Encoding.Default.GetString(url));
        var download = await msg.Result.Content.ReadAsByteArrayAsync();
        //Byte[] bytes = File.ReadAllBytes("path");
        var base64 = Convert.ToBase64String(download);
        return base64;
    }
}
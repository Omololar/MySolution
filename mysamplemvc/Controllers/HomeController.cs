using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mysamplemvc.Models;
using Newtonsoft.Json;

namespace mysamplemvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        WeatherViewModel[] deserializeResponse;
        using var client = new HttpClient();

        var result = await client.GetAsync("http://localhost:5011/WeatherForecast");
        Console.WriteLine("status", result.StatusCode);
        Console.WriteLine("data", result.Content);
           var response = await result.Content.ReadAsStringAsync();

        Console.WriteLine("content", response);
       deserializeResponse = JsonConvert.DeserializeObject<WeatherViewModel[]>(response);
        return View(deserializeResponse);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

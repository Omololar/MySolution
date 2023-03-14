using System.Diagnostics;
using System.Text;
using MemberWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MemberWebApplication.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IConfiguration _configuration;

    public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public async Task<IActionResult> Index()
    {
        var url = _configuration.GetValue<string>("API:Url");
        var endpoint = "api/User/alluser";
        var client = new HttpClient();
        var sendRequest = await client.GetAsync($"{url}/{endpoint}");

        var response = await sendRequest.Content.ReadAsStringAsync();
        List<UserModel> users;

        users = JsonConvert.DeserializeObject<List<UserModel>>(response);


        return View(users);
    }
    public IActionResult AddUser()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> AddUser(UserModel user)
    {
        var url = _configuration.GetValue<string>("API:Url");

        var endpoint = "api/User/adduser";
        var client = new HttpClient();
		string data = JsonConvert.SerializeObject(user);

		HttpResponseMessage sendRequest = await client.PostAsync($"{url}/{endpoint}", new StringContent(data, Encoding.UTF8, "application/json"));

        var response = await sendRequest.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<UserModel>(response);

        return View();

    }
    public IActionResult Privacy()
    {
        return View();
    }

    public async Task<IActionResult> Detail(int id)
    {
        var url = _configuration.GetValue<string>("API:Url");
        var endpoint = $"api/User/{id}";
        var client = new HttpClient();
        var sendRequest = await client.GetAsync($"{url}/{endpoint}");

        var response = await sendRequest.Content.ReadAsStringAsync();
        UserModel user = JsonConvert.DeserializeObject<UserModel>(response);

        return View(user);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

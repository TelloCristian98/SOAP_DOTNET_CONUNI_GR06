using ConversionServiceReference1;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        bool isLoggedIn = TempData["IsLoggedIn"] as bool? ?? false;

        if (!isLoggedIn)
        {
            TempData["IsLoggedIn"] = false;
        }

        ViewBag.IsLoggedIn = isLoggedIn;
        TempData.Keep("IsLoggedIn");

        // Si hay un mensaje de error, lo pasamos a la vista
        ViewBag.ErrorMessage = TempData["ErrorMessage"] as string;

        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        if (username == "monster" && password == "monster")
        {
            TempData["IsLoggedIn"] = true;
            return RedirectToAction("Index");
        }

        // Si las credenciales son incorrectas, mandamos un mensaje de error
        TempData["ErrorMessage"] = "Credenciales inválidas";
        TempData["IsLoggedIn"] = false;
        return RedirectToAction("Index"); // Redirigimos a Index para mostrar el mensaje de error
    }

    [HttpPost]
    public async Task<IActionResult> Convertir(double temperatura, string tipo)
    {
        string resultado;

        try
        {
            var client = new ConversionClient();

            if (tipo == "CtoF")
            {
                double valor = await client.ConvertirCelsiusAFahrenheitAsync(temperatura);
                resultado = $"{temperatura} °C = {valor:F2} °F";
            }
            else
            {
                double valor = await client.ConvertirFahrenheitACelsiusAsync(temperatura);
                resultado = $"{temperatura} °F = {valor:F2} °C";
            }

            await client.CloseAsync();
        }
        catch (System.Exception ex)
        {
            resultado = "Error al consumir el servicio: " + ex.Message;
        }

        ViewBag.Resultado = resultado;
        ViewBag.IsLoggedIn = TempData["IsLoggedIn"] as bool? ?? false;
        TempData.Keep("IsLoggedIn");

        return View("Index");
    }

    public IActionResult Logout()
    {
        TempData["IsLoggedIn"] = false;
        return RedirectToAction("Index");
    }
}

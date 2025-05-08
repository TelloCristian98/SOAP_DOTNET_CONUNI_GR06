using ConUnit_Soap_Dotnet_GR06.ec.edu.monster.modelo;
using Microsoft.AspNetCore.Mvc;
namespace ConUnit_Soap_Dotnet_GR06.ec.edu.monster.controlador
{
    [ApiController]
    [Route("[controller]")]
    public class ConversionController : ControllerBase
    {
        private readonly ILogger _logger; private readonly Conversión _conversor;
        public ConversionController(ILogger<ConversionController> logger, Conversión conversor)
        {
            _logger = logger;
            _conversor = conversor;
        }

        [HttpGet("CelsiusToFahrenheit/{celsius}")]
        public ActionResult<double> CelsiusToFahrenheit(double celsius)
        {
            try
            {
                double result = _conversor.CelsiusToFahrenheit(celsius);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error converting Celsius to Fahrenheit");
                return BadRequest("Conversion error occurred");
            }
        }

        [HttpGet("FahrenheitToCelsius/{fahrenheit}")]
        public ActionResult<double> FahrenheitToCelsius(double fahrenheit)
        {
            try
            {
                double result = _conversor.FahrenheitToCelsius(fahrenheit);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error converting Fahrenheit to Celsius");
                return BadRequest("Conversion error occurred");
            }
        }
    }

}

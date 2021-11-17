using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System.Globalization;


namespace WebApiWithAbpResources.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IStringLocalizer<TestResource> _localizer;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IStringLocalizer<TestResource> localizer
            )
        {
            _logger = logger;
            _localizer = localizer;
        }

        [HttpGet]
        [Route("/api/GetLocalized")]
        public string GetLocalized(string name,string cal)
        {
            string stext = GetStringValue(name, cal);

            return stext;
        }

        private string GetStringValue(string stringName, string culture)
        {
            var specifiedCulture = new CultureInfo(culture);
            CultureInfo.CurrentCulture = specifiedCulture;
            CultureInfo.CurrentUICulture = specifiedCulture;
            return _localizer[stringName];
        }
    }
}

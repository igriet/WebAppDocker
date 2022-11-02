using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace WebAppDocker.Pages
{
    public class PrivacyModel : PageModel
    {
        public Class1[] apiResponse;
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            HttpClient client = new HttpClient();

            Task<string> responseTask = Task.Run(async ()=> await client.GetStringAsync("http://172.18.0.3/api/WeatherForecast"));
            var resultApiCall = responseTask.Result;
            var responseObject = JsonSerializer.Deserialize<Class1[]>(resultApiCall);

            apiResponse = responseObject;
        }
    }


    public class Rootobject
    {
        public Class1[] Property1 { get; set; }
    }

    public class Class1
    {
        public DateTime date { get; set; }
        public int temperatureC { get; set; }
        public int temperatureF { get; set; }
        public string summary { get; set; }
    }

}
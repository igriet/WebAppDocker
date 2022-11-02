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
            //Task<string> responseTask = Task.Run(async ()=> await client.GetStringAsync("http://localhost:5061/api/WeatherForecast").w);
            //var resultApiCall= responseTask.
            //var responseObject = JsonSerializer.Deserialize<Class1[]>(response);

            //var responseTask = client.GetStringAsync("http://localhost:5061/api/WeatherForecast").Result;
            //var responseObject = JsonSerializer.Deserialize<Class1[]>(responseTask);

            Task<string> responseTask = Task.Run(async ()=> await client.GetStringAsync("http://localhost:5061/api/WeatherForecast"));
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
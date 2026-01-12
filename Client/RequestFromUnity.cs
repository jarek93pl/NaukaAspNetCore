using System;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using UnityEngine;

public class LoadSpriteFromDisck : MonoBehaviour
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }
    }

    static HttpClient client = new HttpClient();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ServicePointManager.ServerCertificateValidationCallback = TrustCertificate;
        Person person = new Person
        {
            FirstName = "Imie",
            LastName = "Nazwisko"
        };

        // Serialize the Person object to JSON
        string json = JsonUtility.ToJson(person);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

        // Send the POST request
        HttpResponseMessage response = client.PostAsync("https://localhost:44385/WeatherForecast", content).Result;
        // Read and deserialize the response
        string txt = response.Content.ReadAsStringAsync().Result;
        Person result = JsonUtility.FromJson<Person>(txt);

        response.EnsureSuccessStatusCode();
        Console.WriteLine($"Hej! {result.FirstName} {result.LastName} {result.Id}");
    }
    private static bool TrustCertificate(object sender, X509Certificate x509Certificate, X509Chain x509Chain, SslPolicyErrors sslPolicyErrors)
    {
        // all certificates are accepted
        return true;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
/*
 * work with asp net serivce
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace Serwer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        [HttpPost]
        public ActionResult Post(Person p)
        {
            p.Id = Guid.NewGuid().GetHashCode();
            Console.WriteLine($"{p.FirstName} {p.LastName} {p.Id}");
            return new JsonResult(p);
        }
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
*/
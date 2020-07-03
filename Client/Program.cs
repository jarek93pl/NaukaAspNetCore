﻿using DTO;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            mt().Wait();

        }

        private static async Task mt()
        {
            Person person = new Person();
            person.FirstName = "Imie";
            person.LastName = "Nazwisko";
            HttpResponseMessage response = await client.PostAsJsonAsync("https://localhost:5001/WeatherForecast", person);
            Person resulut = JsonConvert.DeserializeObject<Person>(await response.Content.ReadAsStringAsync());
            response.EnsureSuccessStatusCode();
            Console.WriteLine($"Hej! {resulut.FirstName} {resulut.LastName} {resulut.Id}");
        }
    }
}

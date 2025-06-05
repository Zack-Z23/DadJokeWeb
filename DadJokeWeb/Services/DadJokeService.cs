
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;



    public class JokeResponse
    {
        public string Id { get; set; }

        [JsonPropertyName("joke")]
        public string Joke { get; set; }

        public int Status { get; set; }
    }

    public class DadJokeService
    {
        private readonly HttpClient _httpClient;

        public DadJokeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<string> GetRandomJokeAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://icanhazdadjoke.com/");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var jokeObj = JsonSerializer.Deserialize<JokeResponse>(json);

                return jokeObj?.Joke ?? "No joke found.";
            }
            catch (Exception ex)
            {
                return $"Error fetching joke: {ex.Message}";
            }
        }
    }

﻿using System;
using System.Net.Http;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

#pragma warning disable CA1014
// The code that's violating the rule is on this line.
#pragma warning restore CA1014
namespace CanHazFunny; 

public class JokeService : IJokeService
{
    private HttpClient HttpClient { get; } = new();

    public string GetJoke()
    {
        string jokeJSON = HttpClient.GetStringAsync("https://geek-jokes.sameerkumar.website/api?format=json").Result;
        
        JokeObject jokeObject = JsonSerializer.Deserialize<JokeObject>(jokeJSON) ?? throw new ArgumentNullException();
        
        return jokeObject.joke;
    }
}
using System.Net;

namespace AdventOfCode2023.Utility;
public static class WebUtility
{
  public static bool TryGetFile(string? path, out string file)
  {
    file = "";

    if (File.Exists(path)) file = File.ReadAllText(path);

    return !string.IsNullOrEmpty(file);
  }

  public static async Task<string> GetFile(string path, string? session, int year, int day)
  {
    if (session == null) throw new ArgumentNullException(nameof(session), "Missing session cookie");

    if (TryGetFile(path, out string file)) return file;

    var baseUri = new Uri("http://adventofcode.com");
    var cookieContainer = new CookieContainer();

    using var handler = new HttpClientHandler { CookieContainer = cookieContainer };
    using var http = new HttpClient(handler) { BaseAddress = baseUri };

    cookieContainer.Add(baseUri, new Cookie("session", session));

    var response = await http.GetAsync($"{year}/day/{day}/input");

    response.EnsureSuccessStatusCode();

    file = await response.Content.ReadAsStringAsync();

    if (!Directory.Exists($"inputs/{year}/")) Directory.CreateDirectory($"inputs/{year}/");

    await File.WriteAllTextAsync(path, file);

    return file;
  }
}

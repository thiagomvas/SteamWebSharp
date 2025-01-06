using System.Text.Json;

namespace SteamWebSharp;

internal class Utils
{
    private static readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true
    };

    /// <summary>
    ///     Extracts the "response" object from a Steam API response and deserializes it into the specified type.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the response object into.</typeparam>
    /// <param name="json">The raw JSON string from the Steam API.</param>
    /// <returns>The deserialized response object.</returns>
    public static T ExtractResponse<T>(string json)
    {
        using var document = JsonDocument.Parse(json);
        var root = document.RootElement;

        if (root.TryGetProperty("response", out var responseElement))
            return JsonSerializer.Deserialize<T>(responseElement.GetRawText(), _options);

        if (root.TryGetProperty("game", out var gameElement))
            return JsonSerializer.Deserialize<T>(gameElement.GetRawText(), _options);

        return JsonSerializer.Deserialize<T>(root.GetRawText(), _options);

        //if (root.TryGetProperty("players", out var playersElement) && playersElement.GetArrayLength() > 0)
        //{
        //    var firstPlayerElement = playersElement[0];
        //    return JsonSerializer.Deserialize<T>(playersElement.GetRawText(), _options);
        //}

        //if (root.TryGetProperty("friendslist", out var friendsListElement))
        //{
        //    // Deserialize the "friends" array into the target type
        //    return JsonSerializer.Deserialize<T>(friendsListElement.GetRawText(), _options);
        //}

        //throw new InvalidOperationException("The response object is missing or invalid.");
    }
}
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SteamWebSharp.Converters;

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class UnixTimestampConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Number)
        {
            // Determine the value type (int or long) and parse accordingly
            if (reader.TryGetInt64(out long timestamp))
            {
                return DateTimeOffset.FromUnixTimeSeconds(timestamp).DateTime;
            }
            else if (reader.TryGetInt32(out int timestampInt))
            {
                return DateTimeOffset.FromUnixTimeSeconds(timestampInt).DateTime;
            }
        }

        throw new JsonException("Invalid token type or value for Unix timestamp.");
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        // Convert DateTime to Unix timestamp (seconds)
        long timestamp = new DateTimeOffset(value).ToUnixTimeSeconds();
        writer.WriteNumberValue(timestamp);
    }
}

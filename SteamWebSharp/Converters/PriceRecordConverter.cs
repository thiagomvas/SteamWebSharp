using System.Text.Json;
using SteamWebSharp.Models.Market;

namespace SteamWebSharp.Converters;

public class PriceRecordConverter : System.Text.Json.Serialization.JsonConverter<List<PriceRecord>>
{
    public override List<PriceRecord> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var records = new List<PriceRecord>();

        if (reader.TokenType != JsonTokenType.StartArray)
        {
            throw new JsonException();
        }

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndArray)
            {
                break;
            }

            if (reader.TokenType == JsonTokenType.StartArray)
            {
                reader.Read(); // Read UTC Time
                string utcTime = reader.GetString();
                
                // Parse utcTime into a DateTime
                DateTime dateTime = DateTime.ParseExact(utcTime, "MMM dd yyyy 01: +0", System.Globalization.CultureInfo.InvariantCulture);

                reader.Read(); // Read Price
                double price = reader.GetDouble();

                reader.Read(); // Read Volume
                string volume = reader.GetString();

                records.Add(new PriceRecord
                {
                    Date = dateTime,
                    Price = price,
                    Volume = int.Parse(volume)
                });

                reader.Read(); // End of inner array
            }
        }

        return records;
    }

    public override void Write(Utf8JsonWriter writer, List<PriceRecord> value, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Writing JSON is not implemented.");
    }
}
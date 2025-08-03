using System.Text.Json.Serialization;

public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary
    [JsonPropertyName("features")]
    public List<Feature> Features { get; set; }
}

public class Feature
{
    [JsonPropertyName("properties")]
    public EarthquakeProperties Properties { get; set; }
}

public class EarthquakeProperties
{
    [JsonPropertyName("place")]
    public string Place { get; set; }

    // Magnitude can sometimes be null in the data, so we use a nullable decimal.
    [JsonPropertyName("mag")]
    public decimal? Mag { get; set; }
}
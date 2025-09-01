namespace Store.Client.Web.Options;

public class OpenTelemetryOptions
{
    public const string Section = "OpenTelemetry";

    public string Endpoint { get; set; } = default!;
}

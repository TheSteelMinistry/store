namespace Store.Client.Web.Options;

public abstract class ApiOptions
{
    public virtual string Section => string.Empty;

    public string BaseUrl { get; set; } = default!;
}

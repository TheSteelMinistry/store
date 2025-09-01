using System.Collections.Concurrent;
using System.Diagnostics.Metrics;

namespace Store.Client.Web.Metrics;

public class UserMetrics
{
    public static string MeterName => "UserMetrics";
    private static readonly Meter Meter = new(MeterName);
    private static readonly ConcurrentDictionary<string, DateTime> RecentRequests = new();
    private const int ActiveWindowSeconds = 30;
    static UserMetrics()
    {
        Meter.CreateObservableGauge(
            "active_users",
            () => new Measurement<int>(GetActiveUsers()),
            description: "Number of active Blazor circuits (approx users/tabs)");
    }

    public static void PingRequest(string id)
    {
        RecentRequests[id] = DateTime.UtcNow;
    }

    private static int GetActiveUsers()
    {
        DateTime cutoff = DateTime.UtcNow.AddSeconds(-ActiveWindowSeconds);

        foreach (KeyValuePair<string, DateTime> kvp in RecentRequests)
        {
            if (kvp.Value < cutoff)
                RecentRequests.TryRemove(kvp.Key, out _);
        }

        return RecentRequests.Count;
    }

    public static void Reset() => RecentRequests.Clear();
}

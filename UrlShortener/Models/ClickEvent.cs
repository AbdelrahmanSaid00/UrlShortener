namespace UrlShortener.Models;

public class ClickEvent
{
    public long Id { get; set; }

    public long ShortUrlId { get; set; }

    public DateTime ClickedAt { get; set; }

    public string IpAddress { get; set; } = string.Empty;

    public string DeviceType { get; set; } = string.Empty;

    public string Browser { get; set; } = string.Empty;

    public string? Referer { get; set; }

    public ShortUrl ShortUrl { get; set; } = null!;
}


namespace UrlShortener.Models;

public class ShortUrl
{
    public long Id { get; set; }

    public string ShortCode { get; set; } = string.Empty;

    public string OriginalUrl { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public DateTime? ExpiresAt { get; set; }

    public ICollection<ClickEvent> ClickEvents { get; set; } = new List<ClickEvent>();
}


namespace UrlShortener.DTOs;

public sealed record ShortUrlResponse(
    string ShortCode,
    string ShortUrl,
    string OriginalUrl,
    DateTime CreatedAt);


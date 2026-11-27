using System.Security.Cryptography;

namespace UrlShortener.Services;

public class ShortCodeGenerator
{
    private const string Alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    public const int CodeLength = 7;

    public string Generate()
    {
        return RandomNumberGenerator.GetString(Alphabet, CodeLength);
    }
}


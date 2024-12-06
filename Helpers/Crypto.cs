using BCrypt.Net;
using dotnetproject.Models;

namespace dotnetproject.Helpers;

public class Crypto {
    public static string HashPassword(string text) {
        try
        {
            return BCrypt.Net.BCrypt.HashPassword(text);
        }
        catch (SaltParseException ex)
        {
            throw new GeneratePasswordFailedException($"error generating password: {ex}");
        }
    }

    public static bool ComparePassword(string password, string hashedPassword) {
        try
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
        catch (Exception ex)
        {
            throw new ComparePasswordFailException($"failed to compare password: {ex}");
        }
    }
}
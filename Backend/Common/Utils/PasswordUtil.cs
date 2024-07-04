using Common.Constants;

namespace Common.Utils;

public class PasswordUtil
{
    public static bool VerifyPassword(string password, string hashedPasswordWithSalt)
    {
        string hashedPassword = hashedPasswordWithSalt.Substring(0, 60);

        bool isPasswordCorrect = BCrypt.Net.BCrypt.Verify(password, hashedPassword);

        return isPasswordCorrect;
    }

    public static string HashPassword(string password)
    {
        string salt = BCrypt.Net.BCrypt.GenerateSalt();

        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, workFactor: SystemConstants.PASSWORD_ITERATION);

        string passwordWithSalt = $"{hashedPassword}{salt}";

        return passwordWithSalt;
    }
}

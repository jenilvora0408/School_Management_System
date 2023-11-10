using System.Security.Cryptography;

namespace Common.Utils
{
    public class PasswordUtil
    {
        public static bool VerifyPassword(string password, string hashedPasswordWithSalt)
        {
            string hashedPassword = hashedPasswordWithSalt.Substring(0, 60);

            bool isPasswordCorrect = BCrypt.Net.BCrypt.Verify(password, hashedPassword);

            return isPasswordCorrect;
        }
    }
}

using BCryptNet = BCrypt.Net.BCrypt;

namespace DoctorPrj.Models.Helpers
{
    public class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            return BCryptNet.HashPassword(password);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return BCryptNet.Verify(password, hashedPassword);
        }
    }
}

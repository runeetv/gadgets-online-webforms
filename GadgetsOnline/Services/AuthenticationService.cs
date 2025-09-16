using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using GadgetsOnline.Models;

namespace GadgetsOnline.Services
{
    public class AuthenticationService
    {
        private readonly GadgetsOnlineEntities _context;

        public AuthenticationService()
        {
            _context = new GadgetsOnlineEntities();
        }

        public bool ValidateUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return false;

            var user = _context.AdminUsers.FirstOrDefault(u => u.Username.ToLower() == username.ToLower() && u.IsActive);
            
            if (user != null)
            {
                string hashedPassword = HashPassword(password);
                if (user.PasswordHash == hashedPassword)
                {
                    // Update last login date
                    user.LastLoginDate = DateTime.Now;
                    _context.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        public AdminUser GetUser(string username)
        {
            return _context.AdminUsers.FirstOrDefault(u => u.Username.ToLower() == username.ToLower() && u.IsActive);
        }

        public string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
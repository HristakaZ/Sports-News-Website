using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sports_News_Website.Services
{
    public static class HashingPasswordService
    {
        public static string GenerateSHA256Hash(string input, string salt)
        {
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input + salt);
            System.Security.Cryptography.SHA256Managed sha256string = new System.Security.Cryptography.SHA256Managed();
            byte[] hash = sha256string.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
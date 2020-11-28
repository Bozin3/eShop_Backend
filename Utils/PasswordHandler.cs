using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using eShop_Backend.Models;

namespace eShop_Backend.Utils
{
    public class PasswordHandler : IPasswordHandler
    {
        public bool CheckValidPassword(string providedPass, User user)
        {
            using (HMACSHA512 hmac = new HMACSHA512(user.PasswordSalt))
            {
                byte[] passwordbytes = Encoding.ASCII.GetBytes(providedPass);
                var computedHash = hmac.ComputeHash(passwordbytes);
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != user.PasswordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (HMACSHA512 hmac = new HMACSHA512())
            {
                byte[] passwordbytes = Encoding.ASCII.GetBytes(password);
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(passwordbytes);
            }
        }

    }
}

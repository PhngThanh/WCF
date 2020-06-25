using System;
using System.Text;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace POS.Repository.Entities.Services
{
    public partial interface IAccountService
    {
        Account CheckLogin(string username, string password);
        void EditAccountPassword(Account account);
    }

    public partial class AccountService
    {
        public IEnumerable<Account> CntAccount()
        {
            var result = repository.GetActive();
            return result;

        }
        public Account CheckLogin(string username, string password)
        {
            var targetUser = FirstOrDefault(a => a.AccountId == username);
            if (targetUser == null)
            {
                return null;
            }
            if (password == null)
            {
                return null;
            }
            var isSuccess = this.VerifyHashedPassword(targetUser.AccountPassword, password);
            if (isSuccess)
            {
                return targetUser;
            }

            return null;
        }

        public void EditAccountPassword(Account account)
        {
            // TODO: review this Hash (maybe wrong)
            string hash = HashPassword(account.AccountPassword);
            account.AccountPassword = hash;
            repository.Edit(account);
            Save();
        }

        public bool VerifyHashedPassword(string hashedPassword, string password)
        {
            byte[] buffer4;
            if (hashedPassword == null)
            {
                return false;
            }
            if (password == null)
            {
                //Đã catch password = null ở ngoài
                throw new ArgumentNullException("password");
            }
            byte[] src = Convert.FromBase64String(hashedPassword);
            if ((src.Length != 0x31) || (src[0] != 0))
            {
                return false;
            }
            byte[] dst = new byte[0x10];
            Buffer.BlockCopy(src, 1, dst, 0, 0x10);
            byte[] buffer3 = new byte[0x20];
            Buffer.BlockCopy(src, 0x11, buffer3, 0, 0x20);
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, dst, 0x3e8))
            {
                buffer4 = bytes.GetBytes(0x20);
            }

            return ByteArraysEqual(buffer3, buffer4);
        }

        public static bool ByteArraysEqual(byte[] b1, byte[] b2)
        {
            if (b1 == b2) return true;
            if (b1 == null || b2 == null) return false;
            if (b1.Length != b2.Length) return false;
            for (int i = 0; i < b1.Length; i++)
            {
                if (b1[i] != b2[i]) return false;
            }
            return true;
        }

        public static string HashPassword(string password)
        {
            byte[] salt;
            byte[] buffer2;
            if (password == null)
            {
                //Đã catch password = null ở ngoài
                throw new ArgumentNullException("password");
            }
            using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
            {
                salt = bytes.Salt;
                buffer2 = bytes.GetBytes(0x20);
            }
            byte[] dst = new byte[0x31];
            Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
            Buffer.BlockCopy(buffer2, 0, dst, 0x11, 0x20);
            return Convert.ToBase64String(dst);
        }

        //private static string HashMp5(string password)
        //{
        //    MD5 md5Hash = MD5.Create();
        //    // Convert the input string to a byte array and compute the hash. 
        //    var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

        //    // Create a new Stringbuilder to collect the bytes 
        //    // and create a string.
        //    var sBuilder = new StringBuilder();

        //    // Loop through each byte of the hashed data  
        //    // and format each one as a hexadecimal string. 
        //    foreach (var t in data)
        //    {
        //        sBuilder.Append(t.ToString("x2"));
        //    }

        //    // Return the hexadecimal string. 
        //    return sBuilder.ToString();
        //}
    }
}

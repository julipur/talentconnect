using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace TalentConnect.Infrastructure.Security
{
    public class SaltedHash
    {
        private readonly HashAlgorithm _hashProvider;
        private readonly int _salthLength;

        public SaltedHash(HashAlgorithm hashAlgorithm, int length)
        {
            _hashProvider = hashAlgorithm;
            _salthLength = length;
        }

        public SaltedHash()
            : this(new SHA256Managed(), 4)
        {
        }

        private byte[] ComputeHash(byte[] data, byte[] salt)
        {
            var dataAndSalt = new byte[data.Length + _salthLength];

            Array.Copy(data, dataAndSalt, data.Length);
            Array.Copy(salt, 0, dataAndSalt, data.Length, _salthLength);

            return _hashProvider.ComputeHash(dataAndSalt);
        }

        public void GetHashAndSalt(byte[] data, out byte[] hash, out byte[] salt)
        {
            salt = new byte[_salthLength];

            var random = new RNGCryptoServiceProvider();

            random.GetNonZeroBytes(salt);

            hash = ComputeHash(data, salt);
        }

        public void GetHashAndSaltString(string data, out string hash, out string salt)
        {
            byte[] hashOut;
            byte[] saltOut;

            GetHashAndSalt(Encoding.UTF8.GetBytes(data), out hashOut, out saltOut);

            hash = Convert.ToBase64String(hashOut);
            salt = Convert.ToBase64String(saltOut);
        }

        public bool VerifyHash(byte[] data, byte[] hash, byte[] salt)
        {
            var newHash = ComputeHash(data, salt);

            if (newHash.Length != hash.Length)
            {
                return false;
            }

            for (int Lp = 0; Lp < hash.Length; Lp++)
            {
                if (!hash[Lp].Equals(newHash[Lp]))
                {
                    return false;
                }
            }
            return true;
        }

        public bool VerifyHashString(string data, string hash, string salt)
        {
            var hashToVerify = Convert.FromBase64String(hash);
            var saltToVerify = Convert.FromBase64String(salt);
            var dataToVerify = Encoding.UTF8.GetBytes(data);

            return VerifyHash(dataToVerify, hashToVerify, saltToVerify);
        }

    }
}
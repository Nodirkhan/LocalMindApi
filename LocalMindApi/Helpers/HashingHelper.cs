using System;
using System.Security.Cryptography;

namespace LocalMindApi.Helpers
{
    public static class HashingHelper
    {
        public static string GetHash(string input)
        {
            var salt = new byte[32];
            RandomNumberGenerator.Fill(data: salt);

            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                password: input,
                salt: salt,
                iterations: 10000,
                hashAlgorithm: HashAlgorithmName.SHA256,
                outputLength: 32);

            byte[] hashBytes = new byte[64];
            salt.CopyTo(destination: hashBytes.AsSpan(start: 0, length: 32));
            hash.CopyTo(destination: hashBytes.AsSpan(start: 32, length: 32));

            return Convert.ToBase64String(inArray: hashBytes);
        }

        public static bool IsHashValid(string input, string hashedValue)
        {
            try
            {
                byte[] hashBytes = Convert.FromBase64String(hashedValue);

                Span<byte> salt = new byte[32];
                hashBytes.AsSpan(start: 0, length: 32).CopyTo(destination: salt);

                byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                    password: input,
                    salt: salt,
                    iterations: 10000,
                    hashAlgorithm: HashAlgorithmName.SHA256,
                    outputLength: 32);

                return CryptographicOperations.FixedTimeEquals(
                    left: hashBytes.AsSpan(start: 32, length: 32),
                    right: hash);
            }
            catch
            {
                return false;
            }
        }
    }
}

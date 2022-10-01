using System.Security.Cryptography;

namespace Dominio.Utils
{
    internal static class Crypto
    {
        /*public static string GetHash(string pass)
        {
            // generate a 128-bit salt using a cryptographically strong random sequence of nonzero values
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }
            //Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: pass,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            return hashed;
        }*/

        public static string GetHash(string pass)
        {
            //PASO 1 Cree el valor salt con un PRNG criptográfico:
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            //PASO 2 Cree Rfc2898DeriveBytes y obtenga el valor hash:
            var pbkdf2 = new Rfc2898DeriveBytes(pass, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            //PASO 3 Combine los bytes de sal y contraseña para su uso posterior:
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            //PASO 4 Convierta la combinación de sal y hachís en una cadena para almacenar
            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            return savedPasswordHash;

        }

        /*public static bool VerifyPassword(string pass, string hash)
        {
            return hash == GetHash(pass);
        }*/

        public static bool VerifyPassword(string pass, string hashDB)
        {
            /* Fetch the stored value */
            string savedPasswordHash = hashDB;
            /* Extract the bytes */
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);
            /* Get the salt */
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(pass, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            /* Compare the results */
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    //throw new UnauthorizedAccessException();
                    return false;

            return true;
        }
    }
}

using System.Security.Cryptography;

namespace DestinyHaven.GenericModels
{
    public static class RandomCodeGenerate
    {
        // Random Guvenli Kod Uretme
        public static int GenerateSecureRandomCode(int codeLenght)
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] randomNumber = new byte[codeLenght];
                rng.GetBytes(randomNumber);
                int secureRandomCode = BitConverter.ToInt32(randomNumber, 0);
                secureRandomCode = Math.Abs(secureRandomCode % 900000) + 100000;
                return secureRandomCode;
            }
        }
    }
}

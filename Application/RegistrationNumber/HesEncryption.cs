namespace Application.HesEncryption
{
    using System;
    using System.IO;
    using System.Linq;
    using Core.Security.Cryptography;
    using DGK;

    public class HesEncryptions
    {
        private const int BitLength = 37;

        public string Encrypt( string input)
        {
            // var dgk = new DGK(_publicKey, _privateKey, new DecryptionParameters());
            //var dgk = new DGK(new SecurityParameters { k = 54, t = 9, l = 8}, new DecryptionParameters{dms = 4});
            // var dgk = new DGK(new SecurityParameters { k = 256, t = 9, l = 8}, new DecryptionParameters{dms = 4});
            var dgk = new DGK(new SecurityParameters { k = 1024, t = 160, l = 16 },
                              new DecryptionParameters { dms = 4 });

            var requirementBits = input.PadLeft(BitLength, '0').Select(bit => int.Parse((string)bit.ToString())).ToArray();

            var encryptedRequirementBits = requirementBits.Select(bit => dgk.Encrypt(bit)).ToArray();

            using var stream = new MemoryStream();

            foreach (var encryptedRequirementBit in encryptedRequirementBits) stream.Write(encryptedRequirementBit.data.ToByteArray());

            stream.Flush();
            stream.Position = 0;

            var hash = SHA3.CreateKeccak512().ComputeHash(stream);
            var hex = Application.BitConverter.ByteArrayToHexViaLookup32(hash);
            return hex;
        }
    }
}
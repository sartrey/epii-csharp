using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EPII
{
    /// <summary>
    /// hash
    /// </summary>
    public class Hash
    {
        private Stream _Stream = null;
        private Encoding _Encoding = Encoding.UTF8;

        public Stream Stream
        {
            get { return _Stream; }
            set { _Stream = value; }
        }

        public Encoding Encoding
        {
            get { return _Encoding; }
            set { _Encoding = value; }
        }

        public Hash()
        {
        }

        public Hash(Stream stream)
        {
            _Stream = stream;
        }

        private string ComputeHash(HashAlgorithm hasher)
        {
            byte[] codes = null;
            codes = hasher.ComputeHash(_Stream);
            var sbd = new StringBuilder();
            foreach (byte b in codes)
                sbd.Append(b.ToString("x2"));
            return sbd.ToString();
        }

        public string GetMD5()
        {
            var hasher = MD5.Create();
            return ComputeHash(hasher);
        }

        public string GetMD5Cng()
        {
            var hasher = MD5Cng.Create();
            return ComputeHash(hasher);
        }

        public string GetSHA1()
        {
            var hasher = SHA1.Create();
            return ComputeHash(hasher);
        }

        public string GetSHA1Cng()
        {
            var hasher = SHA1Cng.Create();
            return ComputeHash(hasher);
        }
    }
}
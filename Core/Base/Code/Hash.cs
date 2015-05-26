using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EPII.Code
{
    /// <summary>
    /// hash
    /// </summary>
    public class Hash
    {
        private Stream stream_ = null;
        private Encoding encoding_ = Encoding.UTF8;

        public Stream Stream
        {
            get { return stream_; }
            set { stream_ = value; }
        }

        public Encoding Encoding
        {
            get { return encoding_; }
            set { encoding_ = value; }
        }

        public Hash()
        {
        }

        public Hash(string text)
        {
            SetText(text);
        }

        public Hash(Stream stream)
        {
            stream_ = stream;
        }

        private string ComputeHash(HashAlgorithm hasher)
        {
            byte[] codes = null;
            codes = hasher.ComputeHash(stream_);
            var sbd = new StringBuilder();
            foreach (byte b in codes)
                sbd.Append(b.ToString("x2"));
            return sbd.ToString();
        }

        public void SetText(string text) 
        {
            if(stream_ != null)
                stream_.Close();
            stream_ = new MemoryStream(
                encoding_.GetBytes(text));
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
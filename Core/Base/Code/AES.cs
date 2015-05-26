using System.IO;
using System.Security.Cryptography;

namespace EPII.Code
{
    public sealed class AES : ObjectEx
    {
        private RijndaelManaged core_ = new RijndaelManaged();

        public int KeySize
        {
            get { return core_.KeySize / 8; }
        }

        public int IVSize
        {
            get { return core_.BlockSize / 8; }
        }

        public byte[] Key
        {
            get { return core_.Key; }
            set { core_.Key = value; }
        }

        public byte[] IV
        {
            get { return core_.IV; }
            set { core_.IV = value; }
        }

        public byte[] Decipher(byte[] source)
        {
            var ms_src = new MemoryStream(source);
            var cs = new CryptoStream(
                ms_src, core_.CreateDecryptor(), CryptoStreamMode.Read);
            var ms_dst = new MemoryStream();
            cs.CopyTo(ms_dst);
            return ms_dst.ToArray();
        }

        /// <summary>
        /// from file to file
        /// </summary>
        public void Decipher(string source, string target)
        {
            var fs_src = new FileStream(
                source, FileMode.Open, FileAccess.Read);
            var fs_dst = new FileStream(
                target, FileMode.Create, FileAccess.Write);
            var cs = new CryptoStream(
                fs_src, core_.CreateDecryptor(), CryptoStreamMode.Read);
            cs.CopyTo(fs_dst);
            cs.Close();
            fs_dst.Close();
            fs_src.Close();
        }

        /// <summary>
        /// from stream to stream
        /// </summary>
        public void Decipher(Stream source, Stream target)
        {
            var cs = new CryptoStream(
                source, core_.CreateDecryptor(), CryptoStreamMode.Read);
            cs.CopyTo(target);
            cs.Close();
        }

        public byte[] Encipher(byte[] source)
        {
            var ms_src = new MemoryStream(source);
            var cs = new CryptoStream(
                ms_src, core_.CreateEncryptor(), CryptoStreamMode.Read);
            var ms_dst = new MemoryStream();
            cs.CopyTo(ms_dst);
            return ms_dst.ToArray();
        }

        /// <summary>
        /// from file to file
        /// </summary>
        public void Encipher(string source, string target)
        {
            var fs_src = new FileStream(
                source, FileMode.Open, FileAccess.Read);
            var fs_dst = new FileStream(
                target, FileMode.Create, FileAccess.Write);
            var cs = new CryptoStream(
                fs_src, core_.CreateEncryptor(), CryptoStreamMode.Read);
            cs.CopyTo(fs_dst);
            cs.Close();
            fs_dst.Close();
            fs_src.Close();
        }

        /// <summary>
        /// from stream to stream
        /// </summary>
        public void Encipher(Stream source, Stream target)
        {
            var cs = new CryptoStream(
                source, core_.CreateEncryptor(), CryptoStreamMode.Read);
            cs.CopyTo(target);
            cs.Close();
        }

        protected override void DisposeManaged()
        {
            core_.Dispose();
        }

        protected override void DisposeNative()
        {
        }
    }
}
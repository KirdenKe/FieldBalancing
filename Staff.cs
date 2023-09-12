using System;
using System.Text;
using System.Security.Cryptography;

namespace FeildBalancing
{
    public enum Machine
    {
        FieldBalancing,
        etc
    }
    public class Staff
    {
        public string? Name { get; }
        public string? ID { get; }
        public string? Account { get; }
        public string? Password { get; }
        public bool isComplete = false;
        internal List<Object> AllowedMachine = new List<Object>();
        public Staff(string name, string iD, string account, string password, List<Object> allowedMachine) 
        {
            Name = name;
            ID = iD;
            Account = account;
            Password = password;
            AllowedMachine = allowedMachine;
            isComplete = true;
        }
        public Staff() { }
    }
    public class Administrator
    {
        //private const string Account = "KirdenKe";
        //private const string Password = "109303512";
        private bool _AllowLogin = false;
        public bool AllowLogin
        {
            get { return _AllowLogin; }
        }
        private const string _VerifyKey = "kelcX9Z8TN0FwfOzPdTfQA==";
        public static string VerifyKey
        {
            get => _VerifyKey;
        }
        public Administrator(string account, string password) 
        {
            string encrypt = aesEncryptBase64(account, password);
            if (encrypt == _VerifyKey)
                _AllowLogin = true;
        }
        public Administrator()
        {
            _AllowLogin = false;
        }
        internal static string aesEncryptBase64(string account, string password)
        {
            string encrypt = "";
            try
            {
                AesCryptoServiceProvider aes = new AesCryptoServiceProvider();
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider();
                byte[] key = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                byte[] iv = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
                aes.Key = key;
                aes.IV = iv;
                byte[] dataByteArray = Encoding.UTF8.GetBytes(account);
                using (MemoryStream ms = new MemoryStream())
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(dataByteArray, 0, dataByteArray.Length);
                    cs.FlushFinalBlock();
                    encrypt = Convert.ToBase64String(ms.ToArray());
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return encrypt;
        }
    }
    public class LoginArgs : EventArgs
    {
        private bool _isLoginSuccessed = false;
        private string _account = "";
        private string _password = "";
        public string account
        {
            get { return _account; }
        }
        public string password
        {
            get { return _password; }
        }
        public bool isLoginSuccessed
        {
            get { return _isLoginSuccessed; }
        }
        public LoginArgs(string account, string password)
        {
            string encrypt = Administrator.aesEncryptBase64(account, password);
            if (encrypt == Administrator.VerifyKey)
            {
                _isLoginSuccessed = true;
                _account = account;
                _password = password;
            }
        }
    }
    public class LockArgs : EventArgs
    {

    }
}

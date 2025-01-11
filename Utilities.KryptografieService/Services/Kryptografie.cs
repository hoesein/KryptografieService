using Newtonsoft.Json;
using System.Security.Cryptography;
using Utilities.KryptografieService.IServices;

namespace Utilities.KryptografieService.Services;

public class Kryptografie : IKryptografie
{
    private static byte[] _key;
    private static Aes _aes;

    private static void SetActualKey(string secretKey)
    {
        //_key = Encoding.UTF8.GetBytes(secretKey);
        //_key = SHA1.HashData(_key);
        //Array.Resize(ref _key, 16);

        _aes = Aes.Create();
        _aes.Key = Convert.FromBase64String(secretKey);
        _aes.Mode = CipherMode.ECB;
        _aes.Padding = PaddingMode.PKCS7;
    }

    public string DecryptString(string stringToDecrypt, string secretKey)
    {
        if (string.IsNullOrEmpty(secretKey))
        {
            throw new ArgumentNullException(nameof(secretKey));
        }

        if (string.IsNullOrEmpty(stringToDecrypt))
        {
            throw new ArgumentNullException(nameof(stringToDecrypt));
        }

        try
        {
            SetActualKey(secretKey);
            var decryptor = _aes.CreateDecryptor();
            using var ms = new MemoryStream(Convert.FromBase64String(stringToDecrypt));
            using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var sr = new StreamReader(cs);
            var dataString = sr.ReadToEnd();

            if (dataString is null) throw new Exception("Error decrypting the string");

            return dataString;
        }
        catch (Exception ex)
        {
            throw new Exception("Error decrypting the string", ex);
        }
    }

    public T DecryptObject<T>(string stringOfObjToDecrypt, string secretKey)
    {
        if (string.IsNullOrEmpty(secretKey))
        {
            throw new ArgumentNullException(nameof(secretKey));
        }

        if (string.IsNullOrEmpty(stringOfObjToDecrypt))
        {
            throw new ArgumentNullException(nameof(stringOfObjToDecrypt));
        }

        try
        {
            SetActualKey(secretKey);
            var decryptor = _aes.CreateDecryptor();
            using var ms = new MemoryStream(Convert.FromBase64String(stringOfObjToDecrypt));
            using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var sr = new StreamReader(cs);
            var dataString = sr.ReadToEnd();

            if (dataString is null) throw new Exception("Error decrypting the string");

            return JsonConvert.DeserializeObject<T>(dataString)!;
        }
        catch (Exception ex)
        {
            throw new Exception("Error decrypting the string", ex);
        }
    }

    public string EncryptObject<T>(T objToEncrypt, string secretKey)
    {
        if (objToEncrypt is not { })
        {
            throw new ArgumentNullException(nameof(objToEncrypt));
        }

        if (string.IsNullOrEmpty(secretKey))
        {
            throw new ArgumentNullException(nameof(secretKey));
        }

        try
        {
            SetActualKey(secretKey);
            var encryptor = _aes.CreateEncryptor();
            using var ms = new MemoryStream();
            using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
            {
                using (var sw = new StreamWriter(cs))
                {
                    sw.Write(JsonConvert.SerializeObject(objToEncrypt));
                }
            }
            return Convert.ToBase64String(ms.ToArray());
        }
        catch (Exception ex)
        {
            throw new Exception("Error encrypting the string", ex);
        }
    }

    public string EncryptString(string stringToEncrypt, string secretKey)
    {
        if (stringToEncrypt is not { })
        {
            throw new ArgumentNullException(nameof(stringToEncrypt));
        }

        if (string.IsNullOrEmpty(secretKey))
        {
            throw new ArgumentNullException(nameof(secretKey));
        }

        try
        {
            SetActualKey(secretKey);
            var encryptor = _aes.CreateEncryptor();
            using var ms = new MemoryStream();
            using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
            {
                using (var sw = new StreamWriter(cs))
                {
                    sw.Write(JsonConvert.SerializeObject(stringToEncrypt));
                }
            }
            return Convert.ToBase64String(ms.ToArray());
        }
        catch (Exception ex)
        {
            throw new Exception("Error encrypting the string", ex);
        }
    }
}

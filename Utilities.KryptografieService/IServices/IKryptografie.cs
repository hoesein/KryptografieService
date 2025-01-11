using Utilities.KryptografieService.Models;

namespace Utilities.KryptografieService.IServices;

public interface IKryptografie
{
    string DecryptString(string stringToDecrypt, string secretKey);
    T DecryptObject<T>(string stringOfObjToDecrypt, string secretKey);
    string EncryptString(string stringToEncrypt, string secretKey);
    string EncryptObject<T>(T objToEncrypt, string secretKey);
}

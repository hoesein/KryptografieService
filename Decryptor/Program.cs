using Utilities.KryptografieService.Models;
using Utilities.KryptografieService.Services;

var service = new Kryptografie();
var krypto = new Krypto("bpaAdmin", "Pass@#$%a");
var secretKey = "Nk55c1pBTFBUcmExZEt0V2lqYUE2MUZzWUh4cmF6alg=";
var originalString = "Pass@#$%a";

var encrypted = service.EncryptString(originalString, secretKey);

Console.WriteLine($"Encrypted String: {encrypted}");
Console.WriteLine($"Original String: {originalString}");
Console.WriteLine();

//var decrypted = service.DecryptString("aWXB+ZFMTvrSAm7T9KSFtQ==", secretKey);
//Console.WriteLine($"Decrypted: {decrypted}");
//Console.WriteLine($"Key: {secretKey}");
//Console.WriteLine();

//var encryptedObject = service.EncryptObject(krypto, secretKey);
//Console.WriteLine($"Encrypted Object: {encryptedObject}");
//Console.WriteLine($"Original Object: {JsonConvert.SerializeObject(krypto)}");
//Console.WriteLine();

//var decryptedObject = service.DecryptObject<Krypto>(encryptedObject, secretKey);
//Console.WriteLine($"Decrypted Object: {JsonConvert.SerializeObject(decryptedObject)}");
//Console.WriteLine();

# Kryptografie (Only for personal use)

## Description
This repository contains the implementation of AES.ECB method for encryption and decryption of data.

## Features
- Encrypts and decrypts data using AES.ECB method.
- Supports encryption and decryption of data in base64string format.
- Supports encryption and decryption of data in Object format.

## Requirements
- .NET 6
- Newtonsoft.Json
- Microsoft.Extensions.DependencyInjection

## Installation
1. Clone the repository.
```bash
git clone https://github.com/hoesein/KryptografieService.git
```

2. Navigate to the project directory.
```bash
cd KryptografieService
```

3. Restore the dependencies.
```bash
dotnet restore
```

## Usage
1. Build the project.
```bash
dotnet build
```

2. Run the project.
```bash
dotnet run
```

# Example
```csharp
﻿using Utilities.KryptografieService.Models;
using Utilities.KryptografieService.Services;

var service = new Kryptografie();
var secretKey = Guid.NewGuid().ToString();
var originalString = "Hello World";

var encryptedStr = service.EncryptString(originalString, secretKey);

Console.WriteLine($"Encrypted String: {encryptedStr}");
Console.WriteLine($"Decrypted String: {service.DecryptString(encryptedStr, secretKey)}");
```
    
## License
This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.

## Contact
- KryptografieService - [Mail](mailto:a.heinsoe.a@gmail.com)
- Project Link: [GitHub - KryptografieService](https://github.com/hoesein/KryptografieService.git)

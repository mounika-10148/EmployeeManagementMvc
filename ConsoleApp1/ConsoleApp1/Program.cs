using Microsoft.AspNetCore.Identity;
using System;

class Program
{
    static void Main()
    {
        var admin = new object(); // we just need an object of any type
        var hasher = new PasswordHasher<object>();

        Console.Write("Enter password to hash: ");
        var plainPassword = Console.ReadLine();

        var hashedPassword = hasher.HashPassword(admin, plainPassword);

        Console.WriteLine("\nGenerated Hashed Password:");
        Console.WriteLine(hashedPassword);
        // AQAAAAIAAYagAAAAECxv8lrpT4nt8I/iyy4aeXghNHmaO4OXoF0HTO1WkotJoUkBWCauyfTHjLU50Sf2eQ==
    }
}

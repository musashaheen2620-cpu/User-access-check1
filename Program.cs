class Program
{
    static void Main()
    {
        Console.Write("Username: ");
        var user = Console.ReadLine();

        Console.Write("Password: ");
        var pass = Console.ReadLine();

        Console.Write("UserId: ");
        var id = Convert.ToUInt32(Console.ReadLine());

        bool admin = id > 65536;
        bool validUser = user.Length >= 3;
        bool specialChar = pass.Contains("$") || pass.Contains("|") || pass.Contains("@");
        int minLen = admin ? 20 : 16;
        bool validPass = specialChar && pass.Length >= minLen;

        if (validUser && validPass)
            Console.WriteLine($"Access granted! Welcome {(admin ? "admin" : "user")}.");
        else
        {
            Console.WriteLine("Access denied.");
            if (!validUser) Console.WriteLine("Username too short.");
            if (!specialChar) Console.WriteLine("Password must contain $, | or @.");
            if (pass.Length < minLen) Console.WriteLine($"Password must be at least {minLen} chars.");
        }
    }
}

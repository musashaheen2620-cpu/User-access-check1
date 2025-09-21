class Program
{
    static void Main()
    {
        Console.Write("Username: ");
        string u = Console.ReadLine();

        Console.Write("Password: ");
        string p = Console.ReadLine();

        Console.Write("UserId: ");
        uint id = uint.Parse(Console.ReadLine());

        bool isAdmin = id > 65536;
        bool okUser = u.Length > 2;
        bool okPwd = (p.IndexOfAny(new[] { '$', '|', '@' }) >= 0) &&
                     (p.Length >= (isAdmin ? 20 : 16));

        if (okUser && okPwd)
        {
            Console.WriteLine("Access granted!");
            Console.WriteLine(isAdmin ? "Welcome, admin." : "Welcome, user.");
        }
        else
        {
            Console.WriteLine("Access denied.");
            if (!okUser) Console.WriteLine("Username too short.");
            if (p.IndexOfAny(new[] { '$', '|', '@' }) < 0) Console.WriteLine("Password missing $, | or @.");
            if (isAdmin && p.Length < 20) Console.WriteLine("Admin password must be ≥ 20 chars.");
            if (!isAdmin && p.Length < 16) Console.WriteLine("Password must be ≥ 16 chars.");
        }
    }
}



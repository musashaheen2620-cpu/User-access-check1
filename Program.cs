class Program
{
    static void Main()
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();

        Console.Write("Enter password: ");
        string password = Console.ReadLine();

        Console.Write("Enter userId: ");
        uint userId = uint.Parse(Console.ReadLine());

        bool userIsAdmin = userId > 65536;
        bool usernameValid = username.Length >= 3;
        bool passwordValid = (password.Contains('$') || password.Contains('|') || password.Contains('@')) &&
                             (userIsAdmin ? password.Length >= 20 : password.Length >= 16);

        if (usernameValid && passwordValid)
        {
            Console.WriteLine("Access granted!");
            Console.WriteLine(userIsAdmin ? "Welcome, administrator." : "Welcome, user.");
        }
        else
        {
            Console.WriteLine("Access denied.");
            if (!usernameValid) Console.WriteLine("Username must be at least 3 characters long.");
            if (!(password.Contains('$') || password.Contains('|') || password.Contains('@')))
                Console.WriteLine("Password must contain $, | or @.");
            if (userIsAdmin && password.Length < 20)
                Console.WriteLine("Admin password must be at least 20 characters long.");
            if (!userIsAdmin && password.Length < 16)
                Console.WriteLine("Password must be at least 16 characters long.");
        }
    }
}


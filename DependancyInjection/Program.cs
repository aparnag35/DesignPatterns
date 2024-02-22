using System;
public interface IUserRepository
{
    public void GetUser();
}
// UserRepository class
public class UserRepository: IUserRepository
{
    public void GetUser()
    {
        Console.WriteLine("Retrieving user data from the database...");
    }
}
public class UserRepository2 : IUserRepository
{
    public void GetUser()
    {
        Console.WriteLine("Retrieving user data from the xml file...");
    }
}

// UserService class with constructor injection
public class UserService
{
    private readonly IUserRepository _userRepository;

    // Constructor injection
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void GetUser()
    {
        _userRepository.GetUser();
    }
}

// Main class
class Program
{
    static void Main(string[] args)
    {
        // Create the dependency
        IUserRepository userRepository = new UserRepository();

        // Inject the dependency into the service
        UserService userService = new UserService(userRepository);
        // Use the service
        userService.GetUser();
        //Suppose we decide to change implementation, then only client code changes. service remains unchanged
        IUserRepository userRepositoryifmodified = new UserRepository2();
        UserService userServiceifmodified = new UserService(userRepositoryifmodified);
        userServiceifmodified.GetUser();

        Console.ReadLine();
    }
}

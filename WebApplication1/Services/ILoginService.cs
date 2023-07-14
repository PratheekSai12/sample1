using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface ILoginService
    {
        object UserRepo { get; }
        UserDTO Login(UserDTO user);
        UserDTO Register(UserPassDTO user);
    }
}

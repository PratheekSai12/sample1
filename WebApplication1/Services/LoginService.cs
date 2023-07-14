using System.Security.Cryptography;
using System.Text;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class LoginService : ILoginService
    {
        private readonly IRepo<string, User> _repo;
        private readonly ITokenService _tokenService;

        public LoginService(IRepo<string, User> repo, ITokenService tokenService)
        {
            _repo = repo;
            _tokenService = tokenService;
        }

        public object UserRepo => throw new NotImplementedException();

        public UserDTO Login(UserDTO user)
        {
            var myUser = _repo.GetAll().FirstOrDefault(u => u.Username == user.Username);
            if (myUser == null) return null;
            else
                try
                {
                    if (myUser != null || myUser.Status == "Active")
                    {

                        try
                        {

                            var dbPass = myUser.PasswordHash;
                            HMACSHA512 hmac = new HMACSHA512(myUser.Key);
                            var userPass = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
                            for (int i = 0; i < dbPass.Length; i++)
                            {
                                if (userPass[i] != dbPass[i])
                                    return null;
                            }
                            user.Password = null;
                            user.Token = _tokenService.CreateToken(user);
                            return user;
                        }


                        catch (Exception e)
                        {
                            throw (e);
                        }
                    }
                }
                catch (NullReferenceException e)
                {
                    throw (e);
                }

            return null;
        }

        public UserDTO Register(UserPassDTO user)
        {
            var un = _repo.GetAll().FirstOrDefault(u => u.Username == user.Username);
            if (un == null)
            {
                HMACSHA512 hmac = new HMACSHA512();
                user.Key = hmac.Key;
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
                var myUser = _repo.Add(user);
                if (myUser != null)
                    return new UserDTO
                    {
                        Username = user.Username,
                        Token = _tokenService.CreateToken(new UserDTO { Username = user.Username })

                    };
                return null;
            }
            return null;
        }
    }
}

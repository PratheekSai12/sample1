using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class UserRepo : IRepo<string, User>
    {
        private readonly AaladinContext _context;

        public UserRepo(AaladinContext context)
        {
            _context = context;
        }
        public User Add(User item)
        {
            try
            {
                _context.Users.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception)
            {

                throw;
            }
            return null;
        }

        public User Delete(string key)
        {
            throw new NotImplementedException();
        }

        public User Get(string key)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == key);
            return user;
        }

        public ICollection<User> GetAll()
        {
            if (_context.Users.Count() > 0)
                return _context.Users.ToList();
            return null;
        }

        public User Update(User item)
        {
            throw new NotImplementedException();
        }
    
    }
}

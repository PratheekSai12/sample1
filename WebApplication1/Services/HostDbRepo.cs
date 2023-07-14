using WebApplication1.Models;
using Host = WebApplication1.Models.Host;

namespace WebApplication1.Services
{
    public class HostDbRepo: IRepo<int, Host>
    {
        private readonly AaladinContext _context;

        public HostDbRepo(AaladinContext context)
        {
            _context = context;
        }
        public Host Add(Host item)
        {
            try
            {
                _context.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception e)
            {

            }
            return null;
        }

        public Host Delete(int key)
        {
            var emp = Get(key);
            if (emp != null)
            {
                try
                {
                    _context.Hosts.Remove(emp);
                    _context.SaveChanges();
                    return emp;
                }
                catch (Exception e)
                {

                    throw;
                }
            }
            return null;
        }

        public Host Get(int key)
        {
            var emp = _context.Hosts.FirstOrDefault(e => e.Id == key);
            if (emp != null)
            {
                try
                {
                    return emp;
                }
                catch (Exception e)
                {
                }
            }
            return null;
        }

        public ICollection<Host> GetAll()
        {
            var hosts = _context.Hosts.ToList();
            return hosts;
        }

        public Host Update(Host item)
        {
            var c = Get(item.Id);
            if (c != null)
            {
                try
                {
                    
                    c.ProfilePic = item.ProfilePic;
                    
                    _context.SaveChanges();
                    return c;
                }
                catch (Exception e)
                {

                    throw;
                }
            }
            return null;
        }
    }
}

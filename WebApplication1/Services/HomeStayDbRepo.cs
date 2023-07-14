using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class HomeStayDbRepo : IRepo<int, HomeStay>
    {
        private readonly AaladinContext _context;

        public HomeStayDbRepo(AaladinContext context)
        {
            _context = context;
        }
        public HomeStay Add(HomeStay item)
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

        public HomeStay Delete(int key)
        {
            var emp = Get(key);
            if (emp != null)
            {
                try
                {
                    _context.HomeStays.Remove(emp);
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

        public HomeStay Get(int key)
        {
            var emp = _context.HomeStays.FirstOrDefault(e => e.Id == key);
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

        public ICollection<HomeStay> GetAll()
        {
            var homeStays = _context.HomeStays.ToList();
            return homeStays;
        }

        public HomeStay Update(HomeStay item)
        {
            var c = Get(item.Id);
            if (c != null)
            {
                try
                {
                    c.Property_Name = item.Property_Name;
                    c.Property_Address = item.Property_Address;
                    c.Property_Contact = item.Property_Contact;
                    c.User = item.User;
                    c.NoofRooms = item.NoofRooms;
                    c.Pics = item.Pics;
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

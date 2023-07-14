using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class CustomerDbRepo : IRepo<int, Customer>
    {
        private readonly AaladinContext _context;

        public CustomerDbRepo(AaladinContext context)
        {
            _context = context;
        }
        public Customer Add(Customer item)
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

        public Customer Delete(int key)
        {
            var emp = Get(key);
            if (emp != null)
            {
                try
                {
                    _context.Customers.Remove(emp);
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

        public Customer Get(int key)
        {
            var emp = _context.Customers.FirstOrDefault(e => e.Id == key);
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

        public ICollection<Customer> GetAll()
        {
            var customers = _context.Customers.ToList();
            return customers;
        }
        public Customer Update(Customer item)
        {
            var c = Get(item.Id);
            if (c != null)
            {
                try
                {
                    c.Name = item.Name;
                    c.DateOfBirth = item.DateOfBirth;
                    c.Email = item.Email;
                    c.ContactNumber = item.ContactNumber;
                    c.User = item.User;
                    c.ProfilePic = item.ProfilePic;
                    c.Gender = item.Gender;
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

using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class QuestionaryDbRepo : IRepo<int, Questionary>
    {
        private readonly AaladinContext _context;
        public QuestionaryDbRepo(AaladinContext context)
        {
            _context = context;
        }
        public Questionary Add(Questionary item)
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

        public Questionary Delete(int key)
        {
            var emp = Get(key);
            if (emp != null)
            {
                try
                {
                    _context.Questionaries.Remove(emp);
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

        public Questionary Get(int key)
        {
            var emp = _context.Questionaries.FirstOrDefault(e => e.Id == key);
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

        public ICollection<Questionary> GetAll()
        {
            var Questionaries = _context.Questionaries.ToList();
            return Questionaries;
        }

        public Questionary Update(Questionary item)
        {
            var c = Get(item.Id);
            if (c != null)
            {
                try
                {
                    c.About = item.About;
                    c.Passionate = item.Passionate;
                    c.Hobbies = item.Hobbies;
                    c.Accomplishment = item.Accomplishment;
                    c.Life = item.Life;
                    c.Personal_Expertise = item.Personal_Expertise;
                    c.Professional_Expertise = item.Professional_Expertise;
                    c.Whats_Life = item.Whats_Life;
                    c.Travel = item.Travel;
                    c.Offer = item.Offer;
                    c.Kindof_Guests = item.Kindof_Guests;
                    c.Greatest_Impact = item.Greatest_Impact;
                    c.Cherished_Memories = item.Cherished_Memories;
                    c.Pictures = item.Pictures;
                    c.Journer_Destination = item.Journer_Destination;
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

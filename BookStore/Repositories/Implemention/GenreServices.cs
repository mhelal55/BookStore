using BookStore.Models;
using BookStore.Models.Domain;
using BookStore.Repositories.Abstract;

namespace BookStore.Repositories.Implemention
{
    public class GenreServices : IGenreServices
    {
        private readonly DataBaseContext _context;

        public GenreServices(DataBaseContext context)
        {
            _context = context;
        }

        public bool Add(Genre model)
        {
            try
            {
                _context.Genres.Add(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var data = _context.Genres.Find(id);     
                if (data == null)
                {
                    return false;
                }
                _context.Genres.Remove(data);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public Genre FindById(int id)
        {
           
                return _context.Genres.Find(id);
           
        }

        public IEnumerable<Genre> GetAll()
        {
            return _context.Genres.ToList();
        }

        public bool Update(Genre model)
        {
            try
            {
                _context.Genres.Update(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}

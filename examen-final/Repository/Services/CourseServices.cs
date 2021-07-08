using System.Collections.Generic;
using System.Linq;
using AppUCA.Context;
using AppUCA.Entities;

namespace AppUCA.Repository.Services
{
    public class CourseServices : IRepository<Course>
    {
        private AppGuiContext _context;

        public CourseServices()
        {
            _context = new AppGuiContext();
        }
        
        public List<Course> GetAll()
        {
            return _context.Courses.ToList(); 
        }

        public void Create(Course item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public void Delete(Course item)
        {
            _context.Remove(item);
            _context.SaveChanges();
        }

        public void Update(Course item)
        {
            _context.Update(item);
            _context.SaveChanges();
        }
    }
}
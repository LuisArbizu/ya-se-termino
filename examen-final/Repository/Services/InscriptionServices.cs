using System.Collections.Generic;
using System.Linq;
using AppUCA.Context;
using AppUCA.Entities;

namespace AppUCA.Repository.Services
{
    public class InscriptionServices : IRepository<Inscription>
    {
        private AppGuiContext _context;

        public InscriptionServices()
        {
            _context = new AppGuiContext();
        }
        
        public List<Inscription> GetAll()
        {
            return _context.Inscriptions.ToList(); 
        }

        public void Create(Inscription item)
        {
            _context.Add(item);
            _context.SaveChanges();
        }

        public void Delete(Inscription item)
        {
            _context.Remove(item);
            _context.SaveChanges();
        }

        public void Update(Inscription item)
        {
            _context.Update(item);
            _context.SaveChanges();
        }
    }
}
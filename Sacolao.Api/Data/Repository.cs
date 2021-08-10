using Microsoft.EntityFrameworkCore;
using Sacolao.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sacolao.Api.Data
{
    public class Repository : IRepository
    {
        private readonly SacolaoContext _context;

        public Repository(SacolaoContext context)
        {
            _context = context;
        }

        public void Add<T>(T item) where T : class
        {
            _context.Add(item);
        }

        public void Update<T>(T item) where T : class
        {
            _context.Update(item);
        }

        public void Delete<T>(T item) where T : class
        {
            _context.Remove(item);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public List<Fruta> GetAllFrutas()
        {
            IQueryable<Fruta> query = _context.Frutas;
            query = query.AsNoTracking().OrderBy(a => a.Nome);
            return query.ToList();
        }

        public List<Fruta> GetFrutaByName(string nome)
        {
            IQueryable<Fruta> query = _context.Frutas;
            
            if (!String.IsNullOrEmpty(nome))
                query = query.Where(a => a.Nome.ToUpper().Contains(nome.ToUpper()));

            query = query.AsNoTracking().OrderBy(a => a.Nome);
            return query.ToList();
        }

        public Fruta GetFrutaById(int frutaId)
        {
            IQueryable<Fruta> query = _context.Frutas;

            query = query.AsNoTracking()
                .OrderBy(a => a.Nome)
                .Where(b => b.Id == frutaId);

            return query.FirstOrDefault();
        }

    }
}

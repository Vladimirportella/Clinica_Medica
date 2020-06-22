using ClinicaMedica.Domain.Contracts.Repositories;
using ClinicaMedica.Infra.Data.DataContexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ClinicaMedica.Infra.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected DataContext DataContext;

        public BaseRepository(DataContext dataContext)
        {
            DataContext = dataContext;
        }

        public void Alterar(T obj)
        {
            DataContext.Entry(obj).State = EntityState.Modified;
            DataContext.SaveChanges();
        }

        public List<T> Consultar()
        {
            return DataContext.Set<T>().ToList();
        }

        public void Excluir(T obj)
        {

            DataContext.Entry(obj).State = EntityState.Deleted;
            DataContext.SaveChanges();
        }

        public void Inserir(T obj)
        {

            DataContext.Entry(obj).State = EntityState.Added;
            DataContext.SaveChanges();
        }

        public T ObterPorId(int id)
        {
            return DataContext.Set<T>().Find(id);
        }
    }
}

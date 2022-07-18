using Microsoft.EntityFrameworkCore;
using Proyecto.Ecommerce.Dominio.Repositorio;
using Proyecto.Ecommerce.Infraestructura.Context;

namespace Proyecto.Ecommerce.Infraestructura.Repositorio
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class
    {
        private readonly EcommerceDbContext context;

        public RepositorioGenerico(EcommerceDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(T Entity)
        {
            await context.Set<T>().AddAsync(Entity);
            await context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(T Entity)
        {

            context.Set<T>().Remove(Entity);
            await context.SaveChangesAsync();
            return true;

        }

        public async Task<ICollection<T>> GetAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(string Id)
        {

            return await context.Set<T>().FindAsync(Id);
        }

        public async Task<T> GetByIdAsync(Guid Id)
        {
            return await context.Set<T>().FindAsync(Id);
        }

        public async Task UpdateAsync(T Entity)
        {
            context.Set<T>().Update(Entity);
            await context.SaveChangesAsync();
        }

        public IQueryable<T> GetQueryable()
        {
            return context.Set<T>().AsQueryable();
        }
    }
}

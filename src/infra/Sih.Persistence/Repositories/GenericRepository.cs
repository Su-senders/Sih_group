using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using Sih.Domain.Interfaces;
using Sih.Persistence.Configurations;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;


namespace Sih.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericDomain<T>, IDisposable where T : class
    {
        private readonly DbContextOptions<SihDbContext> _OptionsBuilder;

        public GenericRepository()
        {
            _OptionsBuilder = new DbContextOptions<SihDbContext>();
        }

        public async Task Ajouter(T entity)
        {
            using var fabrique = new SihDbContext(_OptionsBuilder);

            await fabrique.Set<T>().AddAsync(entity);
            await fabrique.SaveChangesAsync();
        }

        public async  Task<List<T>> GetAll()
        {
            using var fabrique = new SihDbContext(_OptionsBuilder);
            return await fabrique.Set<T>().AsNoTracking().ToListAsync();
        }

        public async  Task<T> GetById(int Id)
        {
            using var fabrique = new SihDbContext(_OptionsBuilder);
            return await fabrique.Set<T>().FindAsync(Id);
        }

        public async Task Modifier(T entity)
        {
            using var fabrique = new SihDbContext(_OptionsBuilder);
             fabrique.Set<T>().Update(entity);
            await fabrique.SaveChangesAsync();
        }

        public async Task Supprimer(T entity)
        {
            using var fabrique = new SihDbContext(_OptionsBuilder);
            fabrique.Set<T>().Remove(entity);
            await fabrique.SaveChangesAsync();
        }

        #region Disposed
        bool disposed = false;

        readonly SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        //Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
            }
            disposed = true;
        }

        #endregion
    }

}


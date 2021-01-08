using APesquisa.Data.Repository;
using APesquisa.Repository;
using System;

namespace APesquisa.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly APesquisaContext _context = new APesquisaContext();

        public UnitOfWork()
        {
            Component = new ComponentRepsoitory(_context);
        }

        public IComponentRepsoitory Component { get; set; }

        private bool _disposed;

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Clear(true);
            GC.SuppressFinalize(this);
        }

        private void Clear(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        ~UnitOfWork()
        {
            Clear(false);
        }
    }
}


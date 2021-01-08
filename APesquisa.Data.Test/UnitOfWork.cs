using APesquisa.Data.Repository;
using APesquisa.Data.Test.Repository.ProhibitedComponents;

namespace APesquisa.Data.Test
{
    public class UnitOfWork
    {
        private readonly APesquisaContext _context = new APesquisaContext();

        public UnitOfWork()
        {
            Component = new ComponentRepository(_context);
        }

        public IComponentRepository Component { get; private set; }
    }
}

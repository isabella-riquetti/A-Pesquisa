using APesquisa.Data.Repository;
using APesquisa.Data.Repository.Base;

namespace APesquisa.Data.Test.Repository.ProhibitedComponents
{
    public class ComponentRepository : RepositoryBase<Models.Component>, IComponentRepository
    {
        private readonly APesquisaContext _context;

        public ComponentRepository(APesquisaContext context) : base(context)
        {
            _context = context;
        }
    }
}

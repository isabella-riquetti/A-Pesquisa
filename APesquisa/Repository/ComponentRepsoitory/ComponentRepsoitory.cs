using APesquisa.Data.Repository;
using APesquisa.Data.Repository.Base;

namespace APesquisa.Repository
{
    public class ComponentRepsoitory : RepositoryBase<Data.Models.Component>, IComponentRepsoitory
    {
        private readonly APesquisaContext _context;

        public ComponentRepsoitory(APesquisaContext context) : base(context)
        {
            _context = context;
        }
    }
}
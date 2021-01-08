using APesquisa.Repository;

namespace APesquisa.UnitOfWork
{
    public interface IUnitOfWork
    {
        IComponentRepsoitory Component { get; set; }
        void Commit();
    }
}

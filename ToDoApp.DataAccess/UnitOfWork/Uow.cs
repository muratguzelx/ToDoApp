using System.Threading.Tasks;
using ToDoApp.DataAccess.Contexts;
using ToDoApp.DataAccess.Interfaces;
using ToDoApp.DataAccess.Repositories;
using ToDoApp.Entities.Domains;

namespace ToDoApp.DataAccess.UnitOfWork
{
    public class Uow : IUow
    {
        readonly private ToDoContext _context;

        public Uow(ToDoContext toDoContext)
        {
            _context = toDoContext;
        }

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(_context);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}

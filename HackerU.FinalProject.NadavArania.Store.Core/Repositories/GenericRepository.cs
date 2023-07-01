using HackerU.FinalProject.NadavArania.Store.Db.Context;

namespace HackerU.FinalProject.NadavArania.Store.Core.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        //Generic Repository With Crud And Get's Functions
        protected readonly StoreContext Db;

        public GenericRepository(StoreContext db)
        {
            Db = db;
        }

        public void Add(T entity)
        {
            Db.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            Db.Set<T>().Remove(entity);
        }

        public T GetById(int id)
        {
            return Db.Set<T>().Find(id);
        }

        public List<T> GetList()
        {
            return Db.Set<T>().ToList();
        }

        public void Update(T entity)
        {
            Db.Set<T>().Update(entity);
        }
    }
}

using System.Reflection;
using System.Text;

namespace CatalogueMvc.App.Services.Repositories
{
    public class InMemoryRepository<T> : IRepository<T> where T : class
    {
        private Dictionary<int, T> _store = new();
        private int _currentId = 1;
        private PropertyInfo _idProp;

        public InMemoryRepository()
        {
            Type type = typeof(T);
            var id = type.GetProperty("Id");
            if(id == null || id.PropertyType != typeof(int))
            {
                throw new ArgumentException("T doit exposer une propriété publique int Id");
            }
            _idProp = id;
        }
        public bool Add(T entity)
        {
            object? raw = _idProp.GetValue(entity);
            int id = raw == null ? 0 : Convert.ToInt32(raw);

            if (id == 0)
            {
                id = _currentId++;
                _idProp.SetValue(entity, id);
            }
            else
            {
                if (_store.ContainsKey(id))
                {
                    return false;
                }

                _currentId = Math.Max(_currentId, id + 1);
            }

            _store[id] = entity;
            return true;
        }

        public T? GetById(int id)
        {
            return _store.TryGetValue(id, out var value) ? value : null;
        }

        public IEnumerable<T> ListAll()
        {
            return _store.Values.ToList();
        }

        public bool Remove(int id)
        {
            return _store.Remove(id);
        }

        public bool Update(T entity)
        {
            object? raw = _idProp.GetValue(entity);

            int id = raw == null ? 0 : Convert.ToInt32(raw);
            if (id == 0)
            {
                return false;
            }
            else if (_store.ContainsKey(id))
            {
                _store[id] = entity;

                return true;
            }
            return false;
        }
    }
}

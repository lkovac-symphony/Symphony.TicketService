using System;
using System.Collections.Generic;
using Symphony.TicketService.Models;

namespace Symphony.TicketService.Storage
{
    public class Repository : IRepository
    {
        private readonly Dictionary<Type, Dictionary<Guid, Entity>> storage;

        public Repository()
        {
            storage = new Dictionary<Type, Dictionary<Guid, Entity>>();
        }

        public T Get<T>(Guid id) where T : Entity
        {
            return storage.ContainsKey(typeof(T))
                ? storage[typeof(T)][id] as T
                : throw new KeyNotFoundException();
        }

        public void Add<T>(T entity) where T : Entity
        {
            if (!storage.ContainsKey(typeof(T))) storage.Add(typeof(T), new Dictionary<Guid, Entity>());

            storage[typeof(T)].Add(entity.Id, entity);
        }

        public Guid Delete<T>(T entity) where T : Entity
        {
            if (!storage.ContainsKey(typeof(T))) throw new KeyNotFoundException();

            storage[typeof(T)].Remove(entity.Id);
            return entity.Id;
        }
    }

    public interface IRepository
    {
        T Get<T>(Guid id) where T : Entity;
        void Add<T>(T entity) where T : Entity;
        Guid Delete<T>(T entity) where T : Entity;
    }
}
using Domain.Data;
using Domain.Repositories.Classes;
using Domain.Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Linq;

namespace Services.Classes
{
    internal class BaseService<T> : IBaseService<T> where T : class
    {
        private static IUnitOfWork unitOfWork;
        private BaseRepository<T> _repository;

        public BaseService(MeuDataContext context)
        {
            unitOfWork = context;

            _repository = new BaseRepository<T>(unitOfWork);
        }

        public T Find(int id)
        {
            try
            {
                return _repository.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IQueryable<T> List()
        {
            try
            {
                return _repository.List();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Add(T item)
        {
            try
            {
                _repository.Add(item);
                unitOfWork.Save();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Remove(T item)
        {
            try
            {
                _repository.Remove(item);
                unitOfWork.Save();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Edit(T item)
        {
            try
            {
                _repository.Edit(item);
                unitOfWork.Save();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
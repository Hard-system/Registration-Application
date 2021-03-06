﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;

namespace ACCDataStore.Repository.Impl
{
    public class BaseRepositoryImpl : IBaseRepository
    {
        private ISession session;
        public BaseRepositoryImpl(ISession session)
        {
            this.session = session;
        }
        public IList<T> FindAll<T>() where T : class
        {
            return this.session.CreateCriteria<T>().List<T>();
        }

        public T FindById<T>(object id)
        {
            return this.session.Load<T>(id);
        }

        public T GetById<T>(object id)
        {
            return this.session.Get<T>(id);
        }

        public IList<T> Find<T>(string queryString, string[] names, object[] values)
        {
            var query = this.session.CreateQuery(queryString);
            for (var i = 0; i < names.Length; i++)
            {
                query.SetParameter(names[i], values[i]);
            }
            return query.List<T>();
        }

        public object FindUniqueResult<T>(string queryString, string[] names, object[] values)
        {
            var query = this.session.CreateQuery(queryString);
            for (var i = 0; i < names.Length; i++)
            {
                query.SetParameter(names[i], values[i]);
            }
            return query.UniqueResult();
        }

        public IList<object[]> FindByNativeSQL(string queryString)
        {
            return this.session.CreateSQLQuery(queryString).List<object[]>();
        }

        public IList<object> FindSingleColumnByNativeSQL(string queryString)
        {
            return this.session.CreateSQLQuery(queryString).List<object>();
        }

        public void SaveOrUpdate<T>(T entity)
        {
            this.session.SaveOrUpdate(entity);
        }

        public void Merge<T>(T entity) where T : class
        {
            this.session.Merge<T>(entity);
        }

        public void Delete<T>(T entity)
        {
            this.session.Delete(entity);
        }

        public int UpdateByNativeSQL(string updateQueryString)
        {
            return this.session.CreateSQLQuery(updateQueryString).ExecuteUpdate();
        }
    }
}

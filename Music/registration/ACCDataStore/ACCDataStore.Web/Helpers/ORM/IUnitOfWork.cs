using System;

namespace ACCDataStore.Web.Helpers.ORM
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace DAL.Repository
{
    public class UnitOfWork : IDisposable
    {
        public DatabaseContext context = new DatabaseContext();
        private Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        // private GenericRepository<TeamMembers> TeamMembers;






        //======================custom repository====================//
        private SPRepository spRepository;
        public SPRepository SPRepository
        {
            get
            {

                if (this.spRepository == null)
                {
                    this.spRepository = new SPRepository(context);
                }
                return spRepository;
            }
        }
        //====================end of custom repository==================//

       
        //======================custom repository====================//
        private CustomRepository customRepository;
        public CustomRepository CustomRepository
        {
            get
            {

                if (this.customRepository == null)
                {
                    this.customRepository = new CustomRepository(context);
                }
                return customRepository;
            }
        }
        //====================end of custom repository==================//


        //=====================Generic Repositories =====================//

        public GenericRepository<TEntity> Repositories<TEntity>() where TEntity : class, new()
        {
            if (repositories.Keys.Contains(typeof(TEntity)) == true)
                return (GenericRepository<TEntity>)repositories[typeof(TEntity)];
            GenericRepository<TEntity> tRepositoryObject = new GenericRepository<TEntity>(context);
            repositories.Add(typeof(TEntity), tRepositoryObject);
            return tRepositoryObject;
        }


        //==============================end===============================//


        public void Save()
        {
            try
            {
                context.SaveChanges();
            } catch(Exception ex)
            {
                
                throw ex;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
using Buisness.DAL.Repositories;
using Data.DAL;
using System.Data.Entity;

namespace Buisness.DAL.UnitOfWork
{
    class UnitOfWork
    {
        private readonly DbContext Context;

        //public Repositories
        public MessageRepository Messages { get; }


        public UnitOfWork()
        {
            this.Context = new tradehubEntities();

            this.Messages = new MessageRepository( this.Context );
        }

        int Complete()
        {
            return this.Context.SaveChanges();
        }
    }
}

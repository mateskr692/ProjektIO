using System;
using System.Data.Entity;

namespace Data.DAL
{
    public class UnitOfWork : IDisposable
    {
        private readonly DbContext Context;

        //public Repositories
        public MessageRepository Messages { get; }
        public CommunityRepository Communities { get; }
        public UserRepository Users { get; }


        public UnitOfWork()
        {
            this.Context = new tradehubEntities();

            this.Messages = new MessageRepository( this.Context );
            this.Communities = new CommunityRepository( this.Context );
            this.Users = new UserRepository( this.Context );
        }

        public int Complete()
        {
            return this.Context.SaveChanges();
        }

        public void Dispose()
        {
            this.Context.Dispose();
        }
    }
}

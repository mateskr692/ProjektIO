using Common.Enums;
using Common.Extensions;
using Common.Filters;
using Data.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.DAL.Repositories
{
    internal class MessageRepository : BaseRepository<Message, MessageFilters, MessageSorting>
    {
        public MessageRepository( DbContext context ) : base( context )
        {
        }


        public override IEnumerable<Message> GetPage( int pageSize, int pageNumber, MessageFilters filters )
        {
            IQueryable<Message> messages = this.dbSet;

            if (filters != null)
            {
                //Filtering
                if ( !string.IsNullOrEmpty( filters.Title ) )
                {
                    messages = messages.Where( m => m.Title.Like( filters.Title ) );
                }
                if ( !string.IsNullOrEmpty( filters.SenderName ) )
                {
                    messages = messages.Where( m => m.Sender.Login.Like( filters.SenderName ) );
                }
                if ( filters.SendDate.HasValue )
                {
                    messages = messages.Where( m => m.SendDate == filters.SendDate );
                }

                //Pageination
                switch ( filters.SortingColumn )
                {
                    case MessageSorting.Title:
                        messages = filters.Order == SortingOrder.Ascending ? messages.OrderBy( m => m.Title ) : messages.OrderByDescending( m => m.Title );
                        break;

                    case MessageSorting.SendDate:
                        messages = filters.Order == SortingOrder.Ascending ? messages.OrderBy( m => m.SendDate ) : messages.OrderByDescending( m => m.SendDate );
                        break;

                    case MessageSorting.SenderName:
                        messages = filters.Order == SortingOrder.Ascending ? messages.OrderBy( m => m.Sender.Login ) : messages.OrderByDescending( m => m.Sender.Login );
                        break;
                }
            }

            return messages.Skip( pageSize * (pageNumber - 1) )
                           .Take( pageSize )
                           .AsEnumerable();
        }
    }
}

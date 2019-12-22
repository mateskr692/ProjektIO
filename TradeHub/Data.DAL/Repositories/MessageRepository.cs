using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common.Extensions;
using Common.Filters;

namespace Data.DAL
{
    public class MessageRepository : BaseRepository<Message, MessageFilters, MessageSorting>
    {
        public MessageRepository( DbContext context ) : base( context )
        {
        }


        public override IDictionary<long, string> GetDictionary()
        {
            var messagesDictionary = new Dictionary<long, string>();
            foreach ( var message in this.dbSet )
            {
                messagesDictionary.Add( message.Id, message.Title );
            }

            return messagesDictionary;

        }


        public override IDictionary<long, string> GetFilteredDictionary( MessageFilters filters )
        {
            IQueryable<Message> messages = this.dbSet;
            var messagesDictionary = new Dictionary<long, string>();

            if ( filters != null )
            {
                //Filtering
                if ( !string.IsNullOrEmpty( filters.Title ) )
                {
                    messages = messages.Where( it => it.Title.ToUpper().Contains( filters.Title.ToUpper() ) );
                }
                if ( !string.IsNullOrEmpty( filters.SenderName ) )
                {
                    messages = messages.Where( it => it.Sender.Login.ToUpper().Contains( filters.SenderName.ToUpper() ) );
                }
                if ( filters.SendDate.HasValue )
                {
                    messages = messages.Where( it => it.SendDate == filters.SendDate );
                }
            }
            
            foreach ( var message in messages )
            {
                messagesDictionary.Add( message.Id, message.Title );
            }

            return messagesDictionary;
        }


        public override IEnumerable<Message> GetPage( MessageFilters filters )
        {
            IQueryable<Message> messages = this.dbSet;

            if ( filters != null )
            {
                //Filtering
                if ( !string.IsNullOrEmpty( filters.Title ) )
                {
                    messages = messages.Where( it => it.Title.ToUpper().Contains( filters.Title.ToUpper() ) );
                }
                if ( !string.IsNullOrEmpty( filters.SenderName ) )
                {
                    messages = messages.Where( it => it.Sender.Login.ToUpper().Contains( filters.SenderName.ToUpper() ) );
                }
                if ( filters.SendDate.HasValue )
                {
                    messages = messages.Where( it => it.SendDate == filters.SendDate );
                }

                //Sorting
                switch ( filters.SortingColumn )
                {
                    case MessageSorting.Title:
                        messages = filters.Order == SortingOrder.Ascending ? messages.OrderBy( it => it.Title ) : messages.OrderByDescending( it => it.Title );
                        break;

                    case MessageSorting.SendDate:
                        messages = filters.Order == SortingOrder.Ascending ? messages.OrderBy( it => it.SendDate ) : messages.OrderByDescending( it => it.SendDate );
                        break;

                    case MessageSorting.SenderName:
                        messages = filters.Order == SortingOrder.Ascending ? messages.OrderBy( it => it.Sender.Login ) : messages.OrderByDescending( it => it.Sender.Login );
                        break;
                }
            }

            //Paginations
            return messages.Skip( filters.PageSize * ( filters.PageNumber - 1 ) )
                           .Take( filters.PageSize )
                           .AsEnumerable();
        }
    }
}

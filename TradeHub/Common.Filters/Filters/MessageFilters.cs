using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Filters
{
    //filtry dla wiadomosci, automatycznie generowane po interfejscie daja tylko sortowanie i stronnicowanie
    //jak chcemy filtrowac np po nadawcy albo dacie wyslania to trzeba tu dodac wlasne pola
    //jesli nie chcemy filtrowac po danym polu to zostawiamy je jako null
    //uwaga: typy proste ktore sa na stosie i nie mogą być nullem muszą być nulowalne ( znak zapytania po typie )
    public class MessageFilters : IFiltrable<MessageSorting>
    {
        //automatyczne po implementacji interfejsu
        public MessageSorting SortingColumn { get; set; }
        public SortingOrder Order { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }

        //wlsane filtry
        public DateTime? SendDate { get; set; }
        public string Title { get; set; }
        public string SenderName { get; set; }
    }
}

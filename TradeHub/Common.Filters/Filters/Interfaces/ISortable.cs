using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Filters
{
    //interfejs mowiacy w jakis posob sortowac dane
    //wartosc enuma mowi po jakim polu tabeli sortowac, a order w jakim kierunku
    //kazda tabela ma inne kolumny, po nie ktorych mozna sortowac po innych nie 
    //dlatego dla kazdej klasy mamy enum ktory mowi po jakich polach mozna sortowac i repozytorium patrzac na ta wartosc konstruuje odpowiednie polecenie
    //daje to segregacje ze wysylajac dane z przegladarki wysylamy tylko jakas wartosc pola i nic nie wiemy o samym modelu bazy danych
    public interface ISortable<TSorting>
        where TSorting : Enum
    {
        TSorting SortingColumn { get; set; }
        SortingOrder Order { get; set; }
    }
}

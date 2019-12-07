using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Filters
{
    //interfejs mowiacy o tym w jakis sposob filtrowac otrzymywane dane
    //nic w sobie nei zawiera a jedynie dziedziczy po to by w juz prawdziwej klasie do filtrowania dziedziczyc tylko po jednym interfejsie (wygodniej)
    //filtrowanie oznacza podanie kolumny i kierunku sortowania, podanie strony i jej rozmiaru oraz w samej klasie mozna dodac pola po ktorych filtrowac dane (np data, nr spolecznosci itp)
    public interface IFiltrable<TSorting> : ISortable<TSorting>, IPageable
        where TSorting : Enum
    {
    }
}

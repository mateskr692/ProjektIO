using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Filters
{
    //interfejs mowiacy o tym w jakis sposob stronnicowac dane
    //rozmiar strony oraz jej numer
    public interface IPageable
    {
        int PageSize { get; set; }
        int PageNumber { get; set; }
    }
}

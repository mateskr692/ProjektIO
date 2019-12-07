using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Contracts.Models
{
    //model zawiera wszsytkie informacje z klasy z DAL, jest wykorzystywaniu przy dodawaniu, edycji (operacje z CRUD po stronie przegladarki)
    //nie chcemy bezposrednio operowac w przegladarce na modelach dal bo mozna latwo i niechcianie stworzyc nadmiarowe modele, zepsuc baze
    //te modele sąwalidowane a nastepnie mapowane na modele z DAL - zapewniaja integralnosc bazy i chronia przed atakami
    class MessageModel
    {
    }
}

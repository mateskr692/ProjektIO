using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buisness.Contracts.Models
{
    //InfoModel zawiera tylko niezbedne pola do pokazania przy wyswietlaniu wuelu na raz
    //Dla operacji z przegladania np w tabelce wszystkich wiadomosci chcemy tylko kilka pol i nie trzeba wysylac internetem calcyh kilkutysiecy znakow wiadomosci
    // Model - tworzenie edycja modeli w przegladarce, pelne informacje
    // InfoModel - przegladanie wielu istniejacych modeli, minimalne informacje
    // Slownik - tworzenie SelectListy gdzie potrzeba tylko Id ale chcemy pokazac jakis tekst zamist id np. nazwe
    class MessageInfoModel
    {
    }
}

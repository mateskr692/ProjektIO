using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    //rozne operacje  tj. wysylanie ofert wiadomosci i zaproszen powinno generowac powiadomienie dla uzytkownika
    //zamiast dawac wiele wezlow referencyjnych i potem za kazdym razem sprawdzac czy istnieje w bazie powiadomienie, 
    //przy tworzeniu tych rzeczy bedzie wywolywany stored procedure z bazy danych do generowania powiadomien
    //po przeczytaniu powiadomienie bedzie usuwane wiec nie trzeba ich filtrowac itp
    public enum NotificationType
    {
        NewOffert,
        NewMessage,
        AcceptedOffert,
        BannedFromCommunity,
        //add more if needeed
    }
}

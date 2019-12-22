using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Filters;

namespace Web.Portal.Models
{
    //Index model jest pokazywany na glownej stronie i mozna wyswietlic wszystkich uzytkownikow, filtrowac sortowac i kliknac na kazdego by zobaczyc jego profil
    //potrzebne Id w InfoModel by moc przejsc do odpowiedniej strony
    public class ToolIndexViewModel
    {
        public ToolFilters Filters { get; set; }
        public List<ToolInfoViewModel> Tools { get; set; }
    }
}

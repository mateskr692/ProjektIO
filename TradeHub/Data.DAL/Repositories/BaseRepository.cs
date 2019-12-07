using Common.Enums;
using Common.Filters;
using Data.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL
{
    //bazowa klasa generyczna, umozliwia dodawanie usuwanie elementow jednak trzeba przeciazyc kilka metod w implementacji
    //zamykamy wszystkie operacje zwiazane z dostepem do bazy w repozytorium a repozytoria trzymamy w UnitOfWork
    //dobry wzorzec + ulatwia testowanie
    public abstract class BaseRepository<TModel, TFilters, TSorting> 
        where TModel : class
        where TFilters : IFiltrable<TSorting>
        where TSorting : Enum
    {
        #region Private Fields

        protected readonly DbSet<TModel> dbSet;
        protected readonly DbContext context;

        #endregion

        #region Ctors

        public BaseRepository( DbContext context )
        {
            this.context = context;
            this.dbSet = context.Set<TModel>();
        }

        #endregion

        #region Abstract Methods
        //dla przypadkow gdy przegladamy np spolecznosci i chcemy stronnicowanie ale wszystkie dostepne informacje
        public abstract IEnumerable<TModel> GetPage( TFilters filters );

        //dla przypadku gdy chcemy tylko ID zeby stworzyc np. SelectListe w HTMLu i nie chcemy obciazac sieci wysylajac wszystkie inne pola niz bedzie widoczne w nazwie
        //Repozytoria moga byc wykorzystywane przez rozne serwisy i to ze UserRepository ma GetPaged nie znaczy ze UserServis musi miec usluge GetDictionary
        //np. CommunityService moze uzyc UserRepository by zdobyc slownik wszystkich uzytkownikow jakich posiada
        public abstract IDictionary<long, string> GetDictionary();

        //to samo co wyzej ale gdy chcemy przefiltrowac, np wiadomosci ale tylko od uzytkownika
        //chcemy slownik czyli wszystkie wartosci, dlatego patrzymy tylko na pola z klasy do rpzefiltrowania i ingorujemy sortowanie, stronnicowanie
        public abstract IDictionary<long, string> GetFilteredDictionary( TFilters filters );

        #endregion

        #region Public Methods

        //
        public void Add( TModel entity )
        {
            this.dbSet.Add( entity );
        }

        public void AddRange( IEnumerable<TModel> entities )
        {
            this.dbSet.AddRange( entities );
        }

        public TModel GetById(long Id)
        {
            return this.dbSet.Find( Id );
        }

        public void Remove( TModel entity )
        {
            this.dbSet.Remove( entity );
        }

        public void RemoveRange( IEnumerable<TModel> entities )
        {
            this.dbSet.RemoveRange( entities );
        }

        #endregion
    }
}

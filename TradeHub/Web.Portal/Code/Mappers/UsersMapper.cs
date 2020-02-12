using AutoMapper;
using Buisness.Contracts.Models;
using Web.Portal.Models;

namespace Web.Portal.Code
{
    //klasy ..ViewModel sa wykorzystywane tylko w warstwie MVC (GUI layer) a serwisy wykorzystują własne ..Model
    //ViewModele zaiweraja dodatkowe selectlisty, returnURL i inne, Modele to jest minimum jakie jest potrzebne od serwisu
    //mozna by wykorzystac dziedziczenie ale bylaby zabawa w dodawanie atrybutow dla pol z klasy bazowej
    //w warstwie MVC mozna dodac atrybuty np [Required] ktore automarycznie beda walidowane w przegladarce przez jQuery i w controlerze w model.IsValid
    //najjlepiej miec osobne klasy i przekopiowwac pola ktore potrzeba - dobry wzorzec
    //zeby nie kopiowac recznie wszystkich pol mozna wykorzystac Mapper ktory przez refleksje bierze pola o tych samych nazwach i przepisuje wartosci
    // (mozna rowniez podac zrodlo mapowania dla pola, zakazac mapowania itp.)
    //annotacje sa fajne ale po stronie serwisu i tak trzreba bedzie wywolac metode walidatora zeby sprawdzic czy jest ok (moze nie byc jak ktos inny podepnie sie pod nasz serwis, 
    //architektura warstwowa daje taka zalete ze jabysmy chcieli zrobic apke desktopowa to DAL, Serwisy zostaja takie same trzeba dodac tylko nową warste GUI )
    public class UsersMapper
    {
        internal static IMapper Default = new MapperConfiguration( cfg =>
        {
            //              source                  destination
            cfg.CreateMap<UserRegisterViewModel, UserRegisterModel>();
            cfg.CreateMap<UserLoginViewModel, UserLoginModel>();

            cfg.CreateMap<UserModel, UserViewModel>();
            cfg.CreateMap<UserViewModel, UserModel>();

            cfg.CreateMap<UserInfoModel, UserInfoViewModel>();
            cfg.CreateMap<UserIndexModel, UserIndexViewModel>();

        } ).CreateMapper();
    }
}
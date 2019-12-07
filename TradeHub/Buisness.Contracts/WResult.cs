using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;

namespace Buisness.Contracts
{
    //serwisy wykonuja polecenia, np dodaj do bazy i moglyby zwracac zwykly void
    //ale co w przypadku gdy np nie bedzie polaczenia do bazy? albo logujemy uzytkownika gdzie model bedzie Valid ale moze nie istniec taki w bazie?
    //co zwracac? zwykly bool UdaloSię? co jak chcemy oprocz tego jakies dane, albo wyswietlic co poszlo nie tak w logowaniu oprocz "ups nie udalo sie"
    //co jak chcemy cos zwrocic nawet jak sie nie uda, np jakas wartosc domyslna?
    //serwisy zwracaja WResult (Web Result), Valid - czy sie udalo i jak bedzie false to opcjonalnie jakies bledy w polu Error
    //jak chcemy oprocz tego jakies dane to mamy klase generyczna ktora bedzie zawierac odpowiedni model zwracany
    public class WResult
    {
        public ValidationStatus Status { get; set; }
        public IEnumerable<string> Errors { get; set; }

        public WResult( ValidationStatus status, string error )
        {
            this.Status = status;
            this.Errors = new string[] { error };
        }

        public WResult(ValidationStatus status, IEnumerable<string> errors = null)
        {
            this.Status = status;
            this.Errors = errors;
        }
    }

    public class WResult<TData> : WResult
        where TData : class
    {
        public TData Data { get; set; }

        public WResult( ValidationStatus status, IEnumerable<string> errors = null, TData data = null ) : base(status, errors)
        {
            this.Data = data;
        }

        public WResult( ValidationStatus status, string error ) : base(status, error)
        {
            this.Data = null;
        }
    }
}

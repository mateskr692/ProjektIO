using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    //dodawanie wlasnych metod do istniejacych klas
    public static class StringExtension
    {
        /// <summary>
        /// Returns value indicating wether specified substring occurs within this string. Is not case sensitive
        /// </summary>
        /// <param name="value">The string to seek</param>
        /// <returns></returns>
        public static bool Like( this string ob, string value )
        {
            //przy filtorwaniu np spolecznosci chcemy ignorowac wielkosc znakow wiec trzeba robic .ToLower().Contains( .ToLower())
            //zrobmy metode ktora robi to za nas
            return ob.ToUpper().Contains( value.ToUpper() );
        }
    }
}

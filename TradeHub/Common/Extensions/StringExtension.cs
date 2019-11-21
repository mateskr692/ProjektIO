using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// Returns value indicating wether specified substring occurs within this string. Is not case sensitive
        /// </summary>
        /// <param name="value">The string to seek</param>
        /// <returns></returns>
        public static bool Like( this string ob, string value )
        {
            return ob.ToUpper().Contains( value.ToUpper() );
        }
    }
}

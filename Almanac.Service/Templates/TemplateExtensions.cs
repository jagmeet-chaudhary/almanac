using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almanac.Service.Templates
{
    public static class TemplateExtensions
    {
        public static string IfEmptyThen(this string str, string replaceString)
        {
            return string.IsNullOrWhiteSpace(str) ? replaceString : str;
        }

        public static string Test(this string str)
        {
            return str; 
        }
    }
}

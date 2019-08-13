using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Almanac.Service
{
    public interface ISettingsProvider
    {
        string GetSetting(string key);
    }
}

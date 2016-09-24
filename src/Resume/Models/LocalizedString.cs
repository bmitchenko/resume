using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Models
{
    public class LocalizedString : Dictionary<string, string>
    {
        public string GetString()
        {
            if (Count == 0)
            {
                return string.Empty;
            }

            var cultureName = CultureInfo.CurrentCulture.Name;

            if (ContainsKey(cultureName))
            {
                return this[cultureName];
            }

            if (cultureName.Contains("-"))
            {
                var neutralCultureName = cultureName.Split('-').First();

                if (ContainsKey(cultureName))
                {
                    return this[neutralCultureName];
                }
            }

            return this[Keys.First()];
        }
    }
}
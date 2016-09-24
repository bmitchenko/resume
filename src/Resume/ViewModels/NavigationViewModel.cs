using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.ViewModels
{
    public class NavigationViewModel
    {
        public ICollection<NavigationItemViewModel> Menu { get; set; }
        public ICollection<NavigationItemViewModel> Cultures { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.ViewModels
{
    public class PortfolioFilterViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public bool IsSelected { get; set; }
        public int ProjectCount { get; set; }
    }
}

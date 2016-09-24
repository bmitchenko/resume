using Resume.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.ViewModels
{
    public class PortfolioIndexViewModel
    {
        public List<PortfolioFilterViewModel> Filter { get; set; } = new List<PortfolioFilterViewModel>();
        public List<ProjectViewModel> Projects { get; set; } = new List<ProjectViewModel>();
        public string Header { get; set; }
    }
}

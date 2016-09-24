using Resume.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.ViewModels
{
    public class ExperienceIndexViewModel
    {
        public string Header { get; set; }
        public List<OrganizationViewModel> Organizations { get; set; } = new List<OrganizationViewModel>();
    }
}
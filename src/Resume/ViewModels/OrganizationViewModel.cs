using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.ViewModels
{
    public class OrganizationViewModel
    {
        public string Name { get; set; }
        public string JobTitle { get; set; }
        public string TimePeriod { get; set; }
        public bool IsRemote { get; set; }
        public List<string> Responsibilities { get; set; } = new List<string>();
        public List<TagViewModel> Projects { get; set; } = new List<TagViewModel>();
        public List<TagViewModel> Skills { get; set; } = new List<TagViewModel>();
    }
}

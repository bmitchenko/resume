using Resume.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.ViewModels
{
    public class SkillsIndexViewModel
    {
        public List<SkillViewModel> Skills { get; set; } = new List<SkillViewModel>();
        public List<Test> Tests { get; set; } = new List<Test>();
    }
}

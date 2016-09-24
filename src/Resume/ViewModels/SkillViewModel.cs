using Resume.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.ViewModels
{
    public class SkillViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public SkillCategory Category { get; set; }
        public int? Level { get; set; }
        public int? PlannedLevel { get; set; }
        public string ClassName { get; set; }
    }
}

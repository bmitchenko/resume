using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.ViewModels
{
    public class ProjectViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Task { get; set; }
        public string Action { get; set; }
        public string Result { get; set; }
        public int Year { get; set; }
        public string DemoLink { get; set; }
        public string SourceLink { get; set; }
        public List<TagViewModel> Skills { get; set; } = new List<TagViewModel>();
        public List<ScreenshotViewModel> Screenshots { get; set; } = new List<ScreenshotViewModel>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Resume.ViewModels;
using Microsoft.Extensions.Localization;
using Resume.Services;
using Resume.Models;

namespace Resume.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly EmploymentDb _db;
        private readonly IStringLocalizer<Program> _localizer;

        public PortfolioController(EmploymentDb db, IStringLocalizer<Program> localizer)
        {
            _db = db;
            _localizer = localizer;
        }

        public IActionResult Index(int? skillID = null, int? skillFamilyID = null)
        {
            var vm = new PortfolioIndexViewModel();
            vm.Header = _localizer["MenuPortfolio"];

            foreach (var skillFamiliy in _db.SkillFamilies)
            {
                vm.Filter.Add(CreateFilterViewModel(skillFamiliy, skillFamiliy.ID == skillFamilyID));
            }

            foreach (var skill in _db.Skills.Where(x => x.FamilyID == null))
            {
                var filterVm = CreateFilterViewModel(skill, skill.ID == skillID);

                if (filterVm.ProjectCount > 0)
                {
                    vm.Filter.Add(filterVm);
                }
            }

            vm.Filter = vm.Filter
                .OrderBy(x => x.Name)
                .ToList();

            vm.Filter.Insert(0, new PortfolioFilterViewModel
            {
                IsSelected = skillID == null && skillFamilyID == null,
                Name = _localizer["AllSkills"],
                ProjectCount = _db.Projects.Count(),
                Url = Url.Action("Index")
            });

            vm.Projects = GetVisibleProjects(skillID, skillFamilyID)
                .OrderByDescending(x => x.DateFinished ?? DateTime.Now)
                .Select(project => CreateProjectViewModel(project))
                .ToList();

            return View(vm);
        }

        #region Helpers

        private PortfolioFilterViewModel CreateFilterViewModel(Skill skill, bool isSelected)
        {
            var vm = new PortfolioFilterViewModel();

            vm.ID = skill.ID;
            vm.IsSelected = isSelected;
            vm.Name = skill.Name.GetString();
            vm.ProjectCount = _db.Projects.Count(x => x.Skills.Contains(skill.ID));
            vm.Url = Url.Action("Index", new { skillID = skill.ID });

            return vm;
        }

        private PortfolioFilterViewModel CreateFilterViewModel(SkillFamily skillFamily, bool isSelected)
        {
            var vm = new PortfolioFilterViewModel();

            var skills = _db.Skills
                .Where(x => x.FamilyID == skillFamily.ID)
                .Select(x => x.ID);

            vm.ID = skillFamily.ID;
            vm.IsSelected = isSelected;
            vm.Name = skillFamily.Name.GetString();
            vm.ProjectCount = _db.Projects.Count(p => p.Skills.Intersect(skills).Any());
            vm.Url = Url.Action("Index", new { skillFamilyID = skillFamily.ID });

            return vm;
        }

        private List<Project> GetVisibleProjects(int? skillID = null, int? skillFamilyID = null)
        {
            var visibleSkills = new HashSet<int>();

            foreach (var skill in _db.Skills)
            {
                if (skill.ID == skillID || skillID == null)
                {
                    if (skillFamilyID == null || skill.FamilyID == skillFamilyID)
                    {
                        visibleSkills.Add(skill.ID);
                    }
                }
            }

            return _db.Projects
                .Where(x => x.Skills.Intersect(visibleSkills).Any())
                .ToList();
        }

        private ProjectViewModel CreateProjectViewModel(Project project)
        {
            var vm = new ProjectViewModel();

            if (project.Action != null)
            {
                vm.Action = project.Action.GetString();
            }

            vm.DemoLink = project.DemoLink;
            vm.ID = project.ID;
            vm.Name = project.Name.GetString();

            if (project.Result != null)
            {
                vm.Result = project.Result.GetString();
            }

            if (project.Screenshots != null && project.Screenshots.Any())
            {
                vm.Screenshots = project.Screenshots
                    .Select(screenshot => CreateScreenshotViewModel(screenshot))
                    .ToList();
            }

            if (project.Skills != null && project.Skills.Any())
            {
                vm.Skills = project.Skills
                    .Select(skillID => _db.Skills.First(s => s.ID == skillID))
                    .Select(skill => CreateSkillTagViewModel(skill)).ToList();
            }

            vm.SourceLink = project.SourceLink;

            if (project.Task != null)
            {
                vm.Task = project.Task.GetString();
            }

            vm.Year = project.DateFinished?.Year ?? project.DateStarted.Year;

            return vm;
        }

        private ScreenshotViewModel CreateScreenshotViewModel(Screenshot screenshot)
        {
            var vm = new ScreenshotViewModel();

            vm.Description = screenshot.Description.GetString();
            vm.Height = screenshot.Height;
            vm.ThumbnailUrl = screenshot.ThumbnailUrl;
            vm.Url = screenshot.Url;
            vm.Width = screenshot.Width;

            return vm;
        }

        private TagViewModel CreateSkillTagViewModel(Skill skill)
        {
            var vm = new TagViewModel();

            vm.ID = skill.ID;
            vm.Name = skill.Name.GetString();
            vm.Url = Url.Action("Index", new { skillID = skill.ID });

            return vm;
        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Resume.Services;
using Resume.ViewModels;
using Microsoft.Extensions.Localization;
using Resume.Models;

namespace Resume.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly EmploymentDb _db;
        private readonly IStringLocalizer<Program> _localizer;

        public ExperienceController(EmploymentDb data, IStringLocalizer<Program> localizer)
        {
            _db = data;
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            var vm = new ExperienceIndexViewModel();

            vm.Header = _localizer.GetString("MenuWorkHistory");
            vm.Organizations = _db.Organizations
                .OrderByDescending(x => x.DateEmployed)
                .Select(organization => CreateOrganizationViewModel(organization))
                .ToList();

            return View(vm);
        }

        #region Helpers

        private OrganizationViewModel CreateOrganizationViewModel(Organization organization)
        {
            var vm = new OrganizationViewModel();

            vm.IsRemote = organization.IsRemote;
            vm.JobTitle = organization.JobTitle.GetString();
            vm.Name = organization.Name.GetString();
            vm.TimePeriod = organization.DateEmployed.ToString("MM.yyyy");

            if (organization.DateFired.HasValue)
            {
                vm.TimePeriod += $" - {organization.DateFired.Value.ToString("MM.yyyy")}";
            }
            else
            {
                vm.TimePeriod += $" - {_localizer["WorkPresent"]}";
            }

            vm.Responsibilities = organization.Responsibilities
                .Select(responsibility => responsibility.GetString())
                .ToList();

            var skillIDs = organization.Projects
                .Select(projectID => _db.Projects.First(project => project.ID == projectID))
                .SelectMany(project => project.Skills)
                .ToList();

            skillIDs.AddRange(organization.Skills);

            vm.Skills = skillIDs
                .Select(skillID => _db.Skills.First(skill => skill.ID == skillID))
                .Distinct()
                .Select(skill => new TagViewModel
                {
                    ID = skill.ID,
                    Name = skill.Name.GetString(),
                    Url = Url.Action("Index", "Portfolio", new { skillID = skill.ID })
                })
                .ToList();

            vm.Projects = organization.Projects
                .Select(projectID => _db.Projects.First(project => project.ID == projectID))
                .Select(project=>new TagViewModel
                {
                    ID = project.ID,
                    Name = project.Name.GetString(),
                    Url = Url.Action("Index", "Portfolio", null, null, null, $"project{project.ID}")
                })
                .ToList();

            return vm;
        }

        #endregion
    }
}
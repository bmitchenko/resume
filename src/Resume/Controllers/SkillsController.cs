using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Localization;
using Resume.Services;
using Resume.Models;
using Resume.ViewModels;

namespace Resume.Controllers
{
    public class SkillsController : Controller
    {
        private readonly EmploymentDb _db;
        private readonly IStringLocalizer<Program> _localizer;

        public SkillsController(EmploymentDb db, IStringLocalizer<Program> localizer)
        {
            _db = db;
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            var vm = new SkillsIndexViewModel();

            // сортируем активные навыки по весу;
            var skills = _db.Skills
                .Where(skill => skill.Status != SkillStatus.Inactive)
                .OrderByDescending(x => x.Level.HasValue)
                .ThenByDescending(x => x.Weight)
                .ToList();

            // группируем навыки по семействам;
            while (skills.Any())
            {
                var skill = skills.First();

                var name = skill.Name.GetString();

                if (skill.FamilyID.HasValue)
                {
                    var familySkills = skills
                        .Where(s => s.FamilyID == skill.FamilyID.Value)
                        .ToList();

                    if (familySkills.Count() > 1 && CanGroup(familySkills))
                    {
                        foreach (var familySkill in familySkills)
                        {
                            skills.Remove(familySkill);
                        }

                        name = string.Join(", ", familySkills.Select(familySkill => familySkill.Name.GetString()));
                    }
                    else
                    {
                        skills.Remove(skill);
                    }
                }
                else
                {
                    skills.Remove(skill);
                }

                var skillVm = new SkillViewModel
                {
                    Category = skill.Category,
                    Level = skill.Level,
                    Name = name,
                    PlannedLevel = skill.PlannedLevel
                };

                if (!skill.Level.HasValue)
                {
                    skillVm.ClassName += " secondary";
                }

                if (skill.Status == SkillStatus.Preferred)
                {
                    skillVm.ClassName += " preferred";
                }

                vm.Skills.Add(skillVm);
            }

            vm.Tests.AddRange(_db.Tests.OrderByDescending(x => x.Date));

            return View(vm);
        }

        #region Helpers

        private bool CanGroup(IEnumerable<Skill> skills)
        {
            var familyName = string.Join(", ", skills.Select(x => x.Name.GetString()));

            if (familyName.Length > 20)
            {
                return false;
            }

            var groups = from skill in skills
                         group skill by new { skill.Category, skill.Level } into g
                         select g;

            return groups.Count() == 1;
        }

        #endregion
    }
}

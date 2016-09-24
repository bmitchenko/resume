using Resume.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Resume.Services
{
    public class EmploymentDb
    {
        private IHostingEnvironment _environment;
        private List<Organization> _organizations;
        private List<Project> _projects;
        private List<Screenshot> _screenshots;
        private List<Skill> _skills;
        private List<SkillFamily> _skillFamilies;
        private List<Test> _tests;

        public EmploymentDb(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public ICollection<Organization> Organizations
        {
            get
            {
                if (_organizations == null)
                {
                    _organizations = LoadSet<Organization>(nameof(Organizations));
                }

                return _organizations;
            }
        }

        public ICollection<Project> Projects
        {
            get
            {
                if (_projects == null)
                {
                    _projects = LoadSet<Project>(nameof(Projects));
                }

                return _projects;
            }
        }

        public ICollection<Screenshot> Screenshots
        {
            get
            {
                if (_screenshots == null)
                {
                    _screenshots = LoadSet<Screenshot>(nameof(Screenshots));
                }

                return _screenshots;
            }
        }

        public ICollection<Skill> Skills
        {
            get
            {
                if (_skills == null)
                {
                    _skills = LoadSet<Skill>(nameof(Skills));
                }

                return _skills;
            }
        }

        public ICollection<SkillFamily> SkillFamilies
        {
            get
            {
                if (_skillFamilies == null)
                {
                    _skillFamilies = LoadSet<SkillFamily>(nameof(SkillFamilies));
                }

                return _skillFamilies;
            }
        }

        public ICollection<Test> Tests
        {
            get
            {
                if (_tests == null)
                {
                    _tests = LoadSet<Test>(nameof(Tests));
                }

                return _tests;
            }
        }

        public void Refresh()
        {
            _organizations = null;
            _projects = null;
            _screenshots = null;
            _skills = null;
            _skillFamilies = null;
            _tests = null;
        }

        public void SaveChanges()
        {
            SaveSet(Organizations, nameof(Organizations));
            SaveSet(Projects, nameof(Projects));
            SaveSet(Screenshots, nameof(Screenshots));
            SaveSet(Skills, nameof(Skills));
            SaveSet(SkillFamilies, nameof(SkillFamilies));
            SaveSet(Tests, nameof(Tests));
        }

        private List<T> LoadSet<T>(string name)
        {
            var path = Path.Combine(_environment.ContentRootPath, "Data", $"{name}.json");
            var contents = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<List<T>>(contents);
        }

        private void SaveSet<T>(ICollection<T> collection, string name)
        {
            var path = Path.Combine(_environment.ContentRootPath, "Data", $"{name}.json");
            var contents = JsonConvert.SerializeObject(collection, Formatting.Indented);

            File.WriteAllText(path, contents);
        }
    }
}
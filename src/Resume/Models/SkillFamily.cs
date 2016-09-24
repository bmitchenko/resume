using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Models
{
    /// <summary>
    /// Семейство навыков.
    /// </summary>
    public class SkillFamily
    {
        /// <summary>
        /// Код.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public LocalizedString Name { get; set; }

        /// <summary>
        /// Навыки.
        /// </summary>
        [JsonIgnore]
        public ICollection<Skill> Skills { get; set; }
    }
}
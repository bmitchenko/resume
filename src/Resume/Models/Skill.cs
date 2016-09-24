using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Models
{
    /// <summary>
    /// Навык.
    /// </summary>
    public class Skill
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
        /// Категория.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public SkillCategory Category { get; set; }

        /// <summary>
        /// Предшествующие навыки.
        /// </summary>
        public int[] PredecessorID { get; set; }

        /// <summary>
        /// Семейство навыков.
        /// </summary>
        public int? FamilyID { get; set; }

        /// <summary>
        /// Периоды использования.
        /// </summary>
        public List<DateRange> UsagePeriods { get; set; } = new List<DateRange>();

        /// <summary>
        /// Опыт (лет).
        /// </summary>
        [JsonIgnore]
        public decimal ExperienceYears
        {
            get
            {
                if (UsagePeriods.Count > 0)
                {
                    var years = UsagePeriods
                        .Select(x => (x.To ?? DateTime.Now) - x.From)
                        .Sum(x => x.TotalDays / 365);

                    return (decimal)Math.Round(years, 2);
                }

                return 0;
            }
        }

        /// <summary>
        /// Уровень знаний по 5-бальной шкале.
        /// </summary>
        public byte? Level { get; set; }

        /// <summary>
        /// Планируемый уровень знаний по 5-бальной шкале.
        /// </summary>
        public byte? PlannedLevel { get; set; }

        /// <summary>
        /// Статус навыка.
        /// </summary>
        public SkillStatus Status { get; set; }

        /// <summary>
        /// Важность.
        /// </summary>
        public byte Weight { get; set; }

        public override string ToString()
        {
            return Name.GetString();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Models
{
    /// <summary>
    /// Место работы.
    /// </summary>
    public class Organization
    {
        /// <summary>
        /// Код места работы.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Название компании.
        /// </summary>
        public LocalizedString Name { get; set; }

        /// <summary>
        /// Должность.
        /// </summary>
        public LocalizedString JobTitle { get; set; }
        
        /// <summary>
        /// Дата трудоустройства.
        /// </summary>
        public DateTime DateEmployed { get; set; }

        /// <summary>
        /// Дата увольнения.
        /// </summary>
        public DateTime? DateFired { get; set; }

        /// <summary>
        /// Удаленная работа.
        /// </summary>
        public bool IsRemote { get; set; }

        /// <summary>
        /// Обязанности.
        /// </summary>
        public ICollection<LocalizedString> Responsibilities { get; set; } = new List<LocalizedString>();

        /// <summary>
        /// Завершенные проекты.
        /// </summary>
        public ICollection<int> Projects { get; set; } = new HashSet<int>();

        /// <summary>
        /// Навыки (в дополнение к проектам).
        /// </summary>
        public ICollection<int> Skills { get; set; } = new HashSet<int>();
    }
}
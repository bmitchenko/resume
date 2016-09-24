using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Models
{
    /// <summary>
    /// Проект.
    /// </summary>
    public class Project
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
        /// Место работы.
        /// </summary>
        public int? OrganizationID { get; set; }

        /// <summary>
        /// Задача.
        /// </summary>
        public LocalizedString Task { get; set; }

        /// <summary>
        /// Действия.
        /// </summary>
        public LocalizedString Action { get; set; }

        /// <summary>
        /// Результат.
        /// </summary>
        public LocalizedString Result { get; set; }

        /// <summary>
        /// Дата начала.
        /// </summary>
        public DateTime DateStarted { get; set; }

        /// <summary>
        /// Дата завершения.
        /// </summary>
        public DateTime? DateFinished { get; set; }

        /// <summary>
        /// Ссылка на проект.
        /// </summary>
        public string DemoLink { get; set; }

        /// <summary>
        /// Ссылка на исходный код.
        /// </summary>
        public string SourceLink { get; set; }

        /// <summary>
        /// Задействованные навыки.
        /// </summary>
        public ICollection<int> Skills { get; set; } = new List<int>();

        /// <summary>
        /// Скриншоты.
        /// </summary>
        public ICollection<Screenshot> Screenshots { get; set; } = new List<Screenshot>();
    }
}
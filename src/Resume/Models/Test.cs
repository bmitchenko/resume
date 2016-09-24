using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Models
{
    /// <summary>
    /// Результат тестирования.
    /// </summary>
    public class Test
    {
        /// <summary>
        /// Код.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Компания, проводившая тестирование.
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// Название теста.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Количество баллов.
        /// </summary>
        public decimal Score { get; set; }

        /// <summary>
        /// Рейтинг в процентах.
        /// </summary>
        public decimal Rank { get; set; }

        /// <summary>
        /// Дата тестирования.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Время выполнения теста в минутах.
        /// </summary>
        public int TimeToComplete { get; set; }

        /// <summary>
        /// Ссылка на результаты теста.
        /// </summary>
        public string Link { get; set; }
    }
}

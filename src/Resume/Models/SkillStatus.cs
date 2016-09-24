using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Models
{
    /// <summary>
    /// Статус использования навыка.
    /// </summary>
    public enum SkillStatus
    {
        /// <summary>
        /// Используется.
        /// </summary>
        Active = 0,

        /// <summary>
        /// Предпочтительный навык.
        /// </summary>
        Preferred = 1,

        /// <summary>
        /// Не используется или устарел.
        /// </summary>
        Inactive = 2
    }
}
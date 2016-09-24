using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.Models
{
    /// <summary>
    /// Скриншот.
    /// </summary>
    public class Screenshot
    {
        /// <summary>
        /// URL уменьшенного изображения.
        /// </summary>
        public string ThumbnailUrl { get; set; }

        /// <summary>
        /// URL изображения.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Ширина.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Высота.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Комментарий.
        /// </summary>
        public LocalizedString Description { get; set; }
    }
}

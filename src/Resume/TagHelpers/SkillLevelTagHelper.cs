using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.TagHelpers
{
    public class SkillLevelTagHelper : TagHelper
    {
        public int Current { get; set; } = 0;
        public int? Planned { get; set; } = 0;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "skill-level");

            for (var i = 1; i <= 5; i++)
            {
                if (Current >= i)
                {
                    output.Content.AppendHtml("<span class='skill-level-fill'></span>");
                }
                else
                {
                    if ((Planned ?? 0) >= i)
                    {
                        output.Content.AppendHtml("<span class='skill-level-point'></span>");
                    }
                    else
                    {
                        output.Content.AppendHtml("<span class='skill-level-empty'></span>");
                    }
                }
            }

            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}

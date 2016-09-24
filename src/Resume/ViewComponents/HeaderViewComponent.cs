using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Resume.Services;
using Resume.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.ViewComponents
{
    [ViewComponent(Name = "Header")]
    public class HeaderViewComponent : ViewComponent
    {
        private readonly IStringLocalizer<Program> _localizer;

        public HeaderViewComponent(IStringLocalizer<Program> localizer)
        {
            _localizer = localizer;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var vm = new HeaderViewModel();

            vm.JobTitle = _localizer["HeaderJobTitle"];
            vm.HomeUrl = Url.Action("Index", "Skills");
            vm.Name = _localizer["HeaderName"];

            return View(await Task.FromResult(vm));
        }
    }
}
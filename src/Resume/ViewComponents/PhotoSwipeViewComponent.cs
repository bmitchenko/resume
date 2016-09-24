using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Resume.Services;
using Resume.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resume.ViewComponents
{
    [ViewComponent(Name = "PhotoSwipe")]
    public class PhotoSwipeViewComponent : ViewComponent
    {
        private readonly IStringLocalizer<Program> _localizer;

        public PhotoSwipeViewComponent(IStringLocalizer<Program> localizer)
        {
            _localizer = localizer;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var vm = new NavigationViewModel();
            vm.Cultures = new List<NavigationItemViewModel>();
            vm.Menu = new List<NavigationItemViewModel>();

            var menuItems = new[]
            {
                new { ControllerName = "Skills", Name = "MenuSkills" },
                new { ControllerName = "Portfolio", Name = "MenuPortfolio" },
                new { ControllerName = "Experience", Name = "MenuWorkHistory" }
            };

            var currentControllerName = ViewContext.RouteData.Values["controller"];

            foreach (var menuItem in menuItems)
            {
                var vmItem = new NavigationItemViewModel
                {
                    IsActive = string.Equals(currentControllerName as string, menuItem.ControllerName, StringComparison.OrdinalIgnoreCase),
                    Name = _localizer[menuItem.Name],
                    Url = Url.Action("Index", menuItem.ControllerName).ToLower()
                };

                vm.Menu.Add(vmItem);
            }

            var url = Request.Path.ToString().ToLower();
            url += url.Contains("?") ? "&" : "?";

            vm.Cultures.Add(new NavigationItemViewModel { Name = "EN", Url = "/en" });
            vm.Cultures.Add(new NavigationItemViewModel { Name = "RU", Url = "/" });

            return View(await Task.FromResult(vm));
        }
    }
}
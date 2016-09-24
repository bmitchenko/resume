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
    [ViewComponent(Name = "Navigation")]
    public class NavigationViewComponent : ViewComponent
    {
        private readonly IStringLocalizer<Program> _localizer;

        public NavigationViewComponent(IStringLocalizer<Program> localizer)
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

            var routeValues = ViewContext.RouteData.Values;

            var controllerName = routeValues["controller"] as string;
            var actionName = routeValues["action"] as string;

            foreach (var menuItem in menuItems)
            {
                var menuUrl = Url.RouteUrl("default", new { controller = menuItem.ControllerName });

                if (ViewContext.RouteData.Values.ContainsKey("locale"))
                {
                    menuUrl = Url.RouteUrl("defaultLocalized", new { controller = menuItem.ControllerName, locale = ViewContext.RouteData.Values["locale"] });
                }

                var vmItem = new NavigationItemViewModel
                {
                    IsActive = string.Equals(controllerName, menuItem.ControllerName, StringComparison.OrdinalIgnoreCase),
                    Name = _localizer[menuItem.Name],
                    Url = menuUrl.ToLower()
                };

                vm.Menu.Add(vmItem);
            }
            
            vm.Cultures.Add(new NavigationItemViewModel { Name = "EN", Url = Url.Action(actionName, controllerName, new { locale = "en" }) });
            vm.Cultures.Add(new NavigationItemViewModel { Name = "RU", Url = Url.Action(actionName, controllerName, new { locale = "ru" }) });

            return View(await Task.FromResult(vm));
        }
    }
}
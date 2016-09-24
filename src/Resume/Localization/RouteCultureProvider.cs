using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Resume.Localization
{
    public class RouteCultureProvider : IRequestCultureProvider
    {
        private CultureInfo _defaultCulture;

        public RouteCultureProvider(CultureInfo defaultCulture)
        {
            _defaultCulture = defaultCulture;
        }

        public Task<ProviderCultureResult> DetermineProviderCultureResult(HttpContext httpContext)
        {
            //Parsing language from url path, which looks like "/en/home/index"
            PathString url = httpContext.Request.Path;

            // Test any culture in route
            if (url.ToString().Length <= 1)
            {
                // Set default Culture and default UICulture
                return Task.FromResult<ProviderCultureResult>(new ProviderCultureResult(_defaultCulture.TwoLetterISOLanguageName, _defaultCulture.TwoLetterISOLanguageName));
            }

            var parts = httpContext.Request.Path.Value.Split('/');
            var culture = parts[1];

            // Test if the culture is properly formatted
            if (!Regex.IsMatch(culture, @"^[a-z]{2}(-[A-Z]{2})*$"))
            {
                // Set default Culture and default UICulture
                return Task.FromResult<ProviderCultureResult>(new ProviderCultureResult(_defaultCulture.TwoLetterISOLanguageName, _defaultCulture.TwoLetterISOLanguageName));
            }

            // Set Culture and UICulture from route culture parameter
            return Task.FromResult(new ProviderCultureResult(culture, culture));
        }
    }
}

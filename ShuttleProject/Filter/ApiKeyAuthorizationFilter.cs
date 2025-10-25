using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ShuttleProject.Filter
{
    public class ApiKeyAuthorizationFilter
    {

        private const string ApiKeyHeaderName = "X-API-KEY";
        private readonly IConfiguration _configuration;

        // Constructor to inject services (like IConfiguration)
        public ApiKeyAuthorizationFilter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            
            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeaderName, out var extractedApiKey))
            {
                
                context.Result = new UnauthorizedResult();
                return;
            }

            
            var expectedApiKey = _configuration["ApiKey"];

            
            if (string.IsNullOrWhiteSpace(expectedApiKey) || !expectedApiKey.Equals(extractedApiKey))
            {
                
                context.Result = new UnauthorizedResult();
            }

            
        }
    }
}

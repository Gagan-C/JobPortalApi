

namespace JobPost.WebApp.Services
{
    
public class JobApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<JobApiClient> _logger;

        public JobApiClient(HttpClient httpClient, IHttpContextAccessor httpContextAccessor, ILogger<JobApiClient> logger)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public async Task<HttpResponseMessage> PostLogin(Object obj)
        {
            return await _httpClient.PostAsJsonAsync("/login?useCookies=true&useSessionCookies=true", obj);
        }

        public async Task<HttpResponseMessage> PostOnboardingEmployer(Object obj)
        {
            _logger.LogDebug(_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated.ToString());
            return await _httpClient.PostAsJsonAsync("/api/Onboarding/Employer", obj);
        }
    }
}



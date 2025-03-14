

namespace JobPost.WebApp.Services
{
    
public class JobApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public JobApiClient(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<HttpResponseMessage> PostLogin(Object obj)
        {
            return await _httpClient.PostAsJsonAsync("/login?useCookies=true&useSessionCookies=true", obj);
        }

        public async Task<HttpResponseMessage> PostOnboardingEmployer(Object obj)
        {
            Console.WriteLine(_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated);
            return await _httpClient.PostAsJsonAsync("/api/Onboarding/Employer", obj);
        }
    }
}



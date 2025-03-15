namespace JobPost.WebApp.Services
{
    public interface IJobPostClient
    {
        public  Task<HttpResponseMessage> PostLogin(object obj);
        public Task<HttpResponseMessage> PostOnboardingEmployer(object obj);
        public Task<HttpResponseMessage> PostUserRegistration(object obj);
    }
}

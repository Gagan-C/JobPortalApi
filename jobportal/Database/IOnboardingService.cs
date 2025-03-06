using jobportal.Dtos;

namespace jobportal.Database
{
    public interface IOnboardingService
    {
        public Task<int> OnboardEmployerAsync(EmployerOnboardingDTO employerOnboardingDTO);
    }
}

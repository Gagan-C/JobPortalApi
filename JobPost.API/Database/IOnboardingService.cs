using Jobpost.API.Dtos;

namespace Jobpost.API.Database
{
    public interface IOnboardingService
    {
        public Task<int> OnboardEmployerAsync(EmployerOnboardingDTO employerOnboardingDTO);
    }
}

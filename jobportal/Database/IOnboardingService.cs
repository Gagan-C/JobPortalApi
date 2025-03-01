using jobportal.Dtos;

namespace jobportal.Database
{
    public interface IOnboardingService
    {
        public int OnboardEmployer(EmployerOnboardingDTO employerOnboardingDTO);
    }
}

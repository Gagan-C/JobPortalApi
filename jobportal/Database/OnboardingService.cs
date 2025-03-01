using jobportal.Dtos;
using jobportal.Model;

namespace jobportal.Database
{
    public class OnboardingService : IOnboardingService
    {
        private readonly AppDbContext _appDbContext;
        public OnboardingService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public int OnboardEmployer(EmployerOnboardingDTO employerOnboardingDTO)
        {
            var existingAppUser = _appDbContext.AppUser
                .FirstOrDefault(u =>  u.FirstName != null &&
                u.FirstName.Equals(employerOnboardingDTO.EmployerFirstName) &&
                u.LastName!=null && u.LastName.Equals(employerOnboardingDTO.EmployerLastName)&&
                 u.Email != null && u.Email.Equals(employerOnboardingDTO.EmployerEmail) 
                );
            var existingCompany = _appDbContext.Company.FirstOrDefault(
                u => u.CompanyName != null && u.CompanyName.Equals(employerOnboardingDTO.CompanyName) &&
                u.CompanyAddress != null && u.CompanyAddress.Equals(employerOnboardingDTO.CompanyAddress));
            //duplicate entry
            if (existingAppUser != null && existingCompany!=null)
            {
                return -1;
            }
            var employer = new Employer()
            {
                AppUser=existingAppUser?? new AppUser(){
                    FirstName = employerOnboardingDTO.EmployerFirstName,
                    LastName = employerOnboardingDTO.EmployerLastName,
                    Email = employerOnboardingDTO.EmployerEmail
                },
                Company=existingCompany?? new Company()
                {
                    CompanyAddress = employerOnboardingDTO.CompanyAddress,
                    CompanyName = employerOnboardingDTO.CompanyName
                }
            };
            _appDbContext.Employers.Add(employer);
            return _appDbContext.SaveChanges();
        }
    }
}

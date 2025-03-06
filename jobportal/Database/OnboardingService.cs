using jobportal.Dtos;
using jobportal.Model;
using Microsoft.AspNetCore.Identity;
using System.Runtime.Intrinsics.X86;

namespace jobportal.Database
{
    public class OnboardingService : IOnboardingService
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<User> _userManager;
        public OnboardingService(AppDbContext appDbContext, UserManager<User> userManager)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
        }
        public async Task<int> OnboardEmployerAsync(EmployerOnboardingDTO employerOnboardingDTO)
        {
            var existingCompany = _appDbContext.Company.FirstOrDefault(
                u => u.CompanyName != null && u.CompanyName.Equals(employerOnboardingDTO.CompanyName) &&
                u.CompanyAddress != null && u.CompanyAddress.Equals(employerOnboardingDTO.CompanyAddress));

            if (employerOnboardingDTO.EmployerEmail!=null)
            {
                 var existingUser = await _userManager.FindByEmailAsync(employerOnboardingDTO.EmployerEmail);
                
                if(existingUser == null)
                {
                    var userCreation=await _userManager.CreateAsync(new User()
                    {
                        FirstName = employerOnboardingDTO.EmployerFirstName,
                        LastName = employerOnboardingDTO.EmployerLastName,
                        Email = employerOnboardingDTO.EmployerEmail,
                        PasswordHash = employerOnboardingDTO.Password,
                        UserName=employerOnboardingDTO.EmployerEmail
                    });
                    if (userCreation.Succeeded)
                    {
                         var newUser=await _userManager.FindByEmailAsync(employerOnboardingDTO.EmployerEmail);
                        if (newUser != null)
                        {
                            var employer = new Employer()
                            {
                                AppUser = newUser,
                                Company = existingCompany ?? new Company()
                                {
                                    CompanyAddress = employerOnboardingDTO.CompanyAddress,
                                    CompanyName = employerOnboardingDTO.CompanyName
                                }
                            };
                            _appDbContext.Employers.Add(employer);
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    else
                    {
                        return 0;
                    }

                }
                else
                {
                    var employer = new Employer()
                    {
                        AppUser = existingUser,
                        Company = existingCompany ?? new Company()
                        {
                            CompanyAddress = employerOnboardingDTO.CompanyAddress,
                            CompanyName = employerOnboardingDTO.CompanyName
                        }
                    };
                    _appDbContext.Employers.Add(employer);
                }
            }
            
            return _appDbContext.SaveChanges();
        }
    }
}

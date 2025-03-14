using Jobpost.API.Database;
using Jobpost.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jobpost.API.Controllers
{
    [Route("/api/[controller]")]
    public class OnboardingController: ControllerBase
    {
        private readonly IOnboardingService _onboardingService;
        private readonly ILogger<OnboardingController> _logger;
        public OnboardingController(IOnboardingService onboardingService, ILogger<OnboardingController> logger)
        {
            _onboardingService = onboardingService;
            _logger = logger;
        }
        [HttpPost]
        [Authorize]
        [Route("/api/[controller]/Employer")]
        public async Task<IActionResult> OnboardEmployerAsync([FromBody] EmployerOnboardingDTO employerOnboardingDTO)
        {
            _logger.LogInformation($"Initiated onboarding for user:{employerOnboardingDTO.EmployerFirstName} {employerOnboardingDTO.EmployerLastName} Email: {employerOnboardingDTO.EmployerEmail}");

            var result = await _onboardingService.OnboardEmployerAsync(employerOnboardingDTO);

            if (result > 0)
            {
                return StatusCode(201, new { message = "Employer Created Sucessfully" });
            }
            else if (result == -1)
            {
                return StatusCode(304);
                //return StatusCode(304, new { message = "Duplicate Information found" });
            }
          return StatusCode(500, new { message = "Unable to create Employer please check data" });
        }
    }
}

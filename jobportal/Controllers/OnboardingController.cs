using jobportal.Database;
using jobportal.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace jobportal.Controllers
{
    [Route("/api/[controller]")]
    public class OnboardingController: ControllerBase
    {
        private readonly IOnboardingService _onboardingService;
        public OnboardingController(IOnboardingService onboardingService)
        {
            _onboardingService = onboardingService;
        }
        [HttpPost]
        [Authorize]
        [Route("/api/[controller]/Employer")]
        public async Task<IActionResult> OnboardEmployerAsync([FromBody] EmployerOnboardingDTO employerOnboardingDTO)
        {
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

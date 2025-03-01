using jobportal.Dtos;
using jobportal.Model;
using Microsoft.EntityFrameworkCore;

namespace jobportal.Database
{
    public class PostService : IPostService
    {
        private readonly AppDbContext _appDbContext;
        public PostService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<PostResultDTO> GetPostValue()
        {
            var posts = _appDbContext.Jobposts
                .Include(j => j.Employer)
                .ThenInclude(e => e.Company)
                .Include(j => j.Employer)
                .ThenInclude(e => e.AppUser)
                .ToList();

            var result = new List<PostResultDTO>();
            foreach (var post in posts)
            {
                result.Add(new PostResultDTO
                {
                    JobTitle = post.JobTile,
                    JobDecription = post.JobDescription,
                    CompanyName = post.Employer?.Company?.CompanyName,
                    PostedBy = post.Employer?.AppUser?.FirstName + " " + post.Employer?.AppUser?.LastName
                });
            }
            return result;
        }

        public int PostJob(PostJobDTO postJobDTO)
        {
            var employer = _appDbContext.Employers.Find(postJobDTO.EmployerId);
            if (employer == null) { return -1; }
            Jobpost job = new Jobpost
            {
                JobTile = postJobDTO.JobTitle,
                JobDescription = postJobDTO.JobDescription,
                Employer = employer
            };
            _appDbContext.Jobposts.Add(job);
            return _appDbContext.SaveChanges();
        }
    }
}

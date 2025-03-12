using Jobpost.API.Dtos;

namespace Jobpost.API.Database
{
    public interface IPostService
    {
        public IEnumerable<PostResultDTO> GetPostValue();
        public int PostJob(PostJobDTO postJobDTO);
    }
}

using jobportal.Dtos;

namespace jobportal.Database
{
    public interface IPostService
    {
        public IEnumerable<PostResultDTO> GetPostValue();
        public int PostJob(PostJobDTO postJobDTO);
    }
}

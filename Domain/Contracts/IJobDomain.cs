using DTO.JobDTO;


namespace Domain.Contracts
{
    public interface IJobDomain
    {
        IList <JobDTO> GetAllJobs();
        JobDTO GetJobById(Guid id);
        JobDTO Add(JobDTO job);
        void Update(JobDTO job);
        void Remove(Guid id);
    }
}

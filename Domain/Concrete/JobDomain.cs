using AutoMapper;
using DAL.Contracts;
using DAL.UoW;
using Domain.Contracts;
using DTO.JobDTO;
using Entities.Model;
using Microsoft.AspNetCore.Http;


namespace Domain.Concrete
{
    internal class JobDomain : DomainBase, IJobDomain
    {

        public JobDomain(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor) { }
        
        private IJobRepository jobRepository => _unitOfWork.GetRepository<IJobRepository>();

        public IList<JobDTO> GetAllJobs()
        {
            IEnumerable<Job> jobs = jobRepository.GetAll();
            var test = _mapper.Map<IList<JobDTO>>(jobs);
            return test;
        }
        public JobDTO Add(JobDTO job)
        {
            var data = _mapper.Map<JobDTO, Job>(job);
            var JobData = jobRepository.Add(data);

            var JobDTOdata = _mapper.Map<Job, JobDTO>(JobData);
            return JobDTOdata;
        }

        public JobDTO GetJobById(Guid id)
        {
            Job user = jobRepository.GetById(id);
            return _mapper.Map<JobDTO>(user);
        }

        public void Remove(Guid id)
        {
            jobRepository.Remove(id);
        }

        public void Update(JobDTO job)
        {
            
            var jobData = jobRepository.GetById(job.Id);
            if (jobData != null)
                jobRepository.Update(jobData);
        }

    }
}

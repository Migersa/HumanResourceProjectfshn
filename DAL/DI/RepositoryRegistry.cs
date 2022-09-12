using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Concrete;
//using DAL.Concrete;
using DAL.Contracts;
using Lamar;

namespace DAL.DI
{
    public class RepositoryRegistry : ServiceRegistry
    {
        public RepositoryRegistry()
        {
            IncludeRegistry<UnitOfWorkRegistry>();
            For<IEmailRepository>().Use<EmailRepository>();
            For<IEmployeeRepository>().Use<EmployeeRepository>();
            For<IProjectRepository>().Use<ProjectRepository>();
            For<IArchiveRepository>().Use<ArchiveRepository>();
            For<IEducationRepository>().Use<EducationRepository>();
            For<IJobRepository>().Use<JobRepository>();
            For<ILoginRepository>().Use<LoginRepository>();
            For<IPermitRepository>().Use<PermitRepository>();
            For<IRolesRepository>().Use<RoleRepository>();







        }


    }
}


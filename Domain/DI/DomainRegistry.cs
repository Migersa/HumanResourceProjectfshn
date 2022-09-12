using DAL.DI;
using Domain.Concrete;
using Domain.Contracts;
using Lamar;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DI
{
    public class DomainRegistry : ServiceRegistry
    {
        public DomainRegistry()
        {
            IncludeRegistry<DomainUnitOfWorkRegistry>();


            For<IEmailDomain>().Use<EmailDomain>();
            For<IRoleDomain>().Use<RoleDomain>();
            For<IArchiveDomain>().Use<ArchiveDomain>();

            For<IPermitDomain>().Use<PermitDomain>();
            For<IEmployeeDomain>().Use<EmployeeDomain>();
            For<ILoginDomain>().Use<LoginDomain>();
            For<IEducationDomain>().Use<EducationDomain>();
            For<IJobDomain>().Use<JobDomain>();
            For<IProjectDomain>().Use<ProjectDomain>();
            AddRepositoryRegistries();
            AddHttpContextRegistries();
        }

        private void AddRepositoryRegistries()
        {
            IncludeRegistry<RepositoryRegistry>();
        }

        private void AddHttpContextRegistries()
        {
            For<IHttpContextAccessor>().Use<HttpContextAccessor>();
        }
    }
}

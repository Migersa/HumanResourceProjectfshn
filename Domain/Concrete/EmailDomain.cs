using AutoMapper;
using DAL.Contracts;
using DAL.UoW;
using Domain.Contracts;
using Entities.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    internal class EmailDomain : DomainBase, IEmailDomain
    {
        public EmailDomain(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor) { }
        private IEmailRepository emailRepository => _unitOfWork.GetRepository<IEmailRepository>();
        public void SendEmail(Employee employee, string subject, string body)
        {
            emailRepository.SendEmail(employee, subject, body);
        }
    }
}


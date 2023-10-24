using Entities.Model;


namespace Domain.Contracts
{
    internal interface IEmailDomain
    {
        void SendEmail(Employee employee, string subject, string body);
    }
}

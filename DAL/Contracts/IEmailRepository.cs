﻿using Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IEmailRepository
    {
        void SendEmail(Employee employee, string subject, string body);
    }
}

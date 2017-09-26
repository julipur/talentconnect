using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TalentConnect.Domain.Model
{
    public enum JobTypes
    {
        Contract = 1, 
        Employee,
        Freelance,
        Internship
    }

    public enum Role
    {
        Admin = 1,
        User
    }
}
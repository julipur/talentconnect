using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace TalentConnect.Domain.Commands
{
    public abstract class BaseCommandHandler
    {
        public string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["TalentConnect"].ToString();
            }
        }
    }
}
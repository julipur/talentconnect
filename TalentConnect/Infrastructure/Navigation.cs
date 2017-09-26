using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TalentConnect.Infrastructure
{
    public class Navigation
    {
        public class About
        {
            public const string Controller = "about";
            public const string Index = "index";
        }
        public class Account
        {
            public const string Controller = "account";
            public const string Logon = "login";
            public const string Register = "register";
        }
        public class Application
        {
            public const string Controller = "application";
            public const string Index = "index";
        }
        public class Vacancies
        {
            public const string Controller = "vacancies";
            public const string Index = "index";
            public const string Details = "details";
        }

        public class Contact
        {
            public const string Controller = "contact";
            public const string Index = "index";
        }

        public class Employers
        {
            public const string Controller = "employers";
            public const string Index = "index";
        }

        public class Home
        {
            public const string Controller = "home";
            public const string Index = "index";
        }

        public class Jobs
        {
            public const string Area = "admin";
            public const string Controller = "jobs";
            public const string Index = "index";
            public const string Add = "add";
            public const string Edit = "edit";
        }

        public class Privacy
        {
            public const string Controller = "privacy";
            public const string Index = "index";
        }

        public class Terms
        {
            public const string Controller = "terms";
            public const string Index = "index";
        }
    }
}
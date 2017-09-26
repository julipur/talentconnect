using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TalentConnect.ViewModels
{
    public class VacancyViewModel
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string JobType { get; set; }
        public string ClosingDate { get; set; }
        public int? YearsOfExperince { get; set; }
        public int? Hours { get; set; } 
        public string Rate { get; set; }
        public bool Filled { get; set; }
        public bool Active { get; set; }
        public string CreatedDate { get; set; }
    }
}
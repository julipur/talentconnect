using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TalentConnect.Infrastructure;

namespace TalentConnect.Areas.Admin.ViewModels
{
    public class JobViewModel
    {
        public int? Id { get; set; }
        [Display(Name = "Title"), Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }
        [Display(Name = "Short Description"), Required(ErrorMessage = "Short Description is required.")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        public string City { get; set; }

        [Display(Name = "Province")]
        public string SelectedProvince { get; set; }

        public IEnumerable<Province> Provinces { get; set; }

        [Display(Name = "Job Type"), Required(ErrorMessage = "Job type is required.")]
        public string SelectedJobType { get; set; }

        public SortedDictionary<string, string> JobTypes { get; set; }

        [Display(Name ="Closing Date")]
        public string ClosingDate { get; set; }
       
        [Display(Name = "Year of Experience")]
        public int? YearsOfExperince { get; set; }
        public int? Hours { get; set; }
        public string Rate { get; set; }
        public bool Filled { get; set; }
        public bool Active { get; set; }
        public string CreatedDate { get; set; }

        internal static JobViewModel CreateEmpty()
        {
            var viewModel = new JobViewModel();
            viewModel.InitializeLists();
            return viewModel;
        }

        internal void InitializeLists()
        {
            Provinces = Province.GetProvinces();
            JobTypes = new SortedDictionary<string, string>()
                            {
                                { "Contract", "Contract" },
                                { "Employee", "Employee" },
                                { "Freelance", "Freelance" },
                                { "Internship", "Internship" },
                                { "FullTime", "Full-Time" },
                                { "PartTime", "Part-Time" }
                            };
        }
    }
}
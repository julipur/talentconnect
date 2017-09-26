using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TalentConnect.Domain.Queries;
using TalentConnect.ViewModels;

namespace TalentConnect.Controllers
{
    public class VacanciesController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var dto = new GetActiveVacancies().ExecuteQuery();

            var vm = new VacanciesViewModel()
            {
                Vacancies = dto.Select(v => new VacancyViewModel()
                {
                    Id = v.Id,
                    Title = v.Title,
                    ShortDescription = v.ShortDescription,
                    Description = v.Description,
                    City = v.City,
                    Province = v.Province,
                    JobType = v.JobType.ToString(),
                    YearsOfExperince = v.YearsOfExperience,
                    ClosingDate = v.ClosingDate.HasValue ? v.ClosingDate.Value.ToString("MMM dd, yyyy") : string.Empty,
                    Hours = v.Hours,
                    Rate = v.Rate
                })
            };

            return View(vm);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var dto = new GetJobById().ExecuteQuery(id);
            var vm = new VacancyViewModel()
            {
                Id = dto.Id,
                Title = dto.Title,
                ShortDescription = dto.ShortDescription,
                Description = dto.Description,
                City = dto.City,
                Province = dto.Province,
                JobType = dto.JobType,
                ClosingDate = dto.ClosingDate.HasValue ? dto.ClosingDate.Value.ToString("dd-MM-yyyy") : string.Empty,
                YearsOfExperince = dto.YearsOfExperience,
                Hours = dto.Hours,
                Rate = dto.Rate,
                Filled = dto.Filled,
                Active = dto.Active
            };

            return View(vm);
        }
    }
}
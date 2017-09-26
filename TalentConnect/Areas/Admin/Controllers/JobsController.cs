using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TalentConnect.Areas.Admin.ViewModels;
using TalentConnect.Domain.Commands;
using TalentConnect.Domain.Queries;
using TalentConnect.Infrastructure;


namespace TalentConnect.Areas.Admin.Controllers
{
    [Authorize(Roles="Admin")]
    public class JobsController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var query = new GetJobs();
            var dto = await query.ExecuteQuery().ConfigureAwait(false);

            var vm = new JobsViewModel()
            {
                Jobs = dto.Select(j => new JobViewModel()
                {
                    Id = j.Id,
                    Title = j.Title,
                    ShortDescription = j.ShortDescription,
                    Description = j.Description,
                    City = j.City,
                    SelectedProvince = j.Province,
                    SelectedJobType = j.JobType.ToString(),
                    YearsOfExperince = j.YearsOfExperience,
                    ClosingDate = j.ClosingDate.HasValue ?  j.ClosingDate.Value.ToString("MMM dd, yyyy") : string.Empty,
                    Hours = j.Hours,
                    Rate = j.Rate,
                    Filled = j.Filled,
                    Active = j.Active,
                    CreatedDate = j.CreatedDate.ToString("MMM dd, yyyy")
                })
            };

            return View(vm);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(JobViewModel.CreateEmpty());
        }

        [HttpPost, ValidateInput(false)]
        public async Task<ActionResult> Add(JobViewModel vm)
        {
            await new AddJobCommandHandler().HandleAsync(
                new AddJobCommand()
                {
                    Title = vm.Title,
                    ShortDescription= vm.ShortDescription,
                    Description = vm.Description,
                    City = vm.City,
                    Province = vm.SelectedProvince,
                    JobType = vm.SelectedJobType,
                    ClosingDate = vm.ClosingDate,
                    YearOfExperince = vm.YearsOfExperince,
                    Hours = vm.Hours,
                    Rate = vm.Rate
                }).ConfigureAwait(false);

            return RedirectToAction(Navigation.Jobs.Index, Navigation.Jobs.Controller);
            
            vm.InitializeLists();
            return View(vm);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var dto = new GetJobById().ExecuteQuery(id);
            
            var vm = new JobViewModel()
            {
                Id = dto.Id,
                Title = dto.Title,
                ShortDescription = dto.ShortDescription,
                Description = dto.Description,
                City = dto.City,
                SelectedProvince = dto.Province,
                SelectedJobType = dto.JobType,
                YearsOfExperince = dto.YearsOfExperience,
                ClosingDate = dto.ClosingDate.HasValue ? dto.ClosingDate.Value.ToString("dd-MM-yyyy") : string.Empty,
                Hours = dto.Hours,
                Rate = dto.Rate,
                Active = dto.Active,
                Filled = dto.Filled
            };

            vm.InitializeLists();
            return View(vm);
        }

        [HttpPost, ValidateInput(false)]
        public async Task<ActionResult> Edit(int id, JobViewModel vm )
        {
            var dto = new GetJobById().ExecuteQuery(id);

            await new UpdateJobCommandHandler().HandleAsync(
                new UpdateJobCommand()
                {
                    Id = id,
                    Title = vm.Title,
                    ShortDescription = vm.ShortDescription,
                    Description = vm.Description,
                    City = vm.City,
                    Province = vm.SelectedProvince,
                    JobType = vm.SelectedJobType,
                    ClosingDate = vm.ClosingDate,
                    YearOfExperince = vm.YearsOfExperince,
                    Hours = vm.Hours,
                    Rate = vm.Rate,
                    Filled = vm.Filled,
                    Active = vm.Active
                }).ConfigureAwait(false);

            vm.InitializeLists();
            return View(vm);
        }
    }
}
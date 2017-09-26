using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TalentConnect.ViewModels
{
    public class VacanciesViewModel
    {
        public IEnumerable<VacancyViewModel> Vacancies { get; set; }
    }
}
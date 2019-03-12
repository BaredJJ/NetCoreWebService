using System;
using Microsoft.AspNetCore.Mvc;
using WebService.Infrastructure;
using WebService.Models;
using System.Linq;

namespace WebService.Controllers
{
    public class HomeController:Controller
    {
        private readonly CourseService _courseService;
        private readonly ICurrencyRepository _currencyRepository;

        public HomeController(CourseService courseService, ICurrencyRepository currencyRepository)
        {
            _courseService = courseService ?? throw new ArgumentException(nameof(courseService));
            _currencyRepository = currencyRepository ?? throw new ArgumentNullException(nameof(currencyRepository));
        }

        public ViewResult List()
        {
            CurrentCurrency result = _currencyRepository.CurrentCurrency.FirstOrDefault(x => x.Date == DateTime.Now.Date.AddDays(-1)); ;
            if (result == null)
            {
                result = _courseService.GetCurrentCourse();
                _currencyRepository.Add(result);
            }

            return View(result);
        }
    }
}

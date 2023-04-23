using EntityFrameworkLabb1.Data;
using EntityFrameworkLabb1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labb1EntityFramework.Controllers
{
    public class InfoVacationController : Controller
    {
        private readonly VacationDbContext context; //injection - delvis
        public InfoVacationController(VacationDbContext _context) //tar in databasen till controllern
        {
            context = _context;
        }
        public async Task<IActionResult> Index() //async mot Tasken när man jobbar mot databaser
        {
            List<InfoVacationViewModel> list = new List<InfoVacationViewModel>(); //ny lista frpn infoVacationViewModel
            var items = await (from emp in context.Employees
                               join vl in context.VacationLists on emp.Id equals vl.FK_Id
                               join ab in context.Vacations on vl.FK_VacationId equals ab.VacationId
                               select new
                               {
                                   StartDate = vl.StartDate,
                                   EndDate = vl.EndDate,
                                   VacationType = ab.VacationType,
                                   FirstName = emp.FirstName,
                                   LastName = emp.LastName,
                                   Role = emp.Role,
                               }).ToListAsync();
            //konvertera från anonym
            foreach (var item in items)
            {
                InfoVacationViewModel listItem = new InfoVacationViewModel();
                listItem.StartDate = item.StartDate;
                listItem.EndDate = item.EndDate;
                listItem.VacationType = item.VacationType;
                listItem.FirstName = item.FirstName;
                listItem.LastName = item.LastName;
                list.Add(listItem);
            }
            return View(list);
        }
    }
}

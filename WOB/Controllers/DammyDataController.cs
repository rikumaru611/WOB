using Microsoft.AspNetCore.Mvc;
using WOB.Data;

namespace WOB.Controllers
{
    public class DammyDataController : Controller
    {
        private readonly ApplicationDbContext _db;
        public DammyDataController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            Service.DammyDataService.InsertDammyData(_db);
            return View();
        }
    }
}

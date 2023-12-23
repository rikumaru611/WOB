using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Bogus.DataSets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WOB.Data;
using WOB.Models;

namespace WOB.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// スケジュールを表示します
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {            
            return View();
        }

        /// <summary>
        /// すべてのEventを取得します。
        /// </summary>
        /// <returns>戻り値はJson形式です。</returns>
        public string? GetEvents()
        {
            var events = _context.events;
            List<EventViewModel> eventViewModels = new List<EventViewModel>();
            if(events == null)
            {
                return null;
            }
            else
            {
                foreach (var eve in events)
                {
                    eventViewModels.Add(new EventViewModel(eve));
                }
            }
            return JsonSerializer.Serialize(eventViewModels);         
        }
    }
}

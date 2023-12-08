
using ASP_с_бд.ContextData;
using ASP_с_бд.Entities;
using ASP_с_бд.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_с_бд.Controllers
{
    public class TelephoneDescriptionController : Controller
    {
        DbContextOptions options;

        private readonly ITelephoneDescriptionData telephoneDescriptionData;

        public TelephoneDescriptionController(ITelephoneDescriptionData TelephoneDescriptionData)
        {
            this.telephoneDescriptionData = TelephoneDescriptionData;
        }
        public IActionResult AllView()
        {
            //ViewBag.TelephoneDescriptions = new DataContext().telephoneDescriptions;
            //return View();
            return View(telephoneDescriptionData.GetTelephoneDescriptions());
        }
        [HttpGet]
        [Authorize]
        public IActionResult Add()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        public IActionResult EditIndification()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var db = new DataContext(options);
            if (id != null)
            {
                TelephoneDescription? telephoneDescriptions = await db.telephoneDescriptions.FirstOrDefaultAsync(p => p.ID == id);
                if (telephoneDescriptions != null) return View(telephoneDescriptions);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(TelephoneDescription telephoneDescriptions)
        {
            var db = new DataContext(options);
            db.telephoneDescriptions.Update(telephoneDescriptions);
            await db.SaveChangesAsync();
            return RedirectToAction("AllView");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteOne(int? id)
        {
            if (id != null)
            {
                var db = new DataContext(options);
                TelephoneDescription? user = await db.telephoneDescriptions.FirstOrDefaultAsync(p => p.ID == id);
                if (user != null)
                {
                    db.telephoneDescriptions.Remove(user);
                    await db.SaveChangesAsync();
                    return RedirectToAction("AllView");
                }
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult GetDataFromViewField( string lastName,string name,string middleName,string numberTelephone,string adress,string description)
        {
            //using(
            //    var db=new DataContext())
            //{
            //    db.telephoneDescriptions.Add(
            //        new TelephoneDescription()
            //        {

            //            LastName = lastName,
            //            Name = name,
            //            MiddleName = middleName,
            //            NumberTelephone = numberTelephone,
            //            Adress = adress,
            //            Description = description,
            //        }
            //        );
            //    db.SaveChanges();
            //}
            //return Redirect("~/");
            var telephoneDescription = new TelephoneDescription()
            {
                LastName = lastName,
                Name = name,
                MiddleName = middleName,
                NumberTelephone = numberTelephone,
                Adress = adress,
                Description = description
            };

            telephoneDescriptionData.AddTelephoneDescription(telephoneDescription);
            return Redirect("~/");
        }
            
    }
}

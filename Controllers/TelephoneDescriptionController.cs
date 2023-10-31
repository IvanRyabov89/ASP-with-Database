
using ASP_с_бд.ContextData;
using ASP_с_бд.Entities;
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
       
        public IActionResult AllView()
        {
            ViewBag.TelephoneDescriptions = new DataContext().telephoneDescriptions;
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Delete()
        {
            return View();
        }
        public IActionResult Update()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var db = new DataContext();
            if (id != null)
            {
                TelephoneDescription? user = await db.telephoneDescriptions.FirstOrDefaultAsync(p => p.ID == id);
                if (user != null) return View(user);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(TelephoneDescription telephoneDescriptions)
        {
            var db = new DataContext();
            db.telephoneDescriptions.Update(telephoneDescriptions);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteOne(int? id)
        {
            if (id != null)
            {
                var db = new DataContext();
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
        public IActionResult GetDataFromViewField(string lastName,string name,string middleName,string numberTelephone,string adress,string description)
        {
            using(var db=new DataContext())
            {
                db.telephoneDescriptions.Add(
                    new TelephoneDescription()
                    {
                        LastName = lastName,
                        Name = name,
                        MiddleName = middleName,
                        NumberTelephone = numberTelephone,
                        Adress = adress,
                        Description = description,
                    }
                    );
                db.SaveChanges();
            }
            return Redirect("~/");
        }
            
    }
}

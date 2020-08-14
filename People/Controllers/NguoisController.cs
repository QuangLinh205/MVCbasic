using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using People.Data;
using People.Models;

namespace People.Controllers
{
    public class NguoisController : Controller
    {
        private readonly PeopleContext _context;

        public NguoisController(PeopleContext context)
        {
            _context = context;
        }

         
        public ActionResult Index()
        {
            return View( _context.Nguoi.ToList()); //ToListAsync để lấy về tất cả các dữ liệu (List) của bảng
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound(); // trả về lỗi HTTP 404 cho client
            }

            var nguoi = _context.Nguoi
                .FirstOrDefault(m => m.Id == id);
            if (nguoi == null)
            {
                return NotFound();
            }

            return View(nguoi);
        }

        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Name,Age")] Nguoi nguoi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nguoi);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(nguoi);
        }

        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoi = _context.Nguoi.Find(id);
            if (nguoi == null)
            {
                return NotFound();
            }
            return View(nguoi);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,Name,Age")] Nguoi nguoi)
        {
            if (id != nguoi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nguoi);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NguoiExists(nguoi.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(nguoi);
        }

        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nguoi =  _context.Nguoi
                .FirstOrDefault(m => m.Id == id);
            if (nguoi == null)
            {
                return NotFound();
            }

            return View(nguoi);
        }

         
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var nguoi =  _context.Nguoi.Find(id);
            _context.Nguoi.Remove(nguoi);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool NguoiExists(int id)
        {
            return _context.Nguoi.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Search(string SearchString)
        {
            var nguoi = from m in _context.Nguoi select m;
            if (!string.IsNullOrEmpty(SearchString)){
                nguoi = nguoi.Where(s => s.Name.Contains(SearchString));
            }
            return View(await nguoi.ToListAsync());
        }
        public async Task<IActionResult> SearchTheoID(string id)
        {
            var nguoi = from m in _context.Nguoi select m;
            if (id == null)
            {
                return NotFound();
            }
            return View(await nguoi.ToListAsync());
        }
    }
}

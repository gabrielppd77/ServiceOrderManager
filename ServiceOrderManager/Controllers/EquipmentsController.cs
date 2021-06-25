using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceOrderManager.Data;
using ServiceOrderManager.Models;
using ServiceOrderManager.Services;
using ServiceOrderManager.Services.Exceptions;

namespace ServiceOrderManager.Controllers
{
    public class EquipmentsController : Controller
    {
        private readonly EquipmentService _equipmentService;

        public EquipmentsController(EquipmentService equipmentService)
        {
            _equipmentService = equipmentService;
        }

        // GET: Equipments
        public async Task<IActionResult> Index()
        {
            var list = await _equipmentService.FindAllAsync();
            return View(list);
        }

        // GET: Equipments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Equipments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,InternalControl,Details")] Equipment equipment)
        {
            if (!ModelState.IsValid)
            {
                return View(equipment);
            }
            await _equipmentService.InsertAsync(equipment);
            return RedirectToAction(nameof(Index));
        }

        // GET: Equipments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Index), new { message = "Id not Provided" });
            }
            var equipment = await _equipmentService.FindByIdAsync(id.Value);
            if (equipment == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            return View(equipment);
        }

        // POST: Equipments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,InternalControl,Details")] Equipment equipment)
        {
            if (!ModelState.IsValid)
            {
                return View(equipment);
            }
            if (id != equipment.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mistmatch" });
            }
            try
            {
                await _equipmentService.UpdateAsync(equipment);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        // GET: Equipments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provieded" });
            }

            var equipment = await _equipmentService.FindByIdAsync(id.Value);

            if (equipment == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }
            return View(equipment);
        }

        // POST: Equipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _equipmentService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

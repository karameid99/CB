using CB.Infrastructure.Services.Supervisor;
using CB.Models.Constants;
using CB.Models.DTOs.Helpers;
using CB.Models.DTOs.Supervisor;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CB.Web.Controllers
{
    public class SupervisorController : BaseController
    {
        private readonly ISupervisorService _supervisorService;

        public SupervisorController(ISupervisorService supervisorService)
        {
            _supervisorService = supervisorService;
        }

        [HttpPost]
        public async Task<JsonResult> GetAll(Pagination pagination, Query query)
        {
            var response = await _supervisorService.GetAll(pagination, query);
            return Json(response);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SupervisorCreateDto input)
        {
            if (ModelState.IsValid)
            {
                await _supervisorService.Create(input, "");
                return Content(Results.AddSuccessResult());
            }
            return View(input);
        }
        public async Task<IActionResult> Edit(string id)
        {
            return View(await _supervisorService.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SupervisorUpdateDto input)
        {
            if (ModelState.IsValid)
            {
                await _supervisorService.Update(input, "");
                return Content(Results.EditSuccessResult());
            }
            return View(input);
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _supervisorService.Delete(id, "");
            return Content(Results.DeleteSuccessResult());
        }
    }
}

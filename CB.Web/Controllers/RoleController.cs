using CB.Infrastructure.Services.Role;
using CB.Models.Constants;
using CB.Models.DTOs.Helpers;
using CB.Models.DTOs.Role;
using CB.Models.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CB.Web.Controllers
{
    public class RoleController : BaseController
    {
        private readonly IRoleService _RoleService;

        public RoleController(IRoleService RoleService)
        {
            _RoleService = RoleService;
        }

        [HttpPost]
        public async Task<JsonResult> GetAll(Pagination pagination, Query query)
        {
            var response = await _RoleService.GetAll(pagination, query);
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
        public async Task<IActionResult> Create(RoleCreateDto input)
        {
            if (ModelState.IsValid)
            {
                await _RoleService.Create(input, "");
                return Ok(Results.AddSuccessResult());
            }
            return View(input);
        }
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _RoleService.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RoleUpdateDto input)
        {
            if (ModelState.IsValid)
            {
                await _RoleService.Update(input, "");
                return Ok(Results.EditSuccessResult());
            }
            return View(input);
        } 

        public async Task<IActionResult> Delete(int id)
        {
            await _RoleService.Delete(id, "");
            return Ok(Results.DeleteSuccessResult());
        }
    }
}

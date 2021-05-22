using CB.Infrastructure.Services.Client;
using CB.Models.Constants;
using CB.Models.DTOs.Client;
using CB.Models.DTOs.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CB.Web.Controllers
{

    public class ClientController : BaseController
    {
        private readonly IClientService _ClientService;

        public ClientController(IClientService ClientService)
        {
            _ClientService = ClientService;
        }
        [HttpPost]
        public async Task<JsonResult> GetAllAuctions(int id, Pagination pagination, Query query)
        {
            var response = await _ClientService.GetAllAuctions(id, pagination, query);
            return Json(response);
        }
        [HttpPost]
        public async Task<JsonResult> GetAll(Pagination pagination, Query query)
        {
            var response = await _ClientService.GetAll(pagination, query);
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
        public async Task<IActionResult> Profile(int id)
        {
            return View(await _ClientService.GetProfile(id));
        }
        [HttpPost]
        public async Task<IActionResult> Create(ClientCreateDto input)
        {
            if (ModelState.IsValid)
            {
                await _ClientService.Create(input, GetCurrntUserId());
                return Ok(Results.AddSuccessResult());
            }
            return View(input);
        }
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _ClientService.Get(id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ClientUpdateDto input)
        {
            if (ModelState.IsValid)
            {
                await _ClientService.Update(input, GetCurrntUserId());
                return Ok(Results.EditSuccessResult());
            }
            return View(input);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _ClientService.Delete(id, GetCurrntUserId());
            return Ok(Results.DeleteSuccessResult());
        }
    }

}
